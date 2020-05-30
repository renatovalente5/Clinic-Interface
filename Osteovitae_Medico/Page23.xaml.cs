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
    /// Interaction logic for Page23.xaml
    /// </summary>
    public partial class Page23 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", data = "", conteudo = "", contact3="";
        public Page23(string name, string surname, string address, string pw, string contact, string type, string date, string content, string contact2)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            data = date;
            conteudo = content;
            contact3 = contact2;
        }
        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            Page22 not = new Page22(nome, apelido, mail, pass, contacto, tipo, conteudo);
            this.NavigationService.Navigate(not);
        }
        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Page21 not = new Page21(nome, apelido, mail, pass, contacto, tipo, nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(not);
        }
        private async void confirmarButton_Click(object sender, RoutedEventArgs e)
        {
            // GUARDAR TRATAMENTO NA BD
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.GetTaskAsync("ConsultasMarcadas/" + contact3 + "/tratamento/numero");
            Numero num = response.ResultAs<Numero>();

            num.numero = "" + (Int32.Parse(num._numero) + 1);
            var trat = "trat" + num.numero;
            FirebaseResponse response2 = await client.SetTaskAsync("ConsultasMarcadas/" + contact3 + "/tratamento/numero", num);
            Numero num2 = response2.ResultAs<Numero>();

            var tratamento = new Tratamento { Data = data, Hora = null, TipoConsulta = null, Medico = "Xavier Santos", Mensagem = conteudo };
            FirebaseResponse response3 = await client.SetTaskAsync("ConsultasMarcadas/" + contact3 + "/tratamento/" + trat, tratamento);
            Tratamento obj = response3.ResultAs<Tratamento>();

            Page24 conf = new Page24(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(conf);
        }
        public class Tratamento
        {
            public String Data { get; set; }
            public String Hora { get; set; }
            public String TipoConsulta { get; set; }
            public String Medico { get; set; }
            public String VerMais { get; set; }
            public String Mensagem { get; set; }
        }

        // ------------------------------------------- MENU RODAPÉ -------------------------------------------
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
        private void agendaBtn_Click(object sender, RoutedEventArgs e)
        {
            Page18 agenda = new Page18(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(agenda);
        }
        private void pacientesBtn_Click(object sender, RoutedEventArgs e)
        {
            Page2 pacientes = new Page2(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(pacientes);
        }
        private void notificacoesBtn_Click(object sender, RoutedEventArgs e)
        {
            Page6 notificacoes = new Page6(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(notificacoes);
        }
        private void contaBtn_Click(object sender, RoutedEventArgs e)
        {
            Page9 conta = new Page9(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(conta);
        }
    }
}
