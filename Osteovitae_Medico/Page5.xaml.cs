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

namespace Osteovitae_Medico
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "";

        public Page5(string name, string surname, string address, string pw, string contact, string type)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            listar_consultas();
        }
        private void linhaSelecionada(object sender, SelectionChangedEventArgs e)
        {
            Consulta consulta = (Consulta)ListaConsultas.SelectedItem;
            Page13 abrir = new Page13(consulta.Nome, consulta.Apelido, mail, pass, contacto, tipo, consulta.Data, consulta.Hora, consulta.TipoConsulta, consulta.Medico);
            this.NavigationService.Navigate(abrir);
        }
        private async void listar_consultas()
        {
            client = new FireSharp.FirebaseClient(config);

            List<String> ListaContas = new List<string>();
            List<Consulta> ListaOrdenada = new List<Consulta>();

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

            string mais = "➜";
            foreach (String item in ListaContas)
            {
                FirebaseResponse response = await client.GetTaskAsync("ConsultasMarcadas/" + item + "/numero");
                Numero num2 = response.ResultAs<Numero>();

                FirebaseResponse response6 = await client.GetTaskAsync("Information/" + item);
                Data data2 = response6.ResultAs<Data>();

                for (int i = 1; i <= Int32.Parse(num2._numero); i++)
                {
                    var consulta = "consulta" + i;
                    FirebaseResponse response5 = await client.GetTaskAsync("ConsultasMarcadas/" + item + "/" + consulta);
                    Consulta obj = response5.ResultAs<Consulta>();

                    var tempConsulta = new Consulta { Data = obj.Data, Hora = obj.Hora, TipoConsulta = obj.TipoConsulta, Medico = obj.Medico, vermais = mais , Nome = data2.Nome, Apelido = data2.Apelido};
                    //ListaConsultas.Items.Add(tempConsulta);
                    ListaConsultas.Items.Add(tempConsulta);
                    ListaConsultas.Items.SortDescriptions.Add(new SortDescription("Data", ListSortDirection.Ascending));
                }
            }


            //ListaOrdenada.Sort( ("Data");
            //ListaConsultas.Items.SortDescriptions ("Data", ListSortDirection.Ascending);
            //ListaConsultas.Items.SortDescriptions.Add(new SortDescription("Data", ListSortDirection.Ascending));

            //.Items.Add(ListaOrdenada);

            //for (int i = 1; i <= Int32.Parse(num._numero); i++)
            //{
            //    var consulta = "consulta" + i;
            //    FirebaseResponse response2 = await client2.GetTaskAsync("ConsultasMarcadas/"+ contacto +"/" + consulta);
            //    Consultas obj = response2.ResultAs<Consultas>();
            //    var tempConsulta = new Consulta { data = obj.Data , hora = obj.Hora, tipoconsulta = obj.TipoConsulta, medicoconsulta= obj.Medico, vermais = mais };
            //    ListaConsultas.Items.Add(tempConsulta);
            //}
        }

        public class Consulta
        {
            public String Data { get; set; }
            public String Hora { get; set; }
            public String TipoConsulta { get; set; }
            public String Medico{ get; set; }
            public String vermais { get; set; }
            public String Nome { get; set; }
            public String Apelido { get; set; }
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
