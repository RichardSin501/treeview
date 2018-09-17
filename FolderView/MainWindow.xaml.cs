using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FolderView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            LoadSubFolders(sender);
        }

        private static void LoadSubFolders(object sender)
        {
            var twi = (TreeViewItem)sender;
            var folder = (Folder)twi.Tag;
            folder.LoadSubFolders();
        }

        private void treeView_Initialized(object sender, EventArgs e)
        {
            LoadSubFolders(sender);
        }

        private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LoadSubFolders(sender);
        }

        private void TreeViewItem_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LoadSubFolders(sender);
        }
    }
}