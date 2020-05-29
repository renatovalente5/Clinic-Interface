using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using Newtonsoft.Json;

namespace Osteovitae_Medico
{
    /// <summary>s
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

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "";

        public Page2(string name, string surname, string address, string pw, string contact, string type)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            listar_pacientes();
        }
        private void linhaSelecionada(object sender, SelectionChangedEventArgs e)
        {
            Data pac = (Data)ListaPacientes.SelectedItem;
            Page21 abrir = new Page21(pac.Nome, pac.Apelido, pac.Email, pac.Pass, pac.Contacto, pac.Tipo);
            this.NavigationService.Navigate(abrir);
        }
        private async void listar_pacientes()
        {
            client = new FireSharp.FirebaseClient(config);

            List<String> ListaContas = new List<string>();

            FirebaseResponse response2 = await client.GetTaskAsync("TodosOsUsers/numero");
            Numero num = response2.ResultAs<Numero>();

            for (int i = 1; i <= Int32.Parse(num._numero); i++)
            {
                var user = "user" + i;
                FirebaseResponse response3 = await client.GetTaskAsync("TodosOsUsers/users/" + user);
                Numero obj2 = response3.ResultAs<Numero>();

                var tempContas = new Numero { numero = obj2.numero };
                if (obj2.numero != "912345678")
                {
                    ListaContas.Add(tempContas.numero);
                }
            }

            string mais = "➜";
            foreach (String item in ListaContas)
            {
                FirebaseResponse response = await client.GetTaskAsync("Information/" + item);
                Data obj = response.ResultAs<Data>();

                var tempPaciente = new Data { Nome = obj.Nome, Apelido = obj.Apelido, Contacto = obj.Contacto, Email = obj.Email, vermais = mais };
                ListaPacientes.Items.Add(tempPaciente);
                ListaPacientes.Items.SortDescriptions.Add(new SortDescription("Data", ListSortDirection.Ascending));
            }       
        }

        public class Paciente
        {
            public String Nome { get; set; }
            public String Email { get; set; }
            public String Contacto { get; set; }
            public String Apelido { get; set; }
            public String VerMais { get; set; }
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
