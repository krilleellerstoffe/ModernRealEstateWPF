using Microsoft.Win32;
using ModernRealEstateBLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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

namespace ModernRealEstate
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private MainWindow _mainWindow;
        private Estate? _estate;
        private string? _imageSource;
        private ImageSource _defaultImage;
        public Estate Estate
        {
            get => _estate; set
            {
                _estate = value;
                UpdateDetails();
            }
        }
        public string? ImageSource { get => _imageSource; set => _imageSource = value; }

        public AddEditWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _defaultImage = imgBox.Source.Clone();
        }
        public AddEditWindow(Estate estate, MainWindow mainWindow) : this(mainWindow)
        {
            _estate = estate;
            UpdateDetails();
        }

        public void UpdateDetails()
        {
            //first clear current details
            lstDetails.Items.Clear();
            if (_estate != null)
            {
                string[] estateDetails = _estate.Details();
                foreach (string s in estateDetails)
                {
                    if (!string.IsNullOrEmpty(s)) lstDetails.Items.Add(s);
                }
                //retrieve pictures from estate object:
                if (_estate.ImageSource != null)
                {
                    _imageSource = _estate.ImageSource;
                    imgBox.Source = new BitmapImage(new Uri(_estate.ImageSource));
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //confirm data not saved on close

            //close this window and return to main menu
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //confirm delete
            MessageBox.Show("Are you sure? All fields will be reset", "Confirm reset", MessageBoxButton.OK);
            lstDetails.Items.Clear();
            RemovePicture();
            //clear all fields
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //open new dialog to edit details, include estate object if exists

            DetailsWindow detailsWindow = (_estate == null) ? new DetailsWindow(this): new DetailsWindow(this, _estate);
            detailsWindow.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {            
            if (_estate != null)
            {
                _estate.ImageSource = _imageSource;
                
                _mainWindow.AddEstate(_estate);
                this.Close();
                return;
            }
            if (MessageBox.Show("No details saved, return to Main Menu?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void btnAddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png"
            };
            if (ofd.ShowDialog() == true)
            {
                AddPicture(ofd.FileName);
            }
        }
        private void btnAddURLPicture_Click(object sender, RoutedEventArgs e)
        {
            //get URL and check is valid
            SimpleInputWindow inputWindow = new SimpleInputWindow(this);
            inputWindow.ShowDialog();
            //add picture from URL
        }
        public bool AddPicture(string filename)
        {
            //display picture
            try
            {
                imgBox.Source = new BitmapImage(new Uri(filename));
                _imageSource = filename;
                return true;
            }          
            catch (Exception ex)
            {
                // Handle any download exceptions
                Console.WriteLine("Error downloading image: " + ex.Message);
                MessageBox.Show("Error fetching image, please check URL is valid", "Error", MessageBoxButton.OK);
                return false;
            }
        }

        private void btnRemovePicture_Click(object sender, RoutedEventArgs e)
        {
            RemovePicture();
        }
        private void RemovePicture()
        {
            _imageSource = null;
            imgBox.Source = _defaultImage;
        }
    }
}
