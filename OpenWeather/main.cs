using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Forecast.OpenWeather
{
    class main
    {
        public double humidity;
        private double _temp;
        public double temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15;
            }
        }
        private double _feels_like;
        public double feels_like
        {
            get
            {
                return _feels_like;
            }
            set
            {
                _feels_like = value - 273.15;
            }
        }
       

        
    }
}
