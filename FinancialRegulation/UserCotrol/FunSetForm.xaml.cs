using FundsRegulatoryClient;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialRegulation.UserCotrol
{
    /// <summary>
    /// FunSetForm.xaml 的交互逻辑
    /// </summary>
    public partial class FunSetForm : MetroWindow
    {
        public FunSetForm()
        {
            InitializeComponent();
        }
        public FunSetForm(string dutyid) : this()
        {
            this.dutyid = dutyid;
        }

        private string dutyid;

        public string Dutyid
        {
            get { return dutyid; }
            set { dutyid = value; }
        }

        private DataSet ds;

        private void FunSetForm_Load(object sender, RoutedEventArgs e)
        {
            ds = FunClient.Current.GetDutyFun(dutyid);
            initTree(this.treeNotSet, ds.Tables[1]);
            initTree(this.treeSet, ds.Tables[0]);
            this.btnAdd.Focus();
        }

        private void initTree(TreeView tree, DataTable fun)
        {
            foreach (DataRow modedr in fun.Select("Layer='1'"))
            {
                TreeNode modenode = new TreeNode(modedr["Name"].ToString());
                modenode.Name = modedr["MENUID"].ToString();
                modenode.Tag = modedr;
                foreach (DataRow modeexdr in fun.Select(string.Format("Layer='2' and Code like '{0}%'", modedr["Code"])))
                {
                    TreeNode modeexnode = new TreeNode(modeexdr["Name"].ToString());
                    modeexnode.Name = modeexdr["MENUID"].ToString();
                    modeexnode.Tag = modeexdr;

                    foreach (DataRow fundr in fun.Select(string.Format("Layer='3' and Code like '{0}%'", modeexdr["Code"])))
                    {
                        TreeNode funnode = new TreeNode(fundr["Name"].ToString());
                        funnode.Name = fundr["MENUID"].ToString();
                        funnode.Tag = fundr;
                        modeexnode.Nodes.Add(funnode);
                    }
                    if (modeexnode.Nodes.Count > 0)
                    {
                        modenode.Nodes.Add(modeexnode);
                    }
                }
                if (modenode.Nodes.Count > 0)
                {
                    tree.Nodes.Add(modenode);
                }
            }
            tree.ExpandAll();
        }

        private void treeNotSet_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetNodeChecked(e.Node, e.Node.Checked);
            }
        }

        private void treeSet_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetNodeChecked(e.Node, e.Node.Checked);
            }
        }
        private void SetNodeChecked(TreeNode tn, bool Checked)
        {
            if (tn == null) return;
            // 设置子节点状态
            tn.Checked = Checked;
            foreach (TreeNode tnChild in tn.Nodes)
            {
                SetNodeChecked(tnChild, Checked);
                tnChild.Checked = Checked;
            }
            // 设置父节点状态

            TreeNode tnParent = tn;
            int nNodeCount = 0;

            while (tnParent.Parent != null)
            {
                tnParent = (TreeNode)(tnParent.Parent);
                nNodeCount = 0;
                foreach (TreeNode tnTemp in tnParent.Nodes)
                {
                    if (tnTemp.Checked == Checked)
                    {
                        nNodeCount++;
                    }
                }

                if (nNodeCount == tnParent.Nodes.Count)
                {
                    tnParent.Checked = Checked;
                }
                else
                {
                    tnParent.Checked = false;
                }
            }
        }

        private void btnAddAll_Click(object sender, RoutedEventArgs e)
        {
            //Array dset = Array.CreateInstance(Type.GetType("System.Windows.Forms.TreeNode"), treeNotSet.Nodes.Count);
            //TreeNode[] dset = new TreeNode[treeNotSet.Nodes.Count];
            //treeNotSet.Nodes.CopyTo(dset, 0);
            //treeNotSet.Nodes.Clear();
            //treeSet.Nodes.AddRange(dset);
            nodesMarge(this.treeNotSet.Nodes, this.treeSet.Nodes);
            this.treeNotSet.Nodes.Clear();
            this.treeSet.ExpandAll();
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            //TreeNode[] dset = new TreeNode[treeSet.Nodes.Count];
            //treeSet.Nodes.CopyTo(dset, 0);
            //treeSet.Nodes.Clear();
            //treeNotSet.Nodes.AddRange(dset);
            nodesMarge(this.treeSet.Nodes, this.treeNotSet.Nodes);
            this.treeSet.Nodes.Clear();
            this.treeNotSet.ExpandAll();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CopyNodes(this.treeNotSet, this.treeSet);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CopyNodes(this.treeSet, this.treeNotSet);
        }

        private void CopyNodes(TreeView sur, TreeView obj)
        {

            List<TreeNode> tns = new List<TreeNode>();
            for (int i = sur.Nodes.Count - 1; i >= 0; i--)
            {
                TreeNode tncopy = sur.Nodes[i].Clone() as TreeNode;

                deleteNotChecked(tncopy);
                deleteChecked(sur.Nodes[i]);
                if (tncopy.Nodes.Count > 0)
                {
                    tns.Add(tncopy);
                }
                else
                {
                    tncopy.Remove();
                }
            }

            //obj.Nodes.AddRange(tns.ToArray());
            foreach (TreeNode tn in tns)
            {
                if (obj.Nodes.ContainsKey(tn.Name))
                {
                    nodesMarge(tn.Nodes, obj.Nodes[tn.Name].Nodes);
                }
                else
                {
                    tn.Checked = false;
                    obj.Nodes.Add(tn.Clone() as TreeNode);
                }

            }
            obj.ExpandAll();

        }

        private void deleteNotChecked(TreeNode tn)
        {
            for (int i = tn.Nodes.Count - 1; i >= 0; i--)
            {
                if (!tn.Nodes[i].Checked)
                {
                    if (tn.Nodes[i].Nodes.Count > 0)
                    {
                        deleteNotChecked(tn.Nodes[i]);
                        if (tn.Nodes[i].Nodes.Count == 0)
                        {
                            tn.Nodes[i].Remove();
                        }
                    }
                    else
                    {
                        tn.Nodes[i].Remove();
                    }
                }
                else
                {
                    if (tn.Nodes[i].Nodes.Count == 0)
                    {
                        tn.Nodes[i].Checked = false;
                    }
                }
            }
        }

        private void deleteChecked(TreeNode tn)
        {
            for (int i = tn.Nodes.Count - 1; i >= 0; i--)
            {
                if (tn.Nodes[i].Checked)
                {
                    tn.Nodes[i].Remove();
                }
                else
                {
                    if (tn.Nodes[i].Nodes.Count > 0)
                    {
                        deleteChecked(tn.Nodes[i]);
                    }
                }

            }

            if (tn.Nodes.Count == 0)
            {
                tn.Remove();
            }
        }

        private void nodesMarge(TreeNodeCollection sur, TreeNodeCollection obj)
        {
            foreach (TreeNode tn in sur)
            {
                if (obj.ContainsKey(tn.Name))
                {
                    nodesMarge(tn.Nodes, obj[tn.Name].Nodes);
                }
                else
                {
                    //tn.Checked = false;
                    obj.Add(tn.Clone() as TreeNode);
                }
            }
        }

        private void getfunID(TreeNodeCollection tnc, ref List<string> idlist)
        {
            foreach (TreeNode tn in tnc)
            {
                DataRow dr = tn.Tag as DataRow;
                idlist.Add((string)dr["MENUID"]);
                if (tn.Nodes.Count > 0)
                {
                    getfunID(tn.Nodes, ref idlist);
                }
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            List<string> idlist = new List<string>();
            getfunID(this.treeSet.Nodes, ref idlist);
            if (FundsRegulatoryClient.FunClient.Current.SetFun(this.dutyid, idlist.ToArray()))
            {
                System.Windows.Forms.MessageBox.Show("授权成功！");
                this.DialogResult = true ;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("授权失败！");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

       
    }
}
