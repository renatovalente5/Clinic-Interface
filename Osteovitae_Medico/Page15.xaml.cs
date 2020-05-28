using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
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

namespace Osteovitae_Medico
{
    /// <summary>
    /// Interaction logic for Page15.xaml
    /// </summary>
    public partial class Page15 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", dataConsulta = "", horaConsulta = "", servicoConsulta = "", medicoConsulta = "";

        public Page15()
        {
            InitializeComponent();
        }
        public Page15(string name, string surname, string address, string pw, string contact, string type, string data, string hora, string servico, string medico)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            dataConsulta = data;
            horaConsulta = hora;
            servicoConsulta = servico;
            medicoConsulta = medico;
        }

        private void click_cancelar(object sender, RoutedEventArgs e)
        {
            Page13 cancelar = new Page13(nome, apelido, mail, pass, contacto, tipo, dataConsulta, horaConsulta, servicoConsulta, medicoConsulta);
            this.NavigationService.Navigate(cancelar);
        }
        private async void click_eliminar(object sender, RoutedEventArgs e)
        {
            // COLOCAR AQUI O CODIGO DE ELIMINAR NA BD
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.GetTaskAsync("ConsultasMarcadas/" + contacto + "/numero"); ;
            Numero num = response.ResultAs<Numero>();


            var consulta = "consulta" + Int32.Parse(num._numero);
            FirebaseResponse response2 = await client.DeleteTaskAsync("ConsultasMarcadas/" + contacto + "/" + consulta);

            num._numero = (Int32.Parse(num._numero) - 1) + "";
            FirebaseResponse response3 = await client.UpdateTaskAsync("ConsultasMarcadas/" + contacto + "/numero", num); ;

            Page5 menu = new Page5(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(menu);
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            Page13 cancelar = new Page13(nome, apelido, mail, pass, contacto, tipo, dataConsulta, horaConsulta, servicoConsulta, medicoConsulta);
            this.NavigationService.Navigate(cancelar);
        }
        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            Page3 menu = new Page3(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(menu);
        }

        private void novaConsultaBtn_Click(object sender, RoutedEventArgs e)
        {
            Page4 novaconsulta = new Page4(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(novaconsulta);
        }

        private void listaConsultasBtn_Click(object sender, RoutedEventArgs e)
        {
            Page5 listaconsultas = new Page5(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(listaconsultas);
        }

        private void notificacoesBtn_Click(object sender, RoutedEventArgs e)
        {
            Page6 notificacoes = new Page6(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(notificacoes);
        }

        private void tratamentosBtn_Click(object sender, RoutedEventArgs e)
        {
            Page7 tratamentos = new Page7(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(tratamentos);
        }

        private void osteovitaeBtn_Click(object sender, RoutedEventArgs e)
        {
            Page8 osteovitae = new Page8(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(osteovitae);
        }

        private void contaBtn_Click(object sender, RoutedEventArgs e)
        {
            Page9 conta = new Page9(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(conta);
        }
    }
}
