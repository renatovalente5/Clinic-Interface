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

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Osteovitae_Paciente
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vXSYkw1G8Qc8CNhQSkTf68o4gYI3kqHen4ivBKFr",
            BasePath = "https://clinic-interface.firebaseio.com/"
        };

        IFirebaseClient client;

        //private string nome = "", apelido = "", mail = "", pass = "", contacto = "", tipo = "";

        public Page1()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);

            //if (client != null)
            //{
            //    MessageBox.Show("Connectionnnn is established");
            //}
        }
        private async void click_login(object sender, RoutedEventArgs e)
        {
            //string filePath = @"C:\Users\Asus\Desktop\3ano\IHC\Clinic_Interface\consultas.xlsx";
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //Excel.Range xlRange = xlWorkSheet.UsedRange;
            //int totalRows = xlRange.Rows.Count;
            //int totalColumns = xlRange.Columns.Count;
            //int p = 0;
            //for (int rowCount = 2; rowCount <= totalRows; rowCount++)
            //{
            //    mail = Convert.ToString((xlRange.Cells[rowCount, 4] as Excel.Range).Text);
            //    pass = Convert.ToString((xlRange.Cells[rowCount, 5] as Excel.Range).Text);
            //    if ((mail == emailTextBox.Text) && (pass == passwordTextBox.Text))
            //    {
            //        p = 1;
            //        nome = Convert.ToString((xlRange.Cells[rowCount, 1] as Excel.Range).Text);
            //        apelido = Convert.ToString((xlRange.Cells[rowCount, 2] as Excel.Range).Text);
            //        contacto = Convert.ToString((xlRange.Cells[rowCount, 3] as Excel.Range).Text);
            //        tipo = Convert.ToString((xlRange.Cells[rowCount, 6] as Excel.Range).Text);
            //        break;
            //    } else if ((Convert.ToString((xlRange.Cells[rowCount, 4] as Excel.Range).Text) == emailTextBox.Text) && (Convert.ToString((xlRange.Cells[rowCount, 5] as Excel.Range).Text) != passwordTextBox.Text))
            //    {
            //        p = 2;
            //        break;
            //    }
            //}
            //xlWorkBook.Close();
            //xlApp.Quit();
            //if (p == 2)
            //{
            //    passinvalida.Visibility = Visibility.Visible;
            //    logininvalido.Visibility = Visibility.Hidden;
            //} else if (p == 0)
            //{
            //    passinvalida.Visibility = Visibility.Hidden;
            //    logininvalido.Visibility = Visibility.Visible;
            //} else
            //{
            //    Page3 menu = new Page3(nome, apelido, mail, pass, contacto, tipo);
            //    this.NavigationService.Navigate(menu);
            //}


            FirebaseResponse response;
            Data obj;
            try
            {
                response = await client.GetTaskAsync("Information/" + telefoneTextBox.Text);
                obj = response.ResultAs<Data>();
            }
            catch (Exception)
            {
                passinvalida.Visibility = Visibility.Visible;
                throw;
            }

            if(passwordTextBox.Text == obj.Pass)
            {
                //MessageBox.Show("obj: ", obj.Contacto);
                // = obj.Email;
                //nome = obj.Nome;
                //contacto = obj.Contacto;
                //pass = obj.Pass;
                //apelido = obj.Apelido;
                //tipo = obj.Tipo;
                Page3 menu = new Page3(obj.Nome, obj.Apelido, obj.Email, obj.Pass, obj.Contacto, obj.Tipo);
                this.NavigationService.Navigate(menu);
            }
            //else
            //{
            //    passinvalida.Visibility = Visibility.Visible;
            //}
        }
        private void click_criarconta(object sender, RoutedEventArgs e)
        {
            Page2 criarconta = new Page2();
            this.NavigationService.Navigate(criarconta);
        }

    }
}
