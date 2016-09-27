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
using Srv = BaseClient.BaseManageSrv;
using System.Xml;
using System.Reflection;
using AvalonDock;
using System.IO;
using FinancialRegulation;
using lgsv=BaseClient.LoginSrv;
using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Commands;


namespace MainFrame
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Action<lgsv.MenuItem> MenuDoubleClickAction;

        public lgsv.UserInfo ui  { get; set; }
       
        public MainWindow()
        {
            InitializeComponent();

            CloseTabCommand = new SimpleCommand();
            CloseTabCommand.ExecuteDelegate = CloseTabExecute;
            CloseTabCommand.CanExecuteDelegate = (obj) =>
            {
                return true ;
            };
            MenuDoubleClickAction = new Action<lgsv.MenuItem>(MenuDoubleClick);
            try
            {
                ui = (lgsv.UserInfo)Common.CommonData.GetInstance().ListCheckUesrInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        private void MenuDoubleClick(lgsv.MenuItem mi)
        {
            if (null == mi) return;
            if (null != mi.InvokingConfig && "" != mi.InvokingConfig)
            {
                ShowWindow(mi);
            }
        }

        private void ShowWindow(lgsv.MenuItem mi)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(mi.InvokingConfig);
            XmlNodeList xlist = xdoc.GetElementsByTagName("DSPUSERCONTROL");
            string dllPath = "";
            string dllName = "";

            try
            {
                //if (!IsOpenTab(xlist.Item(0).ChildNodes[1].InnerText))
                {
                    dllPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    dllName = xlist.Item(0).ChildNodes[0].InnerText;
                    dllPath = System.IO.Path.Combine(dllPath, dllName + ".dll");
                    Assembly ass = Assembly.LoadFrom(dllPath);
                    Type t = ass.GetType(xlist.Item(0).ChildNodes[1].InnerText);

                    foreach (MetroTabItem obj in this.tblMainRegion.Items)
                    {

                        if (obj.Content!=null&&obj.Content.GetType() == t)
                        {
                            obj.IsSelected = true;
                            return;
                        }
                    }
                    ConstructorInfo constructors = null;
                    Type[] ts = null;
                    object[] parms = null;
                    if (xlist.Item(0).ChildNodes[2].InnerText == "")
                    {
                        ts = new Type[] { };
                        parms = new object[] { };
                    }
                    else
                    {
                        string[] parmlist = xlist.Item(0).ChildNodes[2].InnerText.Split(new char[] { ',' });
                        ts = new Type[parmlist.Length];
                        parms = new object[parmlist.Length];
                        for (int i = 0; i < parmlist.Length; i++)
                        {
                            ts[i] = Type.GetType(parmlist[i].Split(new char[] { ':' })[1]);
                            parms[i] = Convert.ChangeType(parmlist[i].Split(new char[] { ':' })[2], ts[i]);
                        }
                    }
                    constructors = t.GetConstructor(ts);
                    MetroContentControl f = constructors.Invoke(parms) as MetroContentControl;
                    if (f !=null)
                    {
                        MetroTabItem tabitem = new MetroTabItem();
                        tabitem.Header = mi.Name;
                        tabitem.Content = f;
                        
                        tabitem.CloseTabCommand = CloseTabCommand;
            
                        if (!this.tblMainRegion.Items.Contains(tabitem))
                        {
                            this.tblMainRegion.Items.Add(tabitem);
                        }
                        tabitem.IsSelected = true;
                    }
                   
                    
                }
            }
            catch (FileNotFoundException fe)
            {
                MessageBox.Show("未找到" + dllPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private SimpleCommand CloseTabCommand;
        private void CloseTabExecute(object  tabitem)
        {
            MetroTabItem item = tabitem as MetroTabItem;
            if (item == null) { return; }
            if (this.tblMainRegion.Items!=null &&this.tblMainRegion.Items.Contains(tabitem))
            {
                this.tblMainRegion.Items.Remove(tabitem);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            menuWindow.menuitem = ui.menuitem.ToList<lgsv.MenuItem>();
            menuWindow.MenuItemDoubleClick = MenuDoubleClickAction;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    public class SimpleCommand : ICommand
    {
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
                return CanExecuteDelegate(parameter);
            return true; // if there is no can execute default to true
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
                ExecuteDelegate(parameter);
        }
    }
}
