﻿using ModernRealEstateBLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for BuyerSellerWindow.xaml
    /// </summary>
    public partial class BuyerSellerWindow : Window
    {
        private Person _person;
        private DetailsWindow _parent;
        public BuyerSellerWindow(DetailsWindow parentWindow)
        {
            InitializeComponent();
            _parent = parentWindow;
            cBoxPayment.ItemsSource = Enum.GetValues(typeof(PaymentTypes));
            cBoxPayment.SelectedIndex = 0;
        }
        public BuyerSellerWindow(DetailsWindow parentWindow, Person person) : this(parentWindow)
        {
            _person = person;
            SetName(person);
            SetPayment(person.PaymentDetails);
        }
        private void SetName(Person person)
        {
            txtFirstName.Text = string.IsNullOrEmpty(person.FirstName) ? "": person.FirstName;
            txtLastName.Text = string.IsNullOrEmpty(person.LastName) ? "" : person.LastName;
        }
        private void SetPayment(Payment payment)
        {
            if (payment == null) {
                ControlPaymentType(PaymentTypes.None);
                return;
            }
            txtAccName.Text = payment.PaymentName;
            if (payment.PaymentType == PaymentTypes.Bank)
            {
                txtAccNum.Text = payment.PaymentDetails;
            }
            else
            {
                txtAccEmail.Text = payment.PaymentDetails;
            }                     
            ControlPaymentType(payment.PaymentType);
        }
        private void cBoxPayment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ControlPaymentType((PaymentTypes)cBoxPayment.SelectedItem);
        }
        private void ControlPaymentType(PaymentTypes paymentType)
        {
            switch (paymentType)
            {
                case PaymentTypes.PayPal:
                case PaymentTypes.Western_Union:
                    PaymentControlsVisibility(true, false, true);
                    break;
                case PaymentTypes.Bank:
                    PaymentControlsVisibility(true, true, false);
                    break;
                default:
                    PaymentControlsVisibility(false, false, false);
                    break;
            }
        }
        private void PaymentControlsVisibility(bool accName, bool accNumber, bool accEmail)
        {
            lblAccName.Visibility = accName ? Visibility.Visible: Visibility.Collapsed;
            txtAccName.Visibility = accName ? Visibility.Visible : Visibility.Collapsed;

            lblAccNum.Visibility = accNumber ? Visibility.Visible : Visibility.Collapsed;
            txtAccNum.Visibility = accNumber ? Visibility.Visible : Visibility.Collapsed;

            lblAccEmail.Visibility = accEmail ? Visibility.Visible : Visibility.Collapsed;
            txtAccEmail.Visibility = accEmail ? Visibility.Visible : Visibility.Collapsed;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //check buyer/seller
            SaveDetailsToPerson();
            if (_person is Buyer)
            {
                _parent.Buyer = _person as Buyer;
            }
            else
            {
                _parent.Seller = _person as Seller;
            }
            this.Close();
            //save person in object and return to parent window
        }

        private void SaveDetailsToPerson()
        {
            _person.FirstName = txtFirstName.Text;
            _person.LastName = txtLastName.Text;
            _person.PaymentDetails = CreatePaymentDetails();
            
        }

        private Payment CreatePaymentDetails()
        {
            Payment payment;
            switch (cBoxPayment.SelectedItem)
            {
                case PaymentTypes.PayPal:
                    payment = new Paypal();
                    payment.PaymentDetails = txtAccEmail.Text;
                    break;
                case PaymentTypes.Western_Union:
                    payment = new WesternUnion();
                    payment.PaymentDetails = txtAccEmail.Text;
                    break;
                case PaymentTypes.Bank:
                    payment = new Bank();
                    payment.PaymentDetails = txtAccNum.Text;
                    break;
                default:
                    payment = null;
                    break;
            }
            if (payment != null)
            {
                payment.PaymentName = txtAccName.Text;
            }
            return payment;
        }
    }
}
