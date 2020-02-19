using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        //member vars
        public string City { get; set; }
        public string Temperature { get; set; }
        public string HighTemperature { get; set; }
        public string Condition { get; set; }
        public string Precipitation { get; set; }

        public int currentDay;
        private string currentURL;
        private XmlDocument xmlDocument;
        public string condition;
        public int temperature;
        Random parentRandom;
        WeatherAPI weatherAPI;

        //constructor
        public Weather(Random rng)
        {
            parentRandom = rng;
            condition = GenerateRandomCondition();
            temperature = GenerateRandomTemperature();
        }
        public Weather(string city, int currentDay)
        {
            weatherAPI = new WeatherAPI(city,currentDay);
            City = city;
            this.currentDay = currentDay;
            //this.currentDay = currentDay;
            //weatherAPI.SetCurrentURL(city);
            //xmlDocument = GetXml(currentURL);
        }
        //member methods
        public void CheckWeather()
        {
            Temperature = weatherAPI.GetCurrentTemperature(currentDay);
            HighTemperature = weatherAPI.GetHighTemperature(currentDay);
            Condition = weatherAPI.GetDescription(currentDay);
            Precipitation = weatherAPI.GetPrecipitation(currentDay);
        }
        //private void SetCurrentURL(string location)
        //{
        //    currentURL = "http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&mode=xml&units=imperial&appid=90362ad8206360c9c86bbe50cf3a19b4";
        //}
        //private XmlDocument GetXml(string currentURL)
        //{
        //    using (WebClient client = new WebClient())
        //    {
        //        string xmlContent = client.DownloadString(currentURL);
        //        XmlDocument xmlDocument = new XmlDocument();
        //        xmlDocument.LoadXml(xmlContent);
        //        return xmlDocument;
        //    }
        //}
        //public string GetHighTemperature(int currentDay)
        //{
        //    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
        //    XmlNode xmlNode = xmlNodeList.Item(currentDay);
        //    xmlNode = xmlNode.FirstChild;
        //    xmlNode = xmlNode.NextSibling;
        //    xmlNode = xmlNode.NextSibling;
        //    xmlNode = xmlNode.NextSibling;
        //    xmlNode = xmlNode.NextSibling;
        //    XmlAttribute xmlAttribute = xmlNode.Attributes["max"];
        //    string highTemperature = xmlAttribute.Value;
        //    return highTemperature;
        //}
        //public string GetCurrentTemperature(int currentDay)
        //{
        //    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
        //    XmlNode xmlNode = xmlNodeList.Item(currentDay);
        //    xmlNode = xmlNode.FirstChild;
        //    xmlNode = xmlNode.NextSibling;
        //    xmlNode = xmlNode.NextSibling;
        //    xmlNode = xmlNode.NextSibling;
        //    xmlNode = xmlNode.NextSibling;

        //    XmlAttribute xmlAttribute = xmlNode.Attributes["value"];
        //    string currentTemperature = xmlAttribute.Value;
        //    return currentTemperature;
        //}
        //public string GetDescription(int currentDay)
        //{
        //    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
        //    XmlNode xmlNode = xmlNodeList.Item(currentDay);
        //    xmlNode = xmlNode.FirstChild;
        //    XmlAttribute xmlAttribute = xmlNode.Attributes["name"];
        //    string description = xmlAttribute.Value;
        //    return description;
        //}
        //public string GetPrecipitation(int currentDay)
        //{
        //    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
        //    XmlNode xmlNode = xmlNodeList.Item(currentDay);
        //    xmlNode = xmlNode.FirstChild;
        //    xmlNode = xmlNode.NextSibling;
        //    if (xmlNode.Attributes["type"] == null)
        //    {
        //        return "no precipitation";
        //    }
        //    else
        //    {
        //        XmlAttribute xmlAttribute = xmlNode.Attributes["type"];
        //        string precipitation = xmlAttribute.Value;
        //        return precipitation;
        //    }
        //}
        private string GenerateRandomCondition()
        {
            int randomValue = parentRandom.Next(1, 30);
            if (randomValue <= 5)
            {
                return "Thunderstorms";
            }
            else if (randomValue > 5 && randomValue < 15)
            {
                return "Mostly Sunny";
            }
            else
            {
                return "Hot and Dry";
            }
        }
        private int GenerateRandomTemperature()
        {
            if(condition=="Thunderstorms")
            {                
                return parentRandom.Next(45, 65);
            }
            else if (condition == "Mostly Sunny")
            {
                return parentRandom.Next(65, 80);
            }
            else
            {
                return parentRandom.Next(75, 99);
            }            
        }
    }
}
