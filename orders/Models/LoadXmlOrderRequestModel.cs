﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace orders.Models
{
    [XmlRoot(ElementName = "country")]
    public class Country
    {
        [XmlElement(ElementName = "geo")]
        public string Geo { get; set; }
    }

    [XmlRoot(ElementName = "billingaddress")]
    public class Billingaddress
    {
        [XmlElement(ElementName = "billemail")]
        public string Billemail { get; set; }
        [XmlElement(ElementName = "billfname")]
        public string Billfname { get; set; }
        [XmlElement(ElementName = "billstreet")]
        public string Billstreet { get; set; }
        [XmlElement(ElementName = "billstreetnr")]
        public string Billstreetnr { get; set; }
        [XmlElement(ElementName = "billcity")]
        public string Billcity { get; set; }
        [XmlElement(ElementName = "country")]
        public Country Country { get; set; }
        [XmlElement(ElementName = "billzip")]
        public string Billzip { get; set; }
    }

    [XmlRoot(ElementName = "payment")]
    public class Payment
    {
        [XmlElement(ElementName = "method-name")]
        public string Methodname { get; set; }
        [XmlElement(ElementName = "amount")]
        public string Amount { get; set; }
    }

    [XmlRoot(ElementName = "payments")]
    public class Payments
    {
        [XmlElement(ElementName = "payment")]
        public Payment Payment { get; set; }
    }

    [XmlRoot(ElementName = "orderarticle")]
    public class Orderarticle
    {
        [XmlElement(ElementName = "artnum")]
        public string Artnum { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "amount")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "brutprice")]
        public string Brutprice { get; set; }
    }

    [XmlRoot(ElementName = "articles")]
    public class Articles
    {
        [XmlElement(ElementName = "orderarticle")]
        public List<Orderarticle> Orderarticle { get; set; }
    }

    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "oxid")]
        public string Oxid { get; set; }
        [XmlElement(ElementName = "orderdate")]
        public string Orderdate { get; set; }
        [XmlElement(ElementName = "billingaddress")]
        public Billingaddress Billingaddress { get; set; }
        [XmlElement(ElementName = "payments")]
        public Payments Payments { get; set; }
        [XmlElement(ElementName = "articles")]
        public Articles Articles { get; set; }
    }

    [XmlRoot(ElementName = "orders")]
    public class Orders
    {
        [XmlElement(ElementName = "order")]
        public Order Order { get; set; }
    }

    [XmlRoot(ElementName = "LoadXmlOrderRequest")]
    public class LoadXmlOrderRequest
    {
        [XmlElement(ElementName = "orders")]
        public Orders Orders { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }
}