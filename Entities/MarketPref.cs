using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    [XmlRoot("Market")]
    public class MarketPrefFile : IPrefFile
    {
        public MarketPrefFile()
        {

        }
        public Version Version { get; set; }
        [XmlElement(ElementName = "Preferences")]
        public Preferences Preferences { get; set; }
    }
}
