using System.Windows;
using System.Windows.Controls;

namespace ModernRealEstate
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //open add/edit window
            MessageBox.Show(sender.ToString());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //confirm close
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //confirm delete
            updateList();
        }

        private void chBox_Click(object sender, RoutedEventArgs e)
        {
            updateList();
        }
        private void updateList()
        {
            //get new list from BLL
            //send filter values
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
