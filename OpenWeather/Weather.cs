using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Weather_Forecast.OpenWeather
{
    class Weather
    {
       public string description;
       public string icon;
       public Bitmap Icon
        {
            get
            {
                return new Bitmap(Image.FromFile(@"Icons/" + icon + ".png"));
            }
        }

    }
}
