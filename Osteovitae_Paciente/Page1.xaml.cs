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
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Osteovitae_Paciente
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;

        public Page1()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }

        private async void click_login(object sender, RoutedEventArgs e)
        {
            FirebaseResponse response;
            Data obj;
            try
            {
                response = await client.GetTaskAsync("Information/" + telefoneTextBox.Text);
                obj = response.ResultAs<Data>();
            }
            catch (Exception)
            {
                passinvalida.Visibility = Visibility.Visible;
                throw;
            }

            if(passwordTextBox.Password == obj.Pass)
            {
                //MessageBox.Show("obj: ", obj.Contacto);
                // = obj.Email;
                //nome = obj.Nome;
                //contacto = obj.Contacto;
                //pass = obj.Pass;
                //apelido = obj.Apelido;
                //tipo = obj.Tipo;
                Page3 menu = new Page3(obj.Nome, obj.Apelido, obj.Email, obj.Pass, obj.Contacto, obj.Tipo);
                this.NavigationService.Navigate(menu);
            }
            else
            {
                passinvalida.Visibility = Visibility.Visible;
            }
        }

        private void click_criarconta(object sender, RoutedEventArgs e)
        {
            Page2 criarconta = new Page2();
            this.NavigationService.Navigate(criarconta);
        }
    }
}
