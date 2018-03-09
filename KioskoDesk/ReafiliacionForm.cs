using KioskoDesk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskoDesk
{
    public partial class ReafiliacionForm : Form
    {
        KoiscoEntities db = new KoiscoEntities();
        int poliza = 0;
        public ReafiliacionForm(int _poliza)
        {
            poliza = _poliza;
            InitializeComponent();
            var datosgenerales = db.vis_POLIZA_INTEGRANTE.Where(w => w.poli_id == poliza && w.poli_tipo == 1).ToList();

            lblNombre.Text = datosgenerales[0].poli_integrante;
            lblCURP.Text = datosgenerales[0].poli_integrante;
            lblDomicilio.Text = datosgenerales[0].poli_integrante;
            lblFecha.Text = datosgenerales[0].poli_vigencia.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TitualarResumen consul = new TitualarResumen(poliza);
            consul.Show();
        }
    }
}
