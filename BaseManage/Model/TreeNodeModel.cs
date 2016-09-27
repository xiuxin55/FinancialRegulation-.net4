using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using BaseClient.BaseManageSrv;

namespace BaseManage
{
    public class TreeNodeModel : NotificationObject
    {
        private bool isExpanded;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                this.RaisePropertyChanged("IsExpanded");
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

        private MenuItem item;

        public MenuItem Item
        {
            get { return item; }
            set
            {
                item = value;
                this.RaisePropertyChanged("Item");
            }
        }

        private TreeNodeModel parentNode;

        public TreeNodeModel ParentNode
        {
            get { return parentNode; }
            set
            {
                parentNode = value;
                this.RaisePropertyChanged("ParentNode");
            }
        }

        

        private ObservableCollection<TreeNodeModel> childre;

        public ObservableCollection<TreeNodeModel> Children
        {
            get { return childre; }
            set
            {
                childre = value;
                this.RaisePropertyChanged("Children");
            }
        }
         
    }
}
