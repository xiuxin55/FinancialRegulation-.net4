using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Collections;

namespace FinancialRegulation.Tools
{

    class RowNumberPresenter:ContentControl
    {
        public ItemCollection Items
        {
            get { return (ItemCollection)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        #region 系统自动生成

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ItemCollection), typeof(RowNumberPresenter), new UIPropertyMetadata(null, Items_Changed));

        private static void Items_Changed(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            (s as RowNumberPresenter).RefreshContent();
        }

        public Object Item
        {
            get { return (Object)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Item.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(Object), typeof(RowNumberPresenter), new UIPropertyMetadata(null, Item_Changed));

        private static void Item_Changed(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            (s as RowNumberPresenter).RefreshContent();
        }

        #endregion

        #region 非公有方法声明

        private void RefreshContent()
        {
            var Txt = Items != null ? (Items.IndexOf(Item) + 1) + "" : "";
            this.Content = Txt;
        }

        #endregion
    }
}
