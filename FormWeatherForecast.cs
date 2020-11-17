using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Windows.Devices.Geolocation;
using GoogleMaps.LocationServices;
using Weather_Forecast.OpenWeather;
using System.Globalization;






namespace Weather_Forecast
{
    public partial class FormWeatherForecast : Form
    {
        public FormWeatherForecast()
        {
            InitializeComponent();
        }

        private void ButtonSearch(object sender, EventArgs e)
        {
            PressButtonSearch();
        }

        private void KeyDownEnterForm(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PressButtonSearch();
            }
        }

        private void KeyDownEnterToolbox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PressButtonSearch();
            }
        }
        public void PressButtonSearch()
        {
            string userText = toolStripTextBox1.Text;
            string linejson = GetResponse($"https://geocode.xyz/?scantext=/{userText}&json=1");
            Geocoding.Geocoding geocodingLattLongt = JsonConvert.DeserializeObject<Geocoding.Geocoding>(linejson);
            if ((geocodingLattLongt.latt != 0) & (geocodingLattLongt.longt != 0))
            {
                linejson = GetResponse("http://api.openweathermap.org/data/2.5/weather?lat=" + geocodingLattLongt.latt + "&lon=" + geocodingLattLongt.longt + "&appid=ce392d178e761c837d019512f935da12");
                OpenWeather.OpenWeather geocodingWeather = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(linejson);
                groupBox1.Visible = true;
                groupBox1.Text = ("Weather in " + geocodingWeather.name);
                label1.Text = (Math.Round(geocodingWeather.main.temp, 2)).ToString("0.##") + " C°";
                label2.Text = "Ощущается как " + (Math.Round(geocodingWeather.main.feels_like, 2)).ToString("0.##") + " C°";
                label3.Text = "Влажность " + (Math.Round(geocodingWeather.main.humidity)).ToString("0.##") + " %";
                label5.Text = geocodingWeather.weather[0].description;
                panel1.BackgroundImage = geocodingWeather.weather[0].Icon;
            }
            else
            {
                MessageBox.Show("Вы ввели некорректный адрес, \nпопробуйте еще раз!");
            }
        }
        public string GetResponse(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                string line = null;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader readr = new StreamReader(stream))
                    {
                        line = readr.ReadLine();
                    }
                }
                response.Close();
                return line;
            }
            catch
            {
                return GetResponse(url);
            }
        }
    }
}
