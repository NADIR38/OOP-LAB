using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.models
{
    public class car
    {
        public string car_name;
        public string car_model;
        public string car_color;
        public float price;
        public car(string car_name, string car_model, string car_color, float price)
        {
            this.car_name = car_name;
            this.car_model = car_model;
            this.car_color = car_color;
            this.price = price;
        }
    }
}
