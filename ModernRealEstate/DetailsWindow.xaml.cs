using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ModernRealEstate
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private AddEditWindow? _parentWindow;
        public DetailsWindow()
        {
            InitializeComponent();
        }
        public DetailsWindow(AddEditWindow parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
        }

        private void btnBuyerSeller_Click(object sender, RoutedEventArgs e)
        {
            BuyerSellerWindow window = new BuyerSellerWindow();
            window.Show();
        }
    }
}
