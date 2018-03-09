using KioskoDesk.Model;
using RawPrint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskoDesk
{
    public partial class PolizaResumen : Form
    {
        KoiscoEntities db = new KoiscoEntities();
        int poliza;
        PolizaRead lee = new PolizaRead();


        public PolizaResumen(int _poliza)
        {
            poliza = _poliza;
            //btnAfiliacion.Hide();
            
            InitializeComponent();

            grdPoliza.DataSource = lee.fillPoliza(poliza);

            var datosgenerales= db.vis_POLIZA_INTEGRANTE.Where(w => w.poli_id == poliza && w.poli_tipo == 1).ToList();

            lblNombre.Text = datosgenerales[0].poli_integrante;
            lblCURP.Text = datosgenerales[0].poli_integrante;
            lblDomicilio.Text = datosgenerales[0].poli_integrante;
            lblFecha.Text = datosgenerales[0].poli_vigencia.ToString();
            //si la fecha < a la fecha de la base--- ocultar boton

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    streamToPrint = new StreamReader
            //       ("C:\\texto.txt");
            //    try
            //    {
            //        printFont = new Font("Arial", 10);
            //        PrintDocument pd = new PrintDocument();
            //        pd.PrintPage += new PrintPageEventHandler
            //           (this.pd_PrintPage);
            //        pd.Print();
            //    }
            //    finally
            //    {
            //        streamToPrint.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}

            string Filepath = @"C:\polizaejemplo.pdf";
            // The name of the PDF that will be printed (just to be shown in the print queue)
            string Filename = "polizaejemplo.pdf";
            // The name of the printer that you want to use
            // Note: Check step 1 from the B alternative to see how to list
            // the names of all the available printers with C#
            string PrinterName = "Canon G3000 series Printer";

            // Create an instance of the Printer
            IPrinter printer = new Printer();
            try {
            // Print the file
            printer.PrintRawFile(PrinterName, Filepath, Filename);
                //printer.PrintRawStream
            }
            catch(Exception q) { }
        }

        private void btnAfiliacion_Click(object sender, EventArgs e)
        {
            ReafiliacionForm reaf = new ReafiliacionForm();
            reaf.Show();

            
        }



        //private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    float linesPerPage = 0;
        //    float yPos = 0;
        //    int count = 0;
        //    float leftMargin = ev.MarginBounds.Left;
        //    float topMargin = ev.MarginBounds.Top;
        //    string line = null;

        //    // Calculate the number of lines per page.
        //    linesPerPage = ev.MarginBounds.Height /
        //       printFont.GetHeight(ev.Graphics);

        //    // Print each line of the file.
        //    while (count < linesPerPage &&
        //       ((line = streamToPrint.ReadLine()) != null))
        //    {
        //        yPos = topMargin + (count *
        //           printFont.GetHeight(ev.Graphics));
        //        ev.Graphics.DrawString(line, printFont, Brushes.Black,
        //           leftMargin, yPos, new StringFormat());
        //        count++;
        //    }

        //    // If more lines exist, print another page.
        //    if (line != null)
        //        ev.HasMorePages = true;
        //    else
        //        ev.HasMorePages = false;
        //}



    }
}
