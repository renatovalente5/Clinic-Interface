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
    /// Interaction logic for Page13.xaml
    /// </summary>
    public partial class Page13 : Page
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", dataConsulta = "", horaConsulta = "", servicoConsulta = "", medicoConsulta = "";
        IFirebaseClient client;

        public Page13()
        {
            InitializeComponent();
        }

        public Page13(string name, string surname, string address, string pw, string contact, string type, string data, string hora, string servico, string medico)
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
            dataTextBox.Content = data;
            horaTextBox.Content = hora;
            servicoTextBox.Content = servico;
            medicoTextBox.Content = medico;
        }

        private async void click_confirmar(object sender, RoutedEventArgs e)
        {
            Consultas consulta = new Consultas();
            consulta.Medico = medicoConsulta;
            consulta.TipoConsulta = servicoConsulta;
            consulta.Data = dataConsulta;
            consulta.Hora = horaConsulta;

            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.GetTaskAsync("ConsultasMarcadas/" + contacto + "/numero"); //Saber o numero da Consulta
            Numero num = response.ResultAs<Numero>();

            int n = (Int32.Parse(num.numero) + 1);
            num.numero = n + "";
            var con = "consulta" + n;

            SetResponse response2 = await client.SetTaskAsync("ConsultasMarcadas/" + contacto + "/" + con, consulta);  //Marcar consulta
            Consultas result = response2.ResultAs<Consultas>();

            SetResponse response3 = await client.SetTaskAsync("ConsultasMarcadas/" + contacto + "/numero", num); //Atualizar numero consultas
            Numero num3 = response3.ResultAs<Numero>();

            Page12 confirmar = new Page12(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(confirmar);
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            Page4 voltar = new Page4(nome, apelido, mail, pass, contacto, tipo, dataConsulta, horaConsulta, servicoConsulta, medicoConsulta);
            this.NavigationService.Navigate(voltar);
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
