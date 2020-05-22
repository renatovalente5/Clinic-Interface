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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;

        private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "";

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
        }
        private void readExcelFile()
        {
            // READ EXCEL FILE
            string filePath = @"C:\Users\Asus\Desktop\3ano\IHC\Clinic_Interface\consultas.xlsx";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            int totalRows = xlRange.Rows.Count;
            int totalColumns = xlRange.Columns.Count;
            string value1, value2, value3, value4, value5;
            for (int rowCount = 2; rowCount <= totalRows; rowCount++)
            {
                // row rowCount - column 1
                value1 = Convert.ToString((xlRange.Cells[rowCount, 1] as Excel.Range).Text);
                // row rowCount - column 2
                value2 = Convert.ToString((xlRange.Cells[rowCount, 2] as Excel.Range).Text);
                // row rowCount - column 3
                value3 = Convert.ToString((xlRange.Cells[rowCount, 3] as Excel.Range).Text);
                // row rowCount - column 4
                value4 = Convert.ToString((xlRange.Cells[rowCount, 4] as Excel.Range).Text);
                // row rowCount - column 5
                value5 = Convert.ToString((xlRange.Cells[rowCount, 5] as Excel.Range).Text);
                MessageBox.Show(value1 + "\t" + value2 + "\t" + value3 + "\t" + value4 + "\t" + value5);
            }
            xlWorkBook.Close();
            xlApp.Quit();

            // READ EXCEL FILE
            /*Excel.Application xlApp2 = new Excel.Application();
            //object misValue = System.Reflection.Missing.Value;
            Excel.Workbook xlWorkBook2 = xlApp2.Workbooks.Add(filePath);
            Excel.Worksheet xlWorkSheet2 = (Excel.Worksheet)xlWorkBook2.Worksheets.get_Item(2);
            xlWorkSheet.Cells[totalRows, 1] = "22/05/2020";
            xlWorkSheet.Cells[totalRows, 2] = "11:00";
            xlWorkSheet.Cells[totalRows, 3] = "Manuel Martins";
            xlWorkSheet.Cells[totalRows, 4] = "Osteopatia";
            xlWorkSheet.Cells[totalRows, 5] = "Médico";
            xlWorkBook2.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbook);
            xlWorkBook2.Close();
            xlApp2.Quit();

            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets.Add();

                excelWorksheet.Cells[totalRows, 1] = "22/05/2020";
                excelWorksheet.Cells[totalRows, 2] = "11:00";
                excelWorksheet.Cells[totalRows, 3] = "Manuel Martins";
                excelWorksheet.Cells[totalRows, 4] = "Osteopatia";
                excelWorksheet.Cells[totalRows, 5] = "Médico";

                excelApp.ActiveWorkbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal);

                excelWorkbook.Close();
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorksheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkbook);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }*/
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

        private async void click_marcar(object sender, RoutedEventArgs e)
        {
            //readExcelFile();
            Consultas consulta = new Consultas();
            consulta.Medico = MedicoText.Text;
            consulta.TipoConsulta = TipoConsultaText.Text;
            consulta.Data = diaTextBox.Text + "-" + mesTextBox.Text + "-"+ anoTextBox.Text;
            consulta.Hora = horaTextBox.Text + ":" + minutosTextBox.Text;

            //Falta meter aqui um erro para o caso de o Contacto já existir

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


            Page5 listaconsultas = new Page5(nome, apelido, mail, pass, contacto, tipo);
            this.NavigationService.Navigate(listaconsultas);



        }
    }
}
