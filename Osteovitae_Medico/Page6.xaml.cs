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
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client2;
        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "";
        public Page6(string name, string surname, string address, string pw, string contact, string type)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            listar_notificacoes();
        }
        private void linhaSelecionada(object sender, SelectionChangedEventArgs e)
        {
            Notificacao notificacao = (Notificacao)ListaNotificacoes.SelectedItem;
            Page16 abrir = new Page16(nome, apelido, mail, pass, contacto, tipo, notificacao.Data, notificacao.Hora, notificacao.TipoConsulta, notificacao.MedicoConsulta, notificacao.Mensagem);
            this.NavigationService.Navigate(abrir);
        }
        private async void listar_notificacoes()
        {
            client2 = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client2.GetTaskAsync("Notificacoes/numero"); ;
            Numero num = response.ResultAs<Numero>();
            string mais = "➜";
            
            for (int i = 1; i <= Int32.Parse(num._numero); i++)
            {
                var notificacao = "notificacao" + i;
                FirebaseResponse response2 = await client2.GetTaskAsync("Notificacoes/" + notificacao);
                Notificacao obj = response2.ResultAs<Notificacao>();

                var tempNotificacao = new Notificacao { Data = obj.Data, Hora = obj.Hora, TipoConsulta = obj.TipoConsulta, MedicoConsulta = "Xavier Santos", VerMais = mais, Mensagem = obj.Mensagem };
                ListaNotificacoes.Items.Add(tempNotificacao);
            }
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

        private void novaNotificacaoButton_Click(object sender, RoutedEventArgs e)
        {
            Page19 menu = new Page19(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(menu);
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
            Page18 menu = new Page18(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(menu);
        }
        private void pacientesBtn_Click(object sender, RoutedEventArgs e)
        {
            Page2 menu = new Page2(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(menu);
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
