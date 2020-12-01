using System;

namespace endpoint_service.service.xml
{
    public class CardDatesXML
    {
        public string expiryDate;
        public string issueDate;

        //public CardDatesXML( string expiryDate,  string issueDate)
        //{
        //    this.expiryDate = expiryDate;
        //    this.issueDate = issueDate;
        //}

        public string getExpriryDate()
        {
            return expiryDate;
        }

        public string getIssueDate()
        {
            return issueDate;
        }

        
    //public string toString()
    //    {
    //        return new ToStringBuilder(this).
    //               append("expiryDate", expiryDate).
    //               append("issueDate", issueDate).
    //               toString();
    //    }

    }
}
