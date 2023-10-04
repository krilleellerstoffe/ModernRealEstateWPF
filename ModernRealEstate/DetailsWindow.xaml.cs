using ModernRealEstateBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
        private AddEditWindow _parentWindow;
        private Seller? _seller;
        private Buyer? _buyer;

        public Seller? Seller { get => _seller; set => _seller = value; }
        public Buyer? Buyer { get => _buyer; set => _buyer = value; }
        public AddEditWindow ParentWindow { get => _parentWindow; set => _parentWindow = value; }

        public DetailsWindow(AddEditWindow parent)
        {
            _parentWindow = parent;
            InitializeComponent();
            SetupComboBoxes();
        }

        private void SetupComboBoxes()
        {
            cBoxCountries.ItemsSource = Enum.GetValues(typeof(Countries));
            cBoxType.ItemsSource = Enum.GetValues(typeof(EstateTypes));
            cBoxOwnership.ItemsSource = Enum.GetValues(typeof(Ownership));
            for(int i = 1; i < 10; i++)
            {
                cBoxRooms.Items.Add(i.ToString());

            }
            cBoxRooms.Items.Add("10+");
        }

        private void btnSeller_Click(object sender, RoutedEventArgs e)
        {
            BuyerSellerWindow window = new BuyerSellerWindow(Buyer != null ? Buyer: new Buyer());
            window.Show();
        }
        private void btnBuyer_Click(object sender, RoutedEventArgs e)
        {
            BuyerSellerWindow window = new BuyerSellerWindow(Seller != null ? Seller : new Seller());
            window.Show();
        }

        private void cBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cBoxType.SelectedItem) 
            {
                case EstateTypes.Apartment:
                case EstateTypes.Townhouse:
                case EstateTypes.Villa:
                    ResidentialControlsVisibility(Visibility.Visible);
                    break;
                default:
                    ResidentialControlsVisibility(Visibility.Collapsed);
                    break;
            }
        }
        private void ResidentialControlsVisibility(Visibility visibility)
        {
            lblOwnership.Visibility = visibility;
            cBoxOwnership.Visibility = visibility;
            lblRooms.Visibility = visibility;
            cBoxRooms.Visibility = visibility;
        }
    }
}
