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
using Microsoft.Office.Interop.Excel;

namespace Osteovitae_Medico
{
    /// <summary>
    /// Interaction logic for Page11.xaml
    /// </summary>
    public partial class Page11 : System.Windows.Controls.Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", dataConsulta="", horaConsulta="", servicoConsulta="", medicoConsulta="" ;
        IFirebaseClient client;
        public Page11(string name, string surname, string address, string pw, string contact, string type, string data, string hora, string servico, string medico)
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

            client = new FireSharp.FirebaseClient(config);
            displayContact();
        }

        private async void displayContact()
        {
            FirebaseResponse response = await client.GetTaskAsync("Information/" + contacto);
            Data obj = response.ResultAs<Data>();

            var tempPaciente = new Data { Nome = obj.Nome, Apelido = obj.Apelido, Contacto = obj.Contacto, Email = obj.Email};
            nomeTextBox.Content = obj.Nome +" " + obj.Apelido;
        }

        private async void click_confirmar(object sender, RoutedEventArgs e)
        {
            Consultas consulta = new Consultas();
            consulta.Medico = medicoConsulta;
            consulta.TipoConsulta = servicoConsulta;
            consulta.Data = dataConsulta;
            consulta.Hora = horaConsulta;
                        
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
            Page4 voltar = new Page4(nome, apelido, mail, pass, contacto, tipo, dataConsulta, horaConsulta, servicoConsulta, medicoConsulta, 11);
            this.NavigationService.Navigate(voltar);
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
