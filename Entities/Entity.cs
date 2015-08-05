using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Entity : IEntity
    {
        public Entity()
            : base()
        {

        }

        [XmlAttribute]
        public string ID { get; set; }

        public override string ToString()
        {
            return ID;
        }
    }
}
