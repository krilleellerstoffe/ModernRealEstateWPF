using ModernRealEstateBLL;
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
        public BuyerSellerWindow()
        {
            InitializeComponent();
            cBoxPayment.ItemsSource = Enum.GetValues(typeof(PaymentTypes));
            cBoxPayment.SelectedIndex = 0;
        }
        public BuyerSellerWindow(Person person) : this()
        {
            SetName(person);
            SetPayment(person.PaymentDetails);
        }
        private void SetName(Person person)
        {
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
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
                    EnableControls(true, false, true);
                    break;
                case PaymentTypes.Bank:
                    EnableControls(true, true, false);
                    break;
                case PaymentTypes.None:
                    EnableControls(false, false, false);
                    break;
                default:
                    break;
            }
        }
        private void EnableControls(bool accName, bool accNumber, bool accEmail)
        {
            lblAccName.IsEnabled = accName;
            txtAccName.IsEnabled = accName;

            lblAccNum.IsEnabled = accNumber;
            txtAccNum.IsEnabled = accNumber;

            lblAccEmail.IsEnabled = accEmail;
            txtAccEmail.IsEnabled = accEmail;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //check buyer/seller
            //save person in object and return to parent window
        }


    }
}
