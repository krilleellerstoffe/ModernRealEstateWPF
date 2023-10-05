using ModernRealEstateBLL;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        private Estate? _currentEstateObject;
        private Estate? _newEstateObject;
        private bool[] requiredInputs = new bool[4];

        public Seller? Seller
        {
            get => _seller;
            set
            {
                _seller = value;
                txtBlSeller.Text = ((Seller)value).ToString();
            }
        }

        public Buyer? Buyer
        {
            get => _buyer;
            set
            {
                _buyer = value;
                txtBlBuyer.Text = ((Buyer)value).ToString();
            }
        }
        public AddEditWindow ParentWindow { get => _parentWindow; set => _parentWindow = value; }

        public DetailsWindow(AddEditWindow parent)
        {
            _parentWindow = parent;
            InitializeComponent();
            SetupComboBoxes();
            if (parent.ImageSource != null)
            {
                imgBox.Source = new BitmapImage(new Uri(_parentWindow.ImageSource));
            }
        }

        public DetailsWindow(AddEditWindow parent, Estate estate) : this(parent)
        {
            this._currentEstateObject = estate;

            //populate address info
            txtLine1.Text = estate.Address.Line1;
            txtLine2.Text = estate.Address.Line2;
            txtCity.Text = estate.Address.City;
            txtPostcode.Text = estate.Address.Postcode;
            cBoxCountries.SelectedItem = (Countries)estate.Address.Country;

            //populate object characteristics
            cBoxType.SelectedItem = estate.EstateType;
            txtSize.Text = estate.Size.ToString();
            if (estate is Residential)
            {
                cBoxOwnership.SelectedItem = ((Residential)_currentEstateObject).Ownership;
                cBoxRooms.SelectedItem = ((Residential)_currentEstateObject).Rooms;
            }
            if (estate.Buyer != null) Buyer = estate.Buyer;
            if (estate.Seller != null) Seller = estate.Seller;
        }

        private void SetupComboBoxes()
        {
            cBoxCountries.ItemsSource = Enum.GetValues(typeof(Countries));
            cBoxType.ItemsSource = Enum.GetValues(typeof(EstateTypes));
            cBoxOwnership.ItemsSource = Enum.GetValues(typeof(Ownership));
            for (int i = 1; i < 10; i++)
            {
                cBoxRooms.Items.Add(i.ToString());
            }
            cBoxRooms.Items.Add("10+");
        }

        private void btnSeller_Click(object sender, RoutedEventArgs e)
        {
            BuyerSellerWindow window = new BuyerSellerWindow(this, Seller != null ? Seller : new Seller());
            window.Show();
        }
        private void btnBuyer_Click(object sender, RoutedEventArgs e)
        {
            BuyerSellerWindow window = new BuyerSellerWindow(this, Buyer != null ? Buyer : new Buyer());
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //confirm close
            this.Close();
        }
        //check that all required fields are filled in
        private bool checkRequiredInputs()
        {
            txtLine1_TextChanged(null, null);
            txtCity_TextChanged(null, null);
            txtPostcode_TextChanged(null, null);
            txtSize_TextChanged(null, null);
            foreach (bool item in requiredInputs)
            {
                if (!item) return false;
            }
            return true;
        }
        //highlight label red if invalid input
        private void txtLine1_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtLine1.Text != String.Empty;
            requiredInputs[0] = valid;
            lblLine1.Foreground = valid ? Brushes.Black : Brushes.Red;
        }
        //highlight label red if invalid input
        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtCity.Text != String.Empty;
            requiredInputs[1] = valid;
            lblCity.Foreground = valid ? Brushes.Black : Brushes.Red;
        }
        //highlight label red if invalid input
        private void txtPostcode_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtPostcode.Text != String.Empty;
            requiredInputs[2] = valid;
            lblPost.Foreground = valid ? Brushes.Black : Brushes.Red;
        }
        //highlight label red if invalid input
        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            int ignored;
            bool isInteger = int.TryParse(txtSize.Text, out ignored);
            txtSize.Foreground = isInteger ? Brushes.Black : Brushes.Red;
            lblSize.Foreground = isInteger ? Brushes.Black : Brushes.Red;
            requiredInputs[3] = isInteger;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //first check if required fields are valid
            if (!checkRequiredInputs())
            {
                return;
            }
            try
            {
                CreateObjectFromDetails();
                updateBuyerSeller();
                _parentWindow.Estate = _newEstateObject;
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void CreateObjectFromDetails()
        {
            switch (cBoxType.SelectedItem)
            {
                //residential objects have an ownership type and rooms
                case EstateTypes.Villa:
                    _newEstateObject = new Villa();
                    break;
                case EstateTypes.Townhouse:
                    _newEstateObject = new Townhouse();
                    break;
                case EstateTypes.Apartment:
                    _newEstateObject = new Apartment();
                    break;
                //all other objects just need a size and an address
                case EstateTypes.Hospital:
                    _newEstateObject = new Hospital();
                    break;
                case EstateTypes.School:
                    _newEstateObject = new School();
                    break;
                case EstateTypes.University:
                    _newEstateObject = new University();
                    break;
                case EstateTypes.Shop:
                    _newEstateObject = new Shop();
                    break;
                case EstateTypes.Warehouse:
                default:
                    _newEstateObject = new Warehouse();
                    break;
            }
            //set address and size regardless of estate type
            _newEstateObject.Address = CreateAddress();
            _newEstateObject.Size = int.Parse(txtSize.Text);
            //add ownership type and room count if residential
            if (_newEstateObject is Residential)
            {
                ((Residential)_newEstateObject).Ownership = (Ownership)cBoxOwnership.SelectedItem;
                ((Residential)_newEstateObject).Rooms = (string)cBoxRooms.SelectedItem;
            }
            //keep old ID if updating details on existing estate object
            if (_currentEstateObject != null)
            {
                _newEstateObject.ID = _currentEstateObject.ID;
            }
        }
        //creates an address object from the user's inputs
        private Address CreateAddress()
        {
            return new Address(
                txtLine1.Text,
                txtLine2.Text,
                txtCity.Text,
                txtPostcode.Text,
                (Countries)cBoxCountries.SelectedItem);
        }

        //if buyer/seller exist, put them in the estate object
        private void updateBuyerSeller()
        {
            if (_buyer != null)
            {
                _newEstateObject.Buyer = _buyer;
            }
            if (_seller != null)
            {
                _newEstateObject.Seller = _seller;
            }
        }
    }
}
