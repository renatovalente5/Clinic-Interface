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
            List<String> ListaContas = new List<string>();

            FirebaseResponse response2 = await client.GetTaskAsync("TodosOsUsers/numero");
            Numero num = response2.ResultAs<Numero>();

            for (int i = 1; i <= Int32.Parse(num._numero); i++)
            {
                var user = "user" + i;
                FirebaseResponse response3 = await client.GetTaskAsync("TodosOsUsers/users/" + user);
                Numero obj2 = response3.ResultAs<Numero>();

                var tempContas = new Numero { numero = obj2.numero };
                ListaContas.Add(tempContas.numero);
            }

            FirebaseResponse response;
            Data obj;

            if (ListaContas.Contains(telefoneTextBox.Text))
            {
                response = await client.GetTaskAsync("Information/" + telefoneTextBox.Text);
                obj = response.ResultAs<Data>();

                if (passwordTextBox.Password == obj.Pass)
                {
                    Page3 menu = new Page3(obj.Nome, obj.Apelido, obj.Email, obj.Pass, obj.Contacto, obj.Tipo);
                    this.NavigationService.Navigate(menu);
                }
                else
                {
                    logininvalido.Visibility = Visibility.Hidden;
                    passinvalida.Visibility = Visibility.Visible;
                }
            }
            else
            {
                passinvalida.Visibility = Visibility.Hidden;
                logininvalido.Visibility = Visibility.Visible;
            }
        }

        private void click_criarconta(object sender, RoutedEventArgs e)
        {
            Page2 criarconta = new Page2();
            this.NavigationService.Navigate(criarconta);
        }
    }
}
