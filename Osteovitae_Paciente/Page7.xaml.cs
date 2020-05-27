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
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page7 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client2;
        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "";

        public Page7(string name, string surname, string address, string pw, string contact, string type)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            listar_tratamentos();
        }

        private void linhaSelecionada(object sender, SelectionChangedEventArgs e)
        {
            Tratamento tratamento = (Tratamento)ListaTratamentos.SelectedItem;
            Page17 abrir = new Page17(nome, apelido, mail, pass, contacto, tipo, tratamento.data, tratamento.hora, tratamento.tipoconsulta, tratamento.medicoconsulta);
            this.NavigationService.Navigate(abrir);
        }
        private async void listar_tratamentos()
        {
            client2 = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client2.GetTaskAsync("ConsultasMarcadas/" + contacto + "/numero"); ;
            Numero num = response.ResultAs<Numero>();
            string mais = "➜";
            for (int i = 1; i <= Int32.Parse(num._numero); i++)
            {
                var consulta = "consulta" + i;
                FirebaseResponse response2 = await client2.GetTaskAsync("ConsultasMarcadas/" + contacto + "/" + consulta);
                Consultas obj = response2.ResultAs<Consultas>();
                var tempNotificacao = new Tratamento { data = obj.Data, hora = obj.Hora, tipoconsulta = obj.TipoConsulta, medicoconsulta = obj.Medico, vermais = mais };
                ListaTratamentos.Items.Add(tempNotificacao);
            }
        }

        public class Tratamento
        {
            public String data { get; set; }
            public String hora { get; set; }
            public String tipoconsulta { get; set; }
            public String medicoconsulta { get; set; }
            public String vermais { get; set; }
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
