using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Entities
{
    public class Preference : Entity, IPreference
    {
        public Preference()
        {

        }

        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public string DefaultValue { get; set; }

        [XmlElement(ElementName = "Name")]
        public Entity Name { get; set; }

        public Value[] Values { get; set; }
    }
}
