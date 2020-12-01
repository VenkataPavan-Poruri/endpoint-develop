using System.Xml.Serialization;

namespace endpoint_models.Request
{

    [XmlRoot("SalePostRequest")]
    public class SalePostIncoming
    {
        [XmlElement("gatewayReference")]
        public string gatewayReference { get; set; }

        [XmlElement("authTypeCode")]
        public string authTypeCode { get; set; }

        [XmlElement("recurrenceFlag")]
        public string recurrenceFlag { get; set; }

        [XmlElement("authMode")]
        public string authMode { get; set; }

        [XmlElement("exemptionIndicator")]
        public string exemptionIndicator { get; set; }

        [XmlElement("money")]
        public money moneyXML { get; set; }

        [XmlElement("terminal")]
        public terminal terminalXML { get; set; }

        [XmlElement("card")]
        public card cardXML { get; set; }

        [XmlElement("fundsRecipient")]
        public fundsRecipient fundsRecipientXML { get; set; }

        [XmlElement("isDebtRepayTrans")]
        public string isDebtRepayTrans { get; set; }

        [XmlElement("ewallet")]
        public string ewallet { get; set; }

    }

    public class money
    {
        [XmlElement("amount")]
        public string amount { get; set; }

        [XmlElement("currencyCode")]
        public string currencyCode { get; set; }
    }
    public class terminal
    {
        [XmlElement("mid")]
        public string mid { get; set; }

        [XmlElement("tid")]
        public string tid { get; set; }
    }
    public class card
    {
        [XmlElement("cardNumber")]
        public string cardNumber { get; set; }

        [XmlElement("cvv")]
        public string cvv { get; set; }

        [XmlElement("cardDates")]
        public cardDates cardDatesXML { get; set; }

        [XmlElement("avsData")]
        public avsData avsDataXML { get; set; }
    }

    public class cardDates
    {
        [XmlElement("expiryDate")]
        public string expiryDate { get; set; }

        [XmlElement("issueDate")]
        public string issueDate { get; set; }
    }

    public class avsData
    {
        [XmlElement("address")]
        public string address { get; set; }

        [XmlElement("postalCode")]
        public string postalCode { get; set; }
    }
    public class fundsRecipient
    {
        [XmlElement("surname")]
        public string surname { get; set; }

        [XmlElement("birthDate")]
        public string birthDate { get; set; }

        [XmlElement("accountNumber")]
        public string accountNumber { get; set; }

        [XmlElement("postalCode")]
        public string postalCode { get; set; }
    }
}

