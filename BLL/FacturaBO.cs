using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class FacturaBO
    {
        public static void Create(VentaEntity venta)
        {
                FacturasDAL.Create(venta);
        }
    }
}
