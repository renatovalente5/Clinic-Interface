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

namespace Osteovitae_Medico
{
    /// <summary>
    /// Interaction logic for Page8.xaml
    /// </summary>
    public partial class Page8 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };
        IFirebaseClient client;
        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", data="", conteudo="";
        public Page8(string name, string surname, string address, string pw, string contact, string type, string date, string content)
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
        }
        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            Page19 not = new Page19(nome, apelido, mail, pass, contacto, tipo, conteudo);
            this.NavigationService.Navigate(not);
        }
        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Page6 not = new Page6(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(not);
        }
        private async void confirmarButton_Click(object sender, RoutedEventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Notificacoes/numero");
            Numero num = response.ResultAs<Numero>();

            var not = "" + (Int32.Parse(num._numero) + 1);
            var notificacao = "notificacao" + (Int32.Parse(num._numero) + 1);
            Numero num2 = response.ResultAs<Numero>();
            num2.numero = not;

            FirebaseResponse response2 = await client.SetTaskAsync("Notificacoes/numero", num2);
            Numero num3 = response2.ResultAs<Numero>();

            var tempNotificacao = new Notificacao { Data = data, Hora = null, TipoConsulta = null, MedicoConsulta = "Xavier Santos", VerMais = null, Mensagem = conteudo};

            FirebaseResponse response3 = await client.SetTaskAsync("Notificacoes/" + notificacao, tempNotificacao);
            Numero num4 = response3.ResultAs<Numero>();

            Page20 conf = new Page20(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(conf);
        }
        public class Notificacao
        {
            public String Data { get; set; }
            public String Hora { get; set; }
            public String TipoConsulta { get; set; }
            public String MedicoConsulta { get; set; }
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
