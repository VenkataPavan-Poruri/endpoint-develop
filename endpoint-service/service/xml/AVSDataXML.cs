namespace endpoint_service.service.xml
{
    public class AVSDataXML
    {
        //private readonly string address;
        //private readonly string postalCode;
        public string address;
        public string postalCode;

        //public AVSDataXML(string address, string postalCode)
        //{
        //	this.address = address;
        //	this.postalCode = postalCode;
        //}


        public string getAddress()
        {
            return address;
        }


        public string getPostalCode()
        {
            return postalCode;
        }

        //public override string ToString()
        //{
        //	return (new ToStringBuilder(this)).append("address", address).append("postalCode", postalCode).ToString();
        //}
    }
}
