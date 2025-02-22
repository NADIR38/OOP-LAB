using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale.models
{
    public class customer
    {
        public string cus_name;
        public string cus_pass;
        public string cus_email;
        public string cus_phone;
        public string cus_address;
        public customer(string cus_name, string cus_pass, string cus_email, string cus_phone, string cus_address)
        {
            this.cus_name = cus_name;
            this.cus_pass = cus_pass;
            this.cus_email = cus_email;
            this.cus_phone = cus_phone;
            this.cus_address = cus_address;
        }

    }
}
