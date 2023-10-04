using ModernRealEstateBLL;
using System;
using System.Collections.Generic;
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
        private string _filePath;
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
    }
}
