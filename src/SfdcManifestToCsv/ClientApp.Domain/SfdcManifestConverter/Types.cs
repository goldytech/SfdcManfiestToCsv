﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace ClientApp.Domain.SfdcManifestConverter
{
    [XmlRoot(ElementName = "types", Namespace = "http://soap.sforce.com/2006/04/metadata")]
    public class Types
    {
        [XmlElement(ElementName = "members", Namespace = "http://soap.sforce.com/2006/04/metadata")]
        public List<string> Members { get; set; }
        [XmlElement(ElementName = "name", Namespace = "http://soap.sforce.com/2006/04/metadata")]
        public string Name { get; set; }
    }
}