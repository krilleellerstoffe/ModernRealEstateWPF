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
using System.Windows.Shapes;

namespace ModernRealEstate
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private MainWindow _mainWindow;
        private Estate _estate;
        private string? _imageSource;
        public Estate Estate { get => _estate; set => _estate = value; }
        public string? ImageSource { get => _imageSource; set => _imageSource = value; }

        public AddEditWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
        public AddEditWindow(Estate estate, MainWindow mainWindow) : this(mainWindow)
        {
            _estate = estate;
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

            //clear all fields
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //open new dialog to edit details
            DetailsWindow detailsWindow = new DetailsWindow(this);
            detailsWindow.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {            
            if (_estate != null)
            {
                if (_imageSource != null)
                {
                    _estate.ImageSource = _imageSource;
                }
            }
            _mainWindow.AddEstate(_estate);
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
                ImageSource = filename;
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
            //reset to default image
            ImageSource = null;
            imgBox.Source = null;
        }
    }
}
