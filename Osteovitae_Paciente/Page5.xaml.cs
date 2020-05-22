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
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace Osteovitae_Paciente
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

        IFirebaseClient client2;

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

            Page5_help();

            //string filePath = @"C:\Users\Asus\Desktop\3ano\IHC\Clinic_Interface\consultas.xlsx";
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            //Excel.Range xlRange = xlWorkSheet.UsedRange;
            //int totalRows = xlRange.Rows.Count;
            //int totalColumns = xlRange.Columns.Count;
            //for (int rowCount = 2; rowCount <= totalRows; rowCount++)
            //{
            //    var tempConsulta = new Consulta { data = Convert.ToString((xlRange.Cells[rowCount, 1] as Excel.Range).Text), hora = Convert.ToString((xlRange.Cells[rowCount, 2] as Excel.Range).Text), tipoconsulta = Convert.ToString((xlRange.Cells[rowCount, 4] as Excel.Range).Text) };
            //    ListaConsultas.Items.Add(tempConsulta);
            //}
            //xlWorkBook.Close();
            //xlApp.Quit();

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
        
        private async void Page5_help()
        {
            client2 = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client2.GetTaskAsync("ConsultasMarcadas/" + contacto + "/numero"); ;
            Numero num = response.ResultAs<Numero>();

            for (int i = 1; i <= Int32.Parse(num._numero); i++)
            {
                var consulta = "consulta" + i;
                FirebaseResponse response2 = await client2.GetTaskAsync("ConsultasMarcadas/"+ contacto +"/" + consulta);
                Consultas obj = response2.ResultAs<Consultas>();
                var tempConsulta = new Consulta { data = obj.Data, hora = obj.Hora, tipoconsulta = obj.TipoConsulta };
                ListaConsultas.Items.Add(tempConsulta);
            }
        }

        // ----------------------- CONSULTAS ----------------------
        
        public class Consulta
        {
            public String data { get; set; }
            public String hora { get; set; }
            public String tipoconsulta { get; set; }
        }

        // ------------------------- MENU -------------------------
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
