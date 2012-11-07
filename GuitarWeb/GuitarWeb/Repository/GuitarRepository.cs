using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using GuitarWeb.Interfaces;
using GuitarWeb.Models;

namespace GuitarWeb.Repository
{
    public class GuitarRepository : IGuitarRepository
    {

        private const string Path = @"C:\Sandbox\GuitarWeb\GuitarWeb\guitars.xml";
        public Guitar GetGuitarById(string regNumber)
        {
            var guitars = GetGuitars();

            return guitars.Where(g => g.RegNumber == regNumber).FirstOrDefault();
        }

        public List<Guitar> GetGuitars()
        {
            if(! File.Exists(Path)) return new List<Guitar>();

            var serializer = new XmlSerializer(typeof(List<Guitar>));
            TextReader tr = new StreamReader(Path);
            var guitars = (List<Guitar>)serializer.Deserialize(tr);
            tr.Close();

            return guitars;
        }

        public void SaveGuitars(List<Guitar> guitars)
        {
            var serializer = new XmlSerializer(guitars.GetType());
            TextWriter tw = new StreamWriter(Path);
            serializer.Serialize(tw, guitars);
            tw.Close(); 
        }
    }
}