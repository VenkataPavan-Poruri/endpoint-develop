using System;

namespace datalayer.voicecommerce.entity.impl
{
    public class FundsRecipient
    {
        private readonly DateTime dateOfBirth;
        private readonly string accountNumber;
        private readonly string postalCode;
        private readonly string surname;
        public FundsRecipient(DateTime recipientDOB, string recipientSurname, string recipientAccountNumber, string recipientPostalCode)
        {
            this.dateOfBirth = recipientDOB;
            this.accountNumber = recipientAccountNumber;
            this.postalCode = recipientPostalCode;
            this.surname = recipientSurname;

        }
        public virtual DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
        }
        public virtual string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public virtual string PostalCode
        {
            get
            {
                return postalCode;
            }
        }

        public virtual string Surname
        {
            get
            {
                return surname;
            }
        }


        public virtual string UKPostalCodePrefix
        {
            get
            {
                string partialPostCode = PostalCode.Replace(" ", "").ToUpper();
                if (partialPostCode.Contains(".*[0-9][A-Z]{2}$"))
                {
                    //  Ends 0XX
                    //  Then ends like a UK postcode - trim that part.
                    partialPostCode = partialPostCode.Substring(0, (partialPostCode.Length - 3));
                }

                //  Check what we have left appears to be a valid start to a UK code.
                //  Matching A[A]N[N], or A[A]NA
                return partialPostCode.Equals("^([A-Z]{1,2}[0-9]{1,2}|[A-Z]{1,2}[0-9][A-Z])$").ToString();
                //return partialPostCode.Contains("^([A-Z]{1,2}[0-9]{1,2}|[A-Z]{1,2}[0-9][A-Z])$").ToString();
            }

        }
    }
}