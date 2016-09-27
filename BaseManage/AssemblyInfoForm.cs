using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
namespace BaseManage
{
    public partial class AssemblyInfoForm : Form
    {
        public AssemblyInfoForm()
        {
            InitializeComponent();
        }

        private Assembly assembly;

        public Assembly AssemblyInfo
        {
            get { return assembly; }
            set { assembly = value; }
        }

        private string assemblyName;

        public string AssemblyName
        {
            get { return assemblyName; }
            set { assemblyName = value; }
        }

        private string formName;

        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }

        private Type tagetType;

        public Type TagetType
        {
            get { return tagetType; }
            set { tagetType = value; }
        }

        private void AssemblyInfoForm_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = new TreeNode(assembly.FullName);
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                TreeNode newnode = new TreeNode(t.FullName);
                newnode.Tag = t;
                rootNode.Nodes.Add(newnode);
            }
            treeAssembly.Nodes.Add(rootNode);
            treeAssembly.ExpandAll();
            treeAssembly.Sort();
        }

        private void treeAssembly_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode t = e.Node;
            if (t.Parent != null)
            {
                this.assemblyName = assembly.FullName;
                this.formName = t.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
