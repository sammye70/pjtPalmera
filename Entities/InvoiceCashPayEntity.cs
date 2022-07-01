using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class InvoiceCashPayEntity
    {
        private int id_pay;
        private int id_invoice;
        private decimal amount;
        private DateTime created;
        private int createby;
        private string request_number;

        public string GetRequest_number()
        {
            return request_number;
        }

        public void SetRequest_number(string value)
        {
            request_number = value;
        }

        public InvoiceCashPayEntity() 
        {
        }

        //
        public int GetId_pay()
        {
            return id_pay;
        }

        //
        public void SetId_pay(int value)
        {
            id_pay = value;
        }

        public int GetId_invoice()
        {
            return id_invoice;
        }

        public void SetId_invoice(int value)
        {
            id_invoice = value;
        }

        public decimal GetAmount()
        {
            return amount;
        }

        public void SetAmount(decimal value)
        {
            amount = value;
        }

        public DateTime GetCreated()
        {
            return created;
        }

        public void SetCreated(DateTime value)
        {
            created = value;
        }

        public int GetCreateby()
        {
            return createby;
        }

        public void SetCreateby(int value)
        {
            createby = value;
        }
    }
}
