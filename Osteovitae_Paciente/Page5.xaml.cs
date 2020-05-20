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
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace Osteovitae_Paciente
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "";

        public Page5()
        {
            InitializeComponent();
        }

        public Page5(string name, string surname, string address, string pw, string contact, string type)
        {
            InitializeComponent();
            nome = name;
            apelido = surname;
            mail = address;
            pass = pw;
            contacto = contact;
            tipo = type;

            string filePath = @"C:\Users\riama\OneDrive\Ambiente de Trabalho\Osteovitae_Paciente\consultas.xlsx";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            int totalRows = xlRange.Rows.Count;
            int totalColumns = xlRange.Columns.Count;
            for (int rowCount = 2; rowCount <= totalRows; rowCount++)
            {
                var tempConsulta = new Consulta { data = Convert.ToString((xlRange.Cells[rowCount, 1] as Excel.Range).Text), hora = Convert.ToString((xlRange.Cells[rowCount, 2] as Excel.Range).Text), tipoconsulta = Convert.ToString((xlRange.Cells[rowCount, 4] as Excel.Range).Text) };
                ListaConsultas.Items.Add(tempConsulta);
            }
            xlWorkBook.Close();
            xlApp.Quit();

            /*Consulta con = new Consulta();
            con.data = "20-05-2020";
            con.hora = "11:00";
            con.tipoconsulta = "Osteopatia";
            ListaConsultas.Items.Add(con);

            Consulta cun = new Consulta();
            cun.data = "25-05-2020";
            cun.hora = "13:00";
            cun.tipoconsulta = "Osteopatia";
            ListaConsultas.Items.Add(cun);*/
        }

        // ----------------------- CONSULTAS ----------------------
        public class Consulta
        {
            public string data { get; set; }
            public string hora { get; set; }
            public string tipoconsulta { get; set; }
        }

        // ------------------------- MENU -------------------------
        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            Page3 menu = new Page3();
            this.NavigationService.Navigate(menu);
        }
        private void novaConsultaBtn_Click(object sender, RoutedEventArgs e)
        {
            Page4 novaconsulta = new Page4();
            this.NavigationService.Navigate(novaconsulta);
        }
        private void listaConsultasBtn_Click(object sender, RoutedEventArgs e)
        {
            Page5 listaconsultas = new Page5();
            this.NavigationService.Navigate(listaconsultas);
        }
        private void notificacoesBtn_Click(object sender, RoutedEventArgs e)
        {
            Page6 notificacoes = new Page6();
            this.NavigationService.Navigate(notificacoes);
        }
        private void tratamentosBtn_Click(object sender, RoutedEventArgs e)
        {
            Page7 tratamentos = new Page7();
            this.NavigationService.Navigate(tratamentos);
        }
        private void osteovitaeBtn_Click(object sender, RoutedEventArgs e)
        {
            Page8 osteovitae = new Page8();
            this.NavigationService.Navigate(osteovitae);
        }
        private void contaBtn_Click(object sender, RoutedEventArgs e)
        {
            Page9 conta = new Page9();
            this.NavigationService.Navigate(conta);
        }
    }
}
