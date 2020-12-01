using System;
using System.Text;

namespace endpoint_service.service.xml
{
    public class AuthenticationDataXML
    {
        public int eciFlag;
        public string xid;
        public string acsData;
        public string version;
        public string dsTransId;

        //public AuthenticationDataXML(int eciFlag,
        //                              string xid,
        //                              string acsData,
        //                              string version,
        //                              string dsTransId)
        //{
        //    this.eciFlag = eciFlag;
        //    this.xid = xid;
        //    this.acsData = acsData;
        //    this.version = version;
        //    this.dsTransId = dsTransId;
        //}


        public string getDsTransId()
        {
            return dsTransId;
        }


        public string getVersion() //throws EndpointException
        {
            switch (version)
            {
                case "1.0.2":
                    return "1";
                case "2.1.0":
                    return "2";
                default:
                    //throw new EndpointException("Invalid 3Ds version: '" + version + "'");
                    throw new Exception("Invalid 3Ds version: '" + version + "'");
            }
        }


        public int getECIFlag()
        {
            return eciFlag;
        }


        public string getXID()
        {
            return xid;
        }


        public string getACSData()
        {
            return acsData;
        }


        //public string toString()
        //{
        //    return new StringBuilder(this).
        //           append("XID", xid).
        //           append("ACSData", acsData).
        //           toString();
        //}
    }
}
