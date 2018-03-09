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
        private PrintDocument printDocument1 = new PrintDocument();
       

        public PolizaResumen(int _poliza)
        {
            poliza = _poliza;
            //btnAfiliacion.Hide();

            InitializeComponent();

            grdPoliza.DataSource = lee.fillPoliza(poliza);

            var datosgenerales = db.vis_POLIZA_INTEGRANTE.Where(w => w.poli_id == poliza && w.poli_tipo == 1).ToList();

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
            SendToPrinter();
            printDocument1.Print();
        }

        private void btnAfiliacion_Click(object sender, EventArgs e)
        {
            ReafiliacionForm reaf = new ReafiliacionForm(poliza);
            reaf.Show();


        }

        private void SendToPrinter()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";                          // Seleccionar el programa para imprimir PDF por defecto
            info.FileName = @"C:\polizaejemplo.pdf";         // Ruta hacia el fichero que quieres imprimir
            info.CreateNoWindow = true;                   // Hacerlo sin mostrar ventana
            info.WindowStyle = ProcessWindowStyle.Hidden; // Y de forma oculta
            Process p = new Process();
            p.StartInfo = info;
            p.Start();  // Lanza el proceso

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(10);          // Espera 3 segundos

            if (false == p.CloseMainWindow())
                p.Kill();
        }

    }
}
