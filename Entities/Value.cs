using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Value : Entity, IValue
    {
        public Value()
            : base()
        {

        }

        [XmlElement]
        public Entity Name { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
