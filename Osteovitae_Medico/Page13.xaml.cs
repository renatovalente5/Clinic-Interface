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
    /// Interaction logic for Page13.xaml
    /// </summary>
    public partial class Page13 : Page
    {
        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", dataConsulta = "", horaConsulta = "", servicoConsulta = "", medicoConsulta = "";
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

            pacienteTextBox.Content = nome + " " + apelido;
            contactoTextBox.Content = contacto;
            dataTextBox.Content = data;
            horaTextBox.Content = hora;
            servicoTextBox.Content = servico;
            medicoTextBox.Content = medico;
        }
        private void click_eliminar(object sender, RoutedEventArgs e)
        {
            Page15 elim = new Page15(nome, apelido, mail, pass, contacto, tipo, dataConsulta, horaConsulta, servicoConsulta, medicoConsulta);
            this.NavigationService.Navigate(elim);
        }
        private void click_editar(object sender, RoutedEventArgs e)
        {
            Page4 voltar = new Page4(nome, apelido, mail, pass, contacto, tipo, dataConsulta, horaConsulta, servicoConsulta, medicoConsulta, 13);
            this.NavigationService.Navigate(voltar);
        }
        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            Page5 listaconsultas = new Page5(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(listaconsultas);
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
