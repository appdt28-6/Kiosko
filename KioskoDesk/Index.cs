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
    public partial class Index : Form
    {
        KoiscoEntities db = new KoiscoEntities();
        public Index()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

            ConsultaForm consul = new ConsultaForm();
            consul.Show();
           // this.Close();

        }
    }
}
