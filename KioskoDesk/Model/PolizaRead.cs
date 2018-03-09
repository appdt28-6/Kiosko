using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskoDesk.Model
{
    class PolizaRead
    {
        KoiscoEntities db = new KoiscoEntities();
        private IDataReader reader;
        private BindingSource dbind = new BindingSource();

        public BindingSource fillPoliza(int _poliid)
        {
           var reader = db.vis_POLIZA_INTEGRANTE.Where(w=>w.poli_id== _poliid).ToList();
            dbind.DataSource = reader;
            //reader.Close();
            return (dbind);
        }
    }
}
