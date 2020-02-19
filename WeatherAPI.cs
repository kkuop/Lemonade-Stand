using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using Newtonsoft.Json;

namespace LemonadeStand_3DayStarter
{
    class WeatherAPI
    {
        //member vars
        private string currentURL;
        //constructor
        public WeatherAPI(string city)
        {

        }
        //member methods
        private void SetCurrentURL(string location)
        {
            currentURL = "http://api.openweathermap.org/data/2.5/weather?q=" + location + "&mode=xml&units=imperial&appid=90362ad8206360c9c86bbe50cf3a19b4";
        }
        private XmlDocument GetXml(string currentURL)
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(currentURL);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            }
        }
    }
}
