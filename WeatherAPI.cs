﻿using System;
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
        private XmlDocument xmlDocument;

        //constructor
        public WeatherAPI(string city)
        {
            SetCurrentURL(city);
            xmlDocument = GetXml(currentURL);
        }
        //member methods
        private void SetCurrentURL(string location)
        {
            currentURL = "http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&mode=xml&units=imperial&appid=90362ad8206360c9c86bbe50cf3a19b4";
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
        public string GetHighTemperature(int currentDay)
        {
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
            XmlNode xmlNode = xmlNodeList.Item(currentDay);
            xmlNode = xmlNode.FirstChild;
            xmlNode = xmlNode.NextSibling;
            xmlNode = xmlNode.NextSibling;
            xmlNode = xmlNode.NextSibling;
            xmlNode = xmlNode.NextSibling;
            XmlAttribute xmlAttribute = xmlNode.Attributes["max"];
            string highTemperature = xmlAttribute.Value;
            return highTemperature;

            //XmlNode xmlNode = xmlDocument.SelectSingleNode("//temperature");
            //XmlAttribute xmlAttribute = xmlNode.Attributes["value"];
            //string temperature = xmlAttribute.Value;
            //return temperature;
        }
        public string GetCurrentTemperature (int currentDay)
        {
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
            XmlNode xmlNode = xmlNodeList.Item(currentDay);
            xmlNode = xmlNode.FirstChild;
            xmlNode = xmlNode.NextSibling;
            xmlNode = xmlNode.NextSibling;
            xmlNode = xmlNode.NextSibling;
            xmlNode = xmlNode.NextSibling;
            
            XmlAttribute xmlAttribute = xmlNode.Attributes["value"];
            string currentTemperature = xmlAttribute.Value;
            return currentTemperature;
        }
        public string GetDescription(int currentDay)
        {
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
            XmlNode xmlNode = xmlNodeList.Item(currentDay);
            xmlNode = xmlNode.FirstChild;
            XmlAttribute xmlAttribute = xmlNode.Attributes["name"];
            string description = xmlAttribute.Value;
            return description;

            //XmlNode xmlNode = xmlDocument.SelectSingleNode("//weather");
            //XmlAttribute xmlAttribute = xmlNode.Attributes["value"];
            //XmlNode xmlNode1 = xmlDocument.SelectSingleNode("//speed");
            //XmlAttribute xmlAttribute1 = xmlNode1.Attributes["name"];
            //string description = xmlAttribute.Value + " | " +xmlAttribute1.Value;
            //return description;
        }
        public string GetPrecipitation(int currentDay)
        {
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//time");
            XmlNode xmlNode = xmlNodeList.Item(currentDay);
            xmlNode = xmlNode.FirstChild;
            xmlNode = xmlNode.NextSibling;
            if (xmlNode.Attributes["type"] == null) 
            { 
                return "no precipitation";
            }
            else
            {
                XmlAttribute xmlAttribute = xmlNode.Attributes["type"];
                string precipitation = xmlAttribute.Value;
                return precipitation;
            }
        }
    }
}
