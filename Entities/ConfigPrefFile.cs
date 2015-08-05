using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    [XmlRoot("Root")]
    public class ConfigPrefFile : IPrefFile
    {
        public ConfigPrefFile()
        {

        }
        public Version Version { get; set; }
        [XmlElement(ElementName = "Preferences")]
        public Preferences Preferences { get; set; }
    }
}
