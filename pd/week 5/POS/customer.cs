using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class customer
    {
        public string cus_name; 
        public string cus_email; 
        public string cus_phone;
        public string cus_address; 
        public string cus_password;
   public customer(string cus_name, string cus_email, string cus_phone, string cus_address, string cus_password)
        {
            this.cus_name = cus_name;
            this.cus_email = cus_email;
            this.cus_phone = cus_phone;
            this.cus_address = cus_address;
            this.cus_password = cus_password;
        }
        public static customer Parse(string data)
        {
            string[] parts = data.Split(',');
            return new customer(
                parts[0],
                parts[1],
                parts[2],
                parts[3],
                parts[4]
            );
        }

    }
}
