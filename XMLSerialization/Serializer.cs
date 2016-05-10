using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;


namespace XMLSerialization
{
    public static class PASerializer
    {   
        public static void SerializeToXML(List<Point> pt)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Point>));
            TextWriter textWriter = new StreamWriter(@"./pointarray.xml");
            serializer.Serialize(textWriter, pt);
            textWriter.Close();
        }
        public static List<Point> DeserializeFromXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Point>));
            TextReader textReader = new StreamReader(@"./pointarray.xml");

            List<Point> pt = (List<Point>)deserializer.Deserialize(textReader);
            textReader.Close();

            return pt;
        }
    }
}
