using Microsoft.Win32;
using ModernRealEstateBLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ModernRealEstate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EstateManager _manager;
        private Estate _selectedEstate;
        private string? _filePath;
        private Dictionary<EstateTypes, bool> _filter;

        public MainWindow()
        {
            InitializeComponent();
            _manager = new EstateManager();
            _filter = new Dictionary<EstateTypes, bool>();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //open add/edit window
            AddEditWindow addEditWindow = new AddEditWindow(this);
            addEditWindow.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //confirm close
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstEstates.SelectedItem != null)
            {
                _manager.DeleteAt(lstEstates.SelectedIndex);
            }
            //confirm delete
            UpdateList();
        }


        private void UpdateList()
        {
            //get new list from BLL using filter values
            lstEstates.Items.Clear();
            for (int i = 0; i < _manager.Count; i++)
            {
                if (!isFilteredOut(_manager.GetAt(i)))
                {
                    lstEstates.Items.Add(_manager.GetAt(i));
                }
            }
        }
        private bool isFilteredOut(Estate estate)
        {
            if (_filter.TryGetValue(estate.EstateType, out bool _))
                return _filter[estate.EstateType];
            else return false; //returns false if not in filter, or filter set to false
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePicture();
            //enable/disable buttons
            //update picture box
        }

        public void UpdatePicture()
        {
            if (_selectedEstate != null)
            {
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                try
                {
                    ImgBox.Source = new BitmapImage(new Uri(_selectedEstate.ImageSource));
                }
                catch (Exception e)
                {
                    ImgBox.Source = null;
                }
            }
            else
            {
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;
                ImgBox.Source = null;
            }

        }

        public void AddEstate(Estate estate)
        {
            _manager.Add(estate);
            UpdateList();
        }

        private void chBoxResidential_Click(object sender, RoutedEventArgs e)
        {
            bool filterActive = (bool)!chBoxResidential.IsChecked;
            _filter[EstateTypes.Villa] = filterActive;
            _filter[EstateTypes.Townhouse] = filterActive;
            _filter[EstateTypes.Apartment] = filterActive;
            UpdateList();
        }

        private void chBoxCommercial_Click(object sender, RoutedEventArgs e)
        {
            bool filterActive = (bool)!chBoxCommercial.IsChecked;
            _filter[EstateTypes.Shop] = filterActive;
            _filter[EstateTypes.Warehouse] = filterActive;
            UpdateList();
        }

        private void chBoxInstitutions_Click(object sender, RoutedEventArgs e)
        {
            bool filterActive = (bool)!chBoxInstitutions.IsChecked;
            _filter[EstateTypes.School] = filterActive;
            _filter[EstateTypes.University] = filterActive;
            _filter[EstateTypes.Hospital] = filterActive;
            UpdateList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEstate == null)
            {
                Console.WriteLine("No object selected");

                //TODO: popup confirming that no object will be edited
                return;
            }
            AddEditWindow addEditWindow = new AddEditWindow(_selectedEstate, this);
            addEditWindow.Show();
        }

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Start from fresh?\n\nAny information not saved will be lost!!", "Confirm new", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                _manager = new EstateManager();
                _filePath = null;
                _filter.Clear();
                UpdateList();
            }
        }

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void menuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private bool SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "DAT files (*.dat)|*.dat"
            };
            if (sfd.ShowDialog() == true)
            {
                if (sfd.FileName != "")
                {
                    return Save(sfd.FileName);
                }
            }
            return false;
        }

        public bool Save()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                return SaveAs();
            }
            return Save(_filePath);
        }
        private bool Save(string filePath)
        {
            try
            {
                _manager.BinarySerialize(filePath);
                MessageBox.Show(_filePath + " saved successfully", "Success", MessageBoxButton.OK);
                _filePath = filePath;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_filePath + " could not be saved\n" + ex.Message, "Failed", MessageBoxButton.OK);
                return false;
            }

        }
        private void Open()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "DAT files (*.dat)|*.dat"
            };
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    _manager = (EstateManager) _manager.BinaryDeSerialize(ofd.FileName);
                    _filePath = ofd.FileName;
                    UpdateList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(_filePath + " could not be opened\n" + ex.Message, "Failed", MessageBoxButton.OK);                   
                }
            }
        }
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            //confirm close
            this.Close();
        }
    }
}
