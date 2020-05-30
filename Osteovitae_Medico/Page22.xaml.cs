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
    /// Interaction logic for Page22.xaml
    /// </summary>
    public partial class Page22 : Page
    {
        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", data = "", contact3="";

        public Page22(string name, string surname, string address, string pw, string contact, string type, string contact2)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            contact3 = contact2;
            tipo = type;
            data = DateTime.Now.ToString().Split(' ')[0];
            dataLabel.Content = data;
        }
        public Page22(string name, string surname, string address, string pw, string contact, string type, string content, string contact2)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            contact3 = contact2;
            tipo = type;
            data = DateTime.Now.ToString().Split(' ')[0];
            dataLabel.Content = data;
            conteudoTextBox.Text = content;
        }
        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            Page21 voltar = new Page21(nome, apelido, mail, pass, contacto, tipo, nome, apelido, mail, pass, contact3, tipo);
            this.NavigationService.Navigate(voltar);
        }
        private void registarButton_Click(object sender, RoutedEventArgs e)
        {
            Page23 voltar = new Page23(nome, apelido, mail, pass, contacto, tipo, data, conteudoTextBox.Text, contact3);
            this.NavigationService.Navigate(voltar);
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
