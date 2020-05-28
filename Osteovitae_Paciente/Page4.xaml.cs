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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "", medico="";
        private int hora, minutos;
        public Page4()
        {
            InitializeComponent();
        }

        public Page4(string name, string surname, string address, string pw, string contact, string type)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            horaTextBox.Text = "09";
            hora = Int32.Parse(horaTextBox.Text);
            horaTextBox.Foreground = new SolidColorBrush(Colors.Black);
            minutosTextBox.Text = "00";
            minutos = Int32.Parse(minutosTextBox.Text);
            minutosTextBox.Foreground = new SolidColorBrush(Colors.Black);
            maisHora.Visibility = Visibility.Hidden;
            maisMinuto.Visibility = Visibility.Hidden;
            //data = Int32.Parse(DateTime.Now.ToString().Split(' ')[1].Split(':')[0]);
            //MessageBox.Show(data.ToString());
        }
        public Page4(string name, string surname, string address, string pw, string contact, string type, string date, string hour, string service, string doctor, int id)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;
            string [] h = hour.Split(':');
            horaTextBox.Text = h[0];
            hora = Int32.Parse(horaTextBox.Text);
            horaTextBox.Foreground = new SolidColorBrush(Colors.Black);
            minutosTextBox.Text = h[1];
            minutos = Int32.Parse(minutosTextBox.Text);
            minutosTextBox.Foreground = new SolidColorBrush(Colors.Black);
            menosHora.Visibility = Visibility.Hidden;
            menosMinuto.Visibility = Visibility.Hidden;
            string[] d = date.Split('-');
            diaTextBox.Text = d[0];
            mesTextBox.Text = d[1];
            anoTextBox.Text = d[2];
            tipoComboBox.Text = service;
            medico = doctor;
            diaTextBox.Foreground = new SolidColorBrush(Colors.Black);
            mesTextBox.Foreground = new SolidColorBrush(Colors.Black);
            anoTextBox.Foreground = new SolidColorBrush(Colors.Black);
            if (id == 13)
            {
                titulo.Content = "LISTA DE CONSULTAS";
            }
        }

        private void data_selecionada(object sender, SelectionChangedEventArgs e)
        {
            String[] dataSelect = calendar1.SelectedDate.ToString().Split(' ')[0].Split('/');
            diaTextBox.Text = dataSelect[0];
            diaTextBox.Foreground = new SolidColorBrush(Colors.Black);
            mesTextBox.Text = dataSelect[1];
            mesTextBox.Foreground = new SolidColorBrush(Colors.Black);
            anoTextBox.Text = dataSelect[2];
            anoTextBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void menosHora_Click(object sender, RoutedEventArgs e)
        {
            hora = Int32.Parse(horaTextBox.Text);
            if (hora == 18)
            {
                maisHora.Visibility = Visibility.Visible;
                menosHora.Visibility = Visibility.Hidden;
            }
            else if (hora == 17)
            {
                maisHora.Visibility = Visibility.Visible;
                menosHora.Visibility = Visibility.Hidden;
                horaTextBox.Text = "18";
            }
            else
            {
                menosHora.Visibility = Visibility.Visible;
                maisHora.Visibility = Visibility.Visible;
                horaTextBox.Text = (hora + 1).ToString();
            }
        }

        private void maisHora_Click(object sender, RoutedEventArgs e)
        {
            hora = Int32.Parse(horaTextBox.Text);
            if (hora == 9)
            {
                maisHora.Visibility = Visibility.Hidden;
                menosHora.Visibility = Visibility.Visible;
            }
            else if (hora == 10)
            {
                maisHora.Visibility = Visibility.Hidden;
                menosHora.Visibility = Visibility.Visible;
                horaTextBox.Text = "09";
            }
            else
            {
                menosHora.Visibility = Visibility.Visible;
                maisHora.Visibility = Visibility.Visible;
                horaTextBox.Text = (hora - 1).ToString();
            }
        }

        private void menosMinuto_Click(object sender, RoutedEventArgs e)
        {
            minutos = Int32.Parse(minutosTextBox.Text);
            if (minutos == 45)
            {
                menosMinuto.Visibility = Visibility.Visible;
                menosMinuto.Visibility = Visibility.Hidden;
            }
            else if (minutos == 30)
            {
                menosMinuto.Visibility = Visibility.Visible;
                menosMinuto.Visibility = Visibility.Hidden;
                minutosTextBox.Text = "45";
            }
            else
            {
                menosMinuto.Visibility = Visibility.Visible;
                maisMinuto.Visibility = Visibility.Visible;
                minutosTextBox.Text = (minutos + 15).ToString();
            }
        }

        private void maisMinuto_Click(object sender, RoutedEventArgs e)
        {
            minutos = Int32.Parse(minutosTextBox.Text);
            if (minutos == 0)
            {
                maisMinuto.Visibility = Visibility.Hidden;
                menosMinuto.Visibility = Visibility.Visible;
            }
            else if (minutos == 15)
            {
                maisMinuto.Visibility = Visibility.Hidden;
                menosMinuto.Visibility = Visibility.Visible;
                minutosTextBox.Text = "00";
            }
            else
            {
                menosMinuto.Visibility = Visibility.Visible;
                maisMinuto.Visibility = Visibility.Visible;
                minutosTextBox.Text = (minutos - 15).ToString();
            }
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

        private void click_marcar(object sender, RoutedEventArgs e)
        {
            int valido = 1;
            if (diaTextBox.Text == "" || diaTextBox.Text == "DD")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"DATA DA CONSULTA\" inválida !";
                valido = 0;
            }
            if (mesTextBox.Text == "" || mesTextBox.Text == "MM")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"DATA DA CONSULTA\" inválida !";
                valido = 0;
            }
            if (anoTextBox.Text == "" || anoTextBox.Text == "AAAA")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"DATA DA CONSULTA\" inválida !";
                valido = 0;
            }
            if (horaTextBox.Text == "" || horaTextBox.Text == "HH")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"HORA DA CONSULTA\" inválida !";
                valido = 0;
            }
            if (minutosTextBox.Text == "" || minutosTextBox.Text == "MM")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"HORA DA CONSULTA\" inválida !";
                valido = 0;
            }
            if (tipoComboBox.Text == "")
            {
                alertLabel.Visibility = Visibility.Visible;
                alertLabel.Content = "! \"TIPO DE CONSULTA\" inválida !";
                valido = 0;
            }
            if (valido == 1)
            {
                string dataCon = diaTextBox.Text + "-" + mesTextBox.Text + "-" + anoTextBox.Text;
                string horaCon = horaTextBox.Text + ":" + minutosTextBox.Text;
                Page11 confirmar = new Page11(nome, apelido, mail, pass, contacto, tipo, dataCon, horaCon, tipoComboBox.Text, "Xavier Santos");
                this.NavigationService.Navigate(confirmar);
            }
        }
    }
}
