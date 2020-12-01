namespace core_develop.cashflows.core.xml
{
    public class AcceptorDetailXML
    {
        //private string name;
        //private MerchantContactRecordXML contactRecord;
        //private string subMerchantId;

        public string name;
        public MerchantContactRecordXML contactRecord;
        public string subMerchantId;


        //public AcceptorDetailXML(string name, MerchantContactRecordXML merchantContactRecord)
        //{
        //    this.name = name;
        //    this.contactRecord = merchantContactRecord;
        //}

        public string getName()
        {
            return name;
        }

        public MerchantContactRecordXML getContactRecord()
        {
            return contactRecord;
        }


        public void setSubMerchantId(string subMerchantId)
        {
            this.subMerchantId = subMerchantId;
        }


        public string getSubMerchantId()
        {
            return subMerchantId;
        }
    }
}
