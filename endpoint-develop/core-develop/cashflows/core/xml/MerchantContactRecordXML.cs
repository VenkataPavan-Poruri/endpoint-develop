using System;
using System.Collections.Generic;
using System.Text;

namespace core_develop.cashflows.core.xml
{
    public class MerchantContactRecordXML
    {
        //private string street;
        //private string city;
        //private string state;
        //private string postalCode;
        //private string customerServicePhoneNumber;
        //private string customerServiceEmail;

        public string street;
        public string city;
        public string state;
        public string postalCode;
        public string customerServicePhoneNumber;
        public string customerServiceEmail;
        //public MerchantContactRecordXML(string street, string city, string state,
        //                                 string postalCode, string customerServicePhoneNumber,
        //                                 string customerServiceEmail)
        //{
        //    this.street = street;
        //    this.city = city;
        //    this.state = state;
        //    this.postalCode = postalCode;
        //    this.customerServicePhoneNumber = customerServicePhoneNumber;
        //    this.customerServiceEmail = customerServiceEmail;
        //}

        public string getStreet()
        {
            return street;
        }

        public string getCity()
        {
            return city;
        }

        public string getState()
        {
            return state;
        }

        public string getPostalCode()
        {
            return postalCode;
        }

        public String getCustomerServicePhoneNumber()
        {
            return customerServicePhoneNumber;
        }

        public String getCustomerServiceEmail()
        {
            return customerServiceEmail;
        }

    }
}
