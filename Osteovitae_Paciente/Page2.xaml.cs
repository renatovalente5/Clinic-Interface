using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Osteovitae_Paciente
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void click_registar(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Text != confirmarpasswordTextBox.Text)
            {
                confirmarPassLabel.Visibility = Visibility.Visible;
                passwordTextBox.Text = "";
                confirmarpasswordTextBox.Text = "";
            }
            if (checkPrivacidadeDados.IsChecked == false)
            {
                confirmarCheckLabel.Visibility = Visibility.Visible;   
            }
            Page3 menu = new Page3();
            this.NavigationService.Navigate(menu);
        }
    }
}
