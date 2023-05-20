using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{

    public class OpServices
    {
        /// <summary>
        /// Calculate Cash in Box After Open and After Close 
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
        public decimal cuadre(decimal efectivo, decimal venta, decimal pays)
        {
            decimal t_faltante, tcash;

            tcash = venta + pays;
            t_faltante = efectivo - tcash;
            
            if(efectivo >=  tcash)
            {
                t_faltante = 0M;
            }

            return t_faltante;
        }

        /// <summary>
        ///Product Generator Code Number
        /// </summary>
        public string NumberGeneratorCode()
        {
            //Comment stament to genere code product 13 characters
            // uncomment stament to genere code product 6 characters

            //long NumberRandom1 = new Random().Next(123456789, 987654321);
            long NumberRandom1 = new Random().Next(123456, 654321);
            long NumberRandom2 = new Random().Next(1234, 4321);
            //string NumberRandom = Convert.ToString(NumberRandom1) + Convert.ToString(NumberRandom2);
            string NumberRandom = Convert.ToString(NumberRandom1);
            return NumberRandom;
        }


        /// <summary>
        /// Calculate Price for Product
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public decimal SetPrice(decimal cost, decimal income)
        {
            decimal pg, pv;
            var c = cost;
            var p = income;

            pg = (c * p) / 100;
            pv = c + pg;

            return pv;
        }


        /// <summary>
        /// Refrest Sub Amount after remove item from the list
        /// </summary>
        /// <returns>diferencia</returns>
        public static decimal UpdateSubAmount(decimal subtotal, decimal amount_item) 
        {
            decimal different;

            different = subtotal - amount_item;

            return different;
        }

        /// <summary>
        /// Refrest  Amount after remove item from the list
        /// </summary>
        /// <returns></returns>
        public static decimal UpdateAmount(decimal diferencia)
        {
            decimal pdescuento, rdescuento;

            pdescuento = (diferencia * 10) / 100;
            rdescuento = diferencia - pdescuento;

            return rdescuento;
        }

        /// <summary>
        /// Refrest  Descount Amount after remove item from the list
        /// </summary>
        /// <returns></returns>
        public static decimal UpdateDescountAmount(decimal diferencia)
        {
            decimal pdescuento;
            
            pdescuento = (diferencia * 10) / 100;

            return pdescuento;
        }
    }
}
