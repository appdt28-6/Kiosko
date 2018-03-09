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
    public partial class ConsultaForm : Form
    {
        KoiscoEntities db = new KoiscoEntities();
        public ConsultaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poliza = textBox1.Text;
            var data = db.POLIZAS.Where(w => w.poli_folio == poliza).ToList();
            var id =  data[0].poli_id;
            var fecha = data[0].poli_vigencia;

            PolizaResumen consul = new PolizaResumen(id);
            consul.Show();


        }
    }
}
