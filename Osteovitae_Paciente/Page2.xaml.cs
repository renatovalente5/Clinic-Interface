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
using RestSharp;

namespace Osteovitae_Paciente
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;
        public Page2()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }

        private async void click_registar(object sender, RoutedEventArgs e)
        {
            alertLabel.Visibility = Visibility.Hidden;
            int validos = 1;
            // confirmar nome
            if (nomeTextBox.Text == "")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"NOME\" inválido !";
                validos = 0;
            }
            // confirmar apelido
            if (apelidoTextBox.Text == "")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"APELIDO\" inválido !";
                validos = 0;
            }
            /*// confirmar contacto
            if (contactoTextBox.Text == "")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"CONTACTO\" inválido !";
                validos = 0;
            }*/
            // confirmar email
            if (emailTextBox.Text == "")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"E-MAIL\" inválido !";
                validos = 0;
            }
            // confirmar se as palavras-passes coincidem
            if (passwordTextBox.Text != confirmarpasswordTextBox.Text)
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! As palavras-passe não coincidem. !";
                passwordTextBox.Text = "";
                confirmarpasswordTextBox.Text = "";
                validos = 0;
            }
            // confirmar check da privacidade de dados
            if (checkPrivacidadeDados.IsChecked == false)
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! Para se registar tem de aceitar a política de privacidade de dados !";
                validos = 0;
            }
            if (validos == 1)
            {
                Data data = new Data();
                data.Nome = nomeTextBox.Text;
                data.Apelido = apelidoTextBox.Text;
                data.Contacto = contactoTextBox.Text;
                data.Email = emailTextBox.Text;
                data.Pass = passwordTextBox.Text;
                data.Tipo = "Paciente";

                //Falta meter aqui um erro para o caso de o Contacto já existir

                SetResponse response = await client.SetTaskAsync("Information/" + contactoTextBox.Text, data);
                Data result = response.ResultAs<Data>();

                Numero num = new Numero();
                num.numero = "0";

                SetResponse response2 = await client.SetTaskAsync("ConsultasMarcadas/" + data.Contacto + "/numero", num);
                Numero obj = response.ResultAs<Numero>();

                Page3 menu = new Page3(data.Nome, data.Apelido, data.Email, data.Pass, data.Contacto, data.Tipo);
                this.NavigationService.Navigate(menu);
            }
        }
    }
}
