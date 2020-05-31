using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Page21.xaml
    /// </summary>
    public partial class Page21 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", contact3 = "", name3="", surname3="", address3="";
        public Page21(string name, string surname, string address, string pw, string contact, string type, string name2, string surname2, string address2, string pw2, string contact2, string type2)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            contact3 = contact2;
            name3 = name2;
            surname3 = surname2;
            address3 = address2;
            nomeTextBox.Content = name3 + " " + surname3;
            contactoTextBox.Content = contact3;
            emailTextBox.Content = address3;
            ListasTratamentos();
        }

        private async void ListasTratamentos()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.GetTaskAsync("ConsultasMarcadas/" + contact3 + "/tratamento/numero");
            Numero num = response.ResultAs<Numero>();
            string mais = "➜";
            for (int i = 1; i <= Int32.Parse(num._numero); i++)
            {
                var tratamento = "trat" + i;
                FirebaseResponse response2 = await client.GetTaskAsync("ConsultasMarcadas/" + contact3 + "/tratamento/" + tratamento);
                Tratamento obj = response2.ResultAs<Tratamento>();

                var tempNotificacao = new Tratamento { Data = obj.Data, Hora = obj.Hora, TipoConsulta = obj.TipoConsulta, MedicoConsulta = "Xavier Santos", VerMais = mais, Mensagem = obj.Mensagem };
                ListaTratamentos.Items.Add(tempNotificacao);
                ListaTratamentos.Items.SortDescriptions.Add(new SortDescription("Data", ListSortDirection.Ascending));
            }
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            Page2 pacientes = new Page2(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(pacientes);
        }
        private void novoTratamentoButton_Click(object sender, RoutedEventArgs e)
        {
            Page22 novoTratamento = new Page22(nome, apelido, mail, pass, contacto, tipo, contact3);
            this.NavigationService.Navigate(novoTratamento);
        }
        private void linhaSelecionada(object sender, SelectionChangedEventArgs e)
        {
            Tratamento tra = (Tratamento)ListaTratamentos.SelectedItem;
            Page17 abrir = new Page17(nome, apelido, mail, pass, contacto, tipo, tra.Data, tra.Hora, tra.TipoConsulta, tra.MedicoConsulta, tra.Mensagem, contact3, name3, surname3, address3);
            this.NavigationService.Navigate(abrir);
        }
        public class Tratamento
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
