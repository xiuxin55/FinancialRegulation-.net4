using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Xml;
using System.IO;
using System.Threading;
using System.Net;

namespace AutoUpdate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int availableUpdate;
        List<FileList> list = new List<FileList>();
        public MainWindow()
        {

            InitializeComponent();
            this.Visibility = System.Windows.Visibility.Visible;
            this.button1.IsEnabled = false;
            //DownLoadFile down = new DownLoadFile();
            //down.DownLoad("http://localhost/ERPSCD.Srv/UpdateList.xml", CommonData.Current.CurrentDir + "CheckUpdateList.xml");
            Hashtable htUpdateFile = new Hashtable();
            if (File.Exists("CheckUpdateList.xml"))
            {
                availableUpdate = CheckForUpdate("CheckUpdateList.xml", "UpdateList.xml", out htUpdateFile);

                if (availableUpdate > 0)
                {
                    for (int i = 0; i < htUpdateFile.Count; i++)
                    {
                        string[] items = (string[])htUpdateFile[i];
                        list.Add(new FileList { Name = items[0], BanBenHao = items[1] });
                        this.listView1.ItemsSource = list;
                    }
                }
            }

        }


        public string JinDu
        {
            get { return (string)GetValue(JinDuProperty); }
            set { SetValue(JinDuProperty, value); }
        }

        // Using a DependencyProperty as the backing store for JinDu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JinDuProperty =
            DependencyProperty.Register("JinDu", typeof(string), typeof(MainWindow), new UIPropertyMetadata("0.00%"));

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.button1.IsEnabled == true)
            {
                System.Diagnostics.Process.Start("商品房预售资金监管银行端管理系统.exe");
                this.Close();
            }
        }

        /// <summary>
        /// 更新程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (availableUpdate > 0)
            {
                //Thread threadDown = new Thread(new ThreadStart(DownUpdateFile));
                //threadDown.IsBackground = true;
                //threadDown.Start();
                this.button2.IsEnabled = false;
                this.button3.IsEnabled = false;
                if (DownUpdateFile())
                {
                    File.Copy("CheckUpdateList.xml", "UpdateList.xml", true);
                    try
                    {
                        File.SetAttributes("CheckUpdateList.xml", FileAttributes.Normal);
                        File.Delete("CheckUpdateList.xml");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace.ToString());
                    }
                    lbState.Text = "更新完成";
                    this.button1.IsEnabled = true;
                    MessageBoxResult result = MessageBox.Show("程序更新完成,是否要启动程序？", "自动更新", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start("ERPSCD.ClientSide.exe");
                        Application.Current.Shutdown();
                    }
                }
            }
            else
            {
                MessageBox.Show("没有可用的更新!", "自动更新", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        /// <summary>
        /// 取消更新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("你确定要取消更新吗？", "系统提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// 检查更新文件
        /// </summary>
        /// <param name="serverXmlFile">从服务器下载的配置文件</param>
        /// <param name="localXmlFile">本地的配置文件</param>
        /// <param name="updateFileList">更新的文件列表</param>
        /// <returns></returns>
        public int CheckForUpdate(string serverXmlFile, string localXmlFile, out Hashtable updateFileList)
        {
            updateFileList = new Hashtable();
            if (!File.Exists(localXmlFile) || !File.Exists(serverXmlFile))
            {
                return -1;
            }

            XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
            XmlFiles localXmlFiles = new XmlFiles(localXmlFile);

            XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
            XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");
            //ArrayList oldFileAl = new ArrayList();
            //for (int j = 0; j < oldNodeList.Count; j++)
            //{
            //    string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
            //    string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();

            //    oldFileAl.Add(oldFileName);
            //    oldFileAl.Add(oldVer);

            //}
            Hashtable oldFileAl = new Hashtable();
            for (int j = 0; j < oldNodeList.Count; j++)
            {
                string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
                string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();

                oldFileAl.Add(oldFileName, oldVer);

            }
            int k = 0;
            for (int i = 0; i < newNodeList.Count; i++)
            {
                string[] fileList = new string[2];

                string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
                string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();

                //int pos = oldFileAl.IndexOf(newFileName);
                //if (pos == -1)
                //{
                //    fileList[0] = newFileName;
                //    fileList[1] = newVer;
                //    updateFileList.Add(k, fileList);
                //    k++;
                //}
                //else if (pos > -1 && newVer.CompareTo(oldFileAl[pos ].ToString()) < 0)
                //{
                //    fileList[0] = newFileName;
                //    fileList[1] = newVer;
                //    updateFileList.Add(k, fileList);
                //    k++;
                //}

                bool b = oldFileAl.Contains(newFileName);
                if (b == false)
                {
                    fileList[0] = newFileName;
                    fileList[1] = newVer;
                    updateFileList.Add(k, fileList);
                    k++;
                }
                else if (b == true && newVer.CompareTo(oldFileAl[newFileName].ToString()) > 0)
                {
                    fileList[0] = newFileName;
                    fileList[1] = newVer;
                    updateFileList.Add(k, fileList);
                    k++;
                }

            }
            return k;
        }

        private bool DownUpdateFile()
        {
            WebClient wcClient = new WebClient();
            for (int i = 0; i < this.list.Count; i++)
            {
                string UpdateFile = list[i].Name;
                string updateFileUrl = CommonData.Current.DownLoadAddress + UpdateFile;
                long fileLength = 0;

                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

                lbState.Text = "正在下载更新文件,请稍后...";
                pbDownFile.Value = 0;
                pbDownFile.Maximum = (int)fileLength;

                try
                {
                    Stream srm = webRes.GetResponseStream();
                    StreamReader srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;
                    while (fileLength > 0)
                    {
                        int downByte = srm.Read(bufferbyte, startByte, allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte;
                        pbDownFile.Value += downByte;
                        float part = (float)startByte / 1024;
                        float total = (float)bufferbyte.Length / 1024;
                        double percent = Convert.ToDouble((part / total) * 100);
                        JinDu = percent.ToString("#0.00") + "%";

                    }
                    string tempPath = UpdateFile.Substring(UpdateFile.LastIndexOf("/") + 1);
                    CreateDirtory(tempPath);
                    if (File.Exists(tempPath))
                    {
                        File.SetAttributes(tempPath, FileAttributes.Normal);
                    }
                    FileStream fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write);
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                    srm.Close();
                    srmReader.Close();
                    fs.Close();
                }
                catch (WebException ex)
                {
                    MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }
        //创建目录
        private void CreateDirtory(string path)
        {
            if (!File.Exists(path))
            {
                string[] dirArray = path.Split('\\');
                string temp = string.Empty;
                for (int i = 0; i < dirArray.Length - 1; i++)
                {
                    temp += dirArray[i].Trim() + "\\";
                    if (!Directory.Exists(temp))
                        Directory.CreateDirectory(temp);
                }
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
