using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pjPalmera.Entities
{
    public class EnterpriseSettings
    {
        private String name;
        private String address;
        private String phonenumber;
        private String phonenumber2;
        private String rnc;
        private String slogam;



        public String Name
        {
            set { name = "Farmacia CRM"; }
            get { return name; }
        }


        public String Address
        {
            set { address = "C/9, #15, Las Escobas, Jima Arriba"; }
            get { return address; }
        }

        public String phoneNumber0
        {
            set { phonenumber = "809-954-9952"; }
            get { return phonenumber; }
        }

        public String phoneNumber1
        {
            set { phonenumber2 = "809-851-2775"; }
            get { return phonenumber2; }
        }


        public String rNc
        {
            set { rnc = "80700148433"; }
            get { return rnc; }
        }

        
        public String sLogan
        {
            set { slogam = "Donde tu Salud es Nuestra Prioridad"; }
            get { return slogam; }
        }

    }
}
