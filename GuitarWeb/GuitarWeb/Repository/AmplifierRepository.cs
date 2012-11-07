using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using GuitarWeb.Interfaces;
using GuitarWeb.Models;

namespace GuitarWeb.Repository
{
    public class AmplifierRepository : IAmplifierRepository
    {
        public List<Amplifier> GetAmplifiers()
        {
            var serializer = new XmlSerializer(typeof(List<Amplifier>));
            TextReader tr = new StreamReader(@"d:\guitarweb\amplifiers.xml");
            var amplifiers = (List<Amplifier>)serializer.Deserialize(tr);
            tr.Close();

            return amplifiers;
        }

        public void SaveAmplifiers(List<Amplifier> amplifiers)
        {
            var serializer = new XmlSerializer(amplifiers.GetType());
            TextWriter tw = new StreamWriter(@"d:\guitarweb\amplifiers.xml");
            serializer.Serialize(tw, amplifiers);
            tw.Close(); 
        }

        public Amplifier GeAmplifierById(string regNumber)
        {
            var amplifiers = GetAmplifiers();
            
            return amplifiers.Where(a => a.RegNumber == regNumber).FirstOrDefault();
        }
    }
}