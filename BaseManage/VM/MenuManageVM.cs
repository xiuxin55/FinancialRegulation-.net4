using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Srv=BaseClient.BaseManageSrv;
using Microsoft.Practices.Prism.ViewModel;
using System.Collections.ObjectModel;
using BaseClient;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace BaseManage
{
    public class MenuManageVM : NotificationObject
    {
        private MenuItem currentMenu;

        public MenuItem CurrentMenu
        {   
            get { return currentMenu; }
            set
            {
                currentMenu = value;
                this.RaisePropertyChanged("CurrentMenu");
            }
        }
    

        private TreeNodeModel currentNode;

        public TreeNodeModel CurrentNode
        {
            get { return currentNode; }
            set
            {
                currentNode = value;
                this.RaisePropertyChanged("CurrentNode");
            }
        }

        private string selectedid;

        public string SelectedID
        {
            get { return selectedid; }
            set
            {
                selectedid = value;
                this.RaisePropertyChanged("SelectedID");
            }
        }

        private string assemblyInfo;

        public string AssemblyInfo
        {
            get { return assemblyInfo; }
            set
            {
                assemblyInfo = value;
                this.RaisePropertyChanged("AssemblyInfo");
            }
        }

        private ObservableCollection<Srv.MenuItem> menus;

        public ObservableCollection<Srv.MenuItem> Menus
        {
            get { return menus; }
            set
            {
                menus = value;
                this.RaisePropertyChanged("Menus");
            }
        }

        private ObservableCollection<TreeNodeModel> treeNodes;

        public ObservableCollection<TreeNodeModel> TreeNodes
        {
            get { return treeNodes; }
            set
            {
                treeNodes = value;
                this.RaisePropertyChanged("TreeNodes");
            }
        }

        private ObservableCollection<ConstructorInfo> constructors;

        public ObservableCollection<ConstructorInfo> Constructors
        {
            get { return constructors; }
            set
            {
                constructors = value;
                this.RaisePropertyChanged("Constructors");
            }
        }

        private ConstructorInfo selectedConstructor;

        public ConstructorInfo SelectedConstructor
        {
            get { return selectedConstructor; }
            set
            {
                selectedConstructor = value;
                this.RaisePropertyChanged("SelectedConstructor");
            }
        }

        private ObservableCollection<ParameterItemModel> parameterItems;

        public ObservableCollection<ParameterItemModel> ParameterItems
        {
            get { return parameterItems; }
            set
            {
                parameterItems = value;
                this.RaisePropertyChanged("ParameterItems");
            }
        }

        private List<Srv.MenuItem> menulist;

        public List<Srv.MenuItem> MenuList
        {
            get { return menulist; }
            set
            {
                menulist = value;
                this.RaisePropertyChanged("MenuList");
            }
        }

        public bool EditState;

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand AddSubCommand { get; set; }
        public DelegateCommand DelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancleCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public DelegateCommand SerchAssemblyCommand { get; set; }
        public DelegateCommand SelectedConstructorCommand { get; set; }

        public MenuManageVM()
        {
            AddCommand = new DelegateCommand(new Action(AddMenu));
            AddSubCommand = new DelegateCommand(new Action(AddSubmenu));
            DelCommand = new DelegateCommand(new Action(DeletMenu));
            SaveCommand = new DelegateCommand(new Action(SaveMenu));
            CancleCommand = new DelegateCommand(new Action(CancleMenu));
            SelectionChangedCommand = new DelegateCommand<object>(SelectionChanged);
            SerchAssemblyCommand = new DelegateCommand(SerchAssembly);
            SelectedConstructorCommand = new DelegateCommand(SelectedConstructorChanged);
            //currentMenu = new MenuItem();
            DataRefresh();
            Constructors = new ObservableCollection<ConstructorInfo>();
            ParameterItems = new ObservableCollection<ParameterItemModel>();
            EditState = false;
            //Menus.Concat(menulist.AsEnumerable<MenuItem>());
        }

        private ObservableCollection<TreeNodeModel> GetTreeNodes(List<Srv.MenuItem> mlist)
        {
            ObservableCollection<TreeNodeModel> tnoc = new ObservableCollection<TreeNodeModel>();
            TreeNodeModel tnm = null;
            foreach (Srv.MenuItem mi in mlist.Where(p => p.Layer == 1))
            {
                tnm=new TreeNodeModel() { Item = mi };
                ObservableCollection<TreeNodeModel> tnoc2 = new ObservableCollection<TreeNodeModel>();
                TreeNodeModel tnm2 = null;
                foreach (Srv.MenuItem mi2 in mlist.Where(p => p.Parent == mi.ID && p.Layer == 2))
                {
                    tnm2 = new TreeNodeModel() { Item = mi2, ParentNode=tnm};
                    ObservableCollection<TreeNodeModel> tnoc3 = new ObservableCollection<TreeNodeModel>();
                    foreach (Srv.MenuItem mi3 in mlist.Where(p => p.Parent == mi2.ID && p.Layer == 3))
                    {
                        tnoc3.Add(new TreeNodeModel() { Item = mi3 ,ParentNode=tnm2});
                    }
                    tnm2.Children = tnoc3;
                    tnoc2.Add(tnm2);
                }
                tnm.Children = tnoc2;
                tnoc.Add(tnm);
            }

            return tnoc;
        }

        public static string XMLDocumentToString(ref   XmlDocument doc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);

            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();

            return xmlString;
        }

        private XmlDocument CreateXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //建立Xml的定义声明
            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(dec);
            //创建根节点
            XmlElement root = xmlDoc.CreateElement("DSFUNNODECONFIG");
            xmlDoc.AppendChild(root);
            XmlNode type = xmlDoc.CreateElement("TYPE");
            type.InnerText = "WINDOW";
            XmlElement control = xmlDoc.CreateElement("DSPUSERCONTROL");

            XmlElement fassembly = xmlDoc.CreateElement("ASSEMBLY");
            XmlElement fclass = xmlDoc.CreateElement("CLASS");
            XmlElement fparalist = xmlDoc.CreateElement("PARALIST");

            if (currentNode.Item.AssemblyName != null)
            {
                fassembly.InnerText = currentNode.Item.AssemblyName.Split(',')[0];
                fclass.InnerText = currentNode.Item.WindowName;
                string paralistStr = "";
                foreach (ParameterItemModel pim in parameterItems)
                {
                    paralistStr += "," +pim.DataName+":"+ pim.DataType + ":" + pim.DataValue;
                }
                if (paralistStr.Length > 0)
                {
                    fparalist.InnerText = paralistStr.Remove(0, 1);
                }
                control.AppendChild(fassembly);
                control.AppendChild(fclass);
                control.AppendChild(fparalist);
            }

            root.AppendChild(type);
            root.AppendChild(control);

            return xmlDoc;
        }

        private void DataRefresh()
        {
            //Menus.Clear();
            MenuList = MenuClient.Current.GetMenuItems();
            TreeNodes = GetTreeNodes(menulist);
        }
        private void AddMenu()
        {
            EditState = true;
        }
        private void AddSubmenu()
        {
            EditState = true;
            Srv.MenuItem mi = null;

            if (CurrentNode == null)
            {
                mi = new Srv.MenuItem() { ID = Guid.NewGuid().ToString(), Name = "新增菜单", Layer = 1, Ordinal = TreeNodes.Count+1 };
                TreeNodes.Add(new TreeNodeModel() { Item = mi, Children = new ObservableCollection<TreeNodeModel>() });
            }
            else
            {
                if (CurrentNode.Children != null)
                {
                    mi = new Srv.MenuItem() { ID = Guid.NewGuid().ToString(), Parent = CurrentNode.Item.ID, Name = "新增菜单", Layer = CurrentNode.Item.Layer+1, Ordinal = CurrentNode.Children.Count };
                    CurrentNode.Children.Add(new TreeNodeModel() { Item = mi, Children = new ObservableCollection<TreeNodeModel>(), ParentNode = CurrentNode, });
                    CurrentNode.IsExpanded = true;
                }
                else
                {
                }
            }
        }
        private void DeletMenu()
        {
            string mesg = null;
            if (MenuClient.Current.DeleteMenuItem(CurrentNode.Item, out mesg))
            {
                MessageBox.Show("删除成功");
                DataRefresh();
            }
        }
        private void SaveMenu()
        {
            string mesg = null;
            if (CurrentNode.Item.IsDetail == "1")
            {
                XmlDocument xdmt = CreateXml();
                CurrentNode.Item.InvokingConfig = XMLDocumentToString(ref xdmt);
            }
            if (MenuClient.Current.AddMenuItem(CurrentNode.Item, out mesg))
            {
                MessageBox.Show("保存成功");
                DataRefresh();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
            EditState = false;
        }
        private void CancleMenu()
        {
        }
        private void SelectionChanged(object obj )
        {
            if(obj==null) return;
            string s = selectedid;
            //CurrentMenu = obj as MenuItem;

            CurrentNode = obj as TreeNodeModel;
            if (CurrentNode == null) return;
            Constructors.Clear();
            ParameterItems.Clear();

            if (!string.IsNullOrEmpty(CurrentNode.Item.InvokingConfig))
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(CurrentNode.Item.InvokingConfig);
                XmlNodeList xlist = xdoc.GetElementsByTagName("DSPUSERCONTROL");

                string[] strs = xlist.Item(0).ChildNodes[2].InnerText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                ParameterItems.Clear();
                foreach (string str in strs)
                {
                    string[] tstr = str.Split(new char[]{':'});
                    ParameterItems.Add(new ParameterItemModel() { DataName=tstr[0], DataType = tstr[1], DataValue=tstr[2] });
                }
            }
        }
        private void SerchAssembly()
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            ofd.DefaultExt = ".dll";

            ofd.Filter = "程序集文件(*.dll)|*.dll"; ;

            if (ofd.ShowDialog() == true)
            {
                Assembly asby = Assembly.LoadFrom(ofd.FileName);
                AssemblyInfoForm aif = new AssemblyInfoForm();
                aif.AssemblyInfo = asby;
                if (aif.ShowDialog() == DialogResult.OK)
                {
                    CurrentNode.Item.AssemblyName = aif.AssemblyName;
                    CurrentNode.Item.WindowName = aif.FormName;
                    CurrentNode = currentNode;
                    Constructors = new ObservableCollection<ConstructorInfo>(asby.GetType(aif.FormName).GetConstructors());
                    //CurrentNode.Item.a
                    //this.txtAssembly.Text = aif.AssemblyName;
                    //this.txtForm.Text = aif.FormName;
                    //cis = asby.GetType(aif.FormName).GetConstructors();
                    //cboConstructors.DataSource = cis;
                }

            }
        }
        private void SelectedConstructorChanged()
        {
            if (selectedConstructor == null) return;
            ParameterInfo[] parameters = selectedConstructor.GetParameters();
            ParameterItems.Clear();
            foreach (ParameterInfo pif in parameters)
            {
                ParameterItems.Add(new ParameterItemModel() { DataName = pif.Name, DataType = pif.ParameterType.FullName });
            }
        }
    }
}
