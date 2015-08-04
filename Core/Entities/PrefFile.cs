﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Entities
{
    [XmlRoot("Root")]
    public class PrefFile
    {
        public PrefFile()
        {

        }
        public Version Version { get; set; }
        [XmlElement(ElementName = "Preferences")]
        public Preferences Preferences { get; set; }
    }

    public class Preferences
    {
        public Preferences()
        {

        }
        [XmlElement(ElementName = "Pref")]
        public List<Preference> Prefs { get; set; }
    }

    public class Version
    {
        [XmlAttribute]
        public string Major { get; set; }
        [XmlAttribute]
        public string Minor { get; set; }
    }
}
