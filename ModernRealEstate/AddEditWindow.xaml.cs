using Microsoft.Win32;
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
        public AddEditWindow()
        {
            InitializeComponent();
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
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //ask BLL to create new object
            //get parent window to update lists
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
                ImgBox.Source = new BitmapImage(new Uri(filename));
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
            ImgBox.Source = new BitmapImage(new Uri("/Resources/logo.png"));
        }
    }
}
