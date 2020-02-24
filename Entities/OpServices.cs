using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
  public  class OpServices
    {
        /// <summary>
        /// Calculate Cash in Box After Open
        /// </summary>
        /// <param name="one"></param>
        /// <param name="cinco"></param>
        /// <param name="diez"></param>
        /// <param name="venticinco"></param>
        /// <param name="cincuenta"></param>
        /// <param name="cien"></param>
        /// <param name="doscientos"></param>
        /// <param name="quinientos"></param>
        /// <param name="mil"></param>
        /// <param name="dosmil"></param>
        /// <returns></returns>
        public int monto(int one, int cinco, int diez, int venticinco, int cincuenta, int cien, int doscientos, int quinientos, int mil, int dosmil)
        {
            int total, t_one, t_cinco, t_diez, t_venticinco, t_cincuenta, t_cien, t_doscientos, t_quinientos, t_mil, t_dosmil;

            t_one = one * 1;
            t_cinco = cinco * 5;
            t_diez = diez * 10;
            t_venticinco = venticinco * 25;
            t_cincuenta = cincuenta * 50;
            t_cien = cien * 100;
            t_doscientos = doscientos * 200;
            t_quinientos = quinientos * 500;
            t_mil = mil * 1000;
            t_dosmil = dosmil * 2000;

            total = t_one + t_cinco + t_diez + t_venticinco + t_cincuenta + t_cien + t_doscientos + t_quinientos + t_mil + t_dosmil;

            return total;
        }

        /// <summary>
        /// Calculate Amount Missing in Box
        /// </summary>
        /// <param name="efectivo"></param>
        /// <param name="venta"></param>
        /// <returns></returns>
        public decimal cuadre(decimal efectivo, decimal venta)
        {
            decimal t_faltante;

            t_faltante = efectivo - venta;

            return t_faltante;
        }

    }
}
