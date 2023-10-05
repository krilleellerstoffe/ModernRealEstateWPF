using System.Windows;

namespace ModernRealEstate
{
    /// <summary>
    /// Interaction logic for SimpleInputWindow.xaml
    /// </summary>

    public partial class SimpleInputWindow : Window
    {
        private AddEditWindow? _parentWindow;

        public SimpleInputWindow()
        {
            InitializeComponent();
        }
        public SimpleInputWindow(AddEditWindow parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //only can call addPicure() if parent window exists
            if (_parentWindow == null) return;
            string url = txtURL.Text;
            //check URL worked ok
            if (_parentWindow.AddPicture(url))
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtURL_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtURL.Text.StartsWith("Enter")) txtURL.Text = "";
        }

        private void txtURL_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtURL.Text)) txtURL.Text = "Enter URL here...";
        }
    }
}
