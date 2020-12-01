using System;

namespace endpoint_service.service.xml
{
    public class FundsRecipientXML
    {
        //private string surname;
        //private DateTime birthDate;
        //private string accountNumber;
        //private string postalCode;
        public string surname;
        public DateTime birthDate;
        public string accountNumber;
        public string postalCode;

        //public FundsRecipientXML(string surname,
        //                DateTime birthDate, string accountNumber,
        //                string postalCode)
        //{
        //    this.surname = surname;
        //    this.birthDate = birthDate;
        //    this.accountNumber = accountNumber;
        //    this.postalCode = postalCode;
        //}


        public string getSurname()
        {
            return surname;
        }


        public DateTime getBirthDate()
        {
            return birthDate;
        }


        public string getAccountNumber()
        {
            return accountNumber;
        }


        public string getPostalCode()
        {
            return postalCode;
        }

    }
}
