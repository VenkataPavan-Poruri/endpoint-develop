using core_develop.cashflows.core.xml;
using core_develop.cashflows.endpoint.service.api;
using core_develop.cashflows.endpoint.sockets;
using datalayer.voicecommerce.entity;
using endpoint_api;
using endpoint_models.Request;
using endpoint_service.service.handler;
using endpoint_service.service.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using endpoint_impl.voicecommerce.stages;
using endpoint_impl.voicecommerce.stages.sale;


namespace endpoint_salepost
{
    public class TestClass : SalePostPipelineStageBase
    {
        private SalePostPipelineStage _salePostPipelineStage;
        public TestClass(SalePostPipelineStage next) : base(next)
        {
            _salePostPipelineStage = next;
        }
        protected override void stageExecute(SalePostContext context)
        {
            //throw new NotImplementedException();
        }
    }

    public class Program
    {
        static TestClass _salePostPipelineStage;
        private readonly TestClass obj = new TestClass(_salePostPipelineStage);
        private static readonly TestClass _salePostPipelineStage1 = _salePostPipelineStage;

        static EndpointImpl endpoint = new EndpointImpl(_salePostPipelineStage1);
        static EndpointServiceRequestHandlerImpl handler = new EndpointServiceRequestHandlerImpl(endpoint);
        ServerServiceAPIProtocol acquirerAPI;

        //public static EndpointServiceRequestHandlerImpl Handler => handler;


        //static void Main(string[] args)
        //{
        //    //Console.WriteLine("Hello World!");

        //    APIResponse response = null;
        //    APIRequest request = null;
        //    MonitoredConnection clientData = null;
        //    request = acquirerAPI.unmarshalRequest(requestBuffer);
        //    //response = submitRequest(request, clientData);
        //}
        //protected void handleIncomingData(MonitoredConnection clientData)
        //{
        //    StreamReader inputStream = (StreamReader)clientData;
        //    StreamWriter outputStream = (StreamWriter)clientData;
        //    BufferedStream requestBuffer;
        //    requestBuffer = acquirerAPI..readBuffer(inputStream);
        //}

        //public APIResponse submitRequest(APIRequest apiRequest, MonitoredConnection clientData)
        //{
        //    string bid = "VCG";
        //    APIResponse apiResponse = null;
        //    apiResponse = handler.handleRequest(apiRequest, getIdent(), bid);
        //    return apiResponse;

        //}
        //public string getIdent()
        //{
        //    string ident = "01S00BE20CF";
        //    return ident;
        //}
        //public static readonly string apiRequest = "<SalePostRequest gatewayReference=" + "01S00BE20CF" + " authTypeCode=" + "ECOM" + " recurrenceFlag=" + "SINGLE" + " authMode=" + "FINAL" + "exemptionIndicator=" + "><money amount=" + "300" + "currencyCode=" + "GBP" + "></money><terminal mid=" + "100121943" + "tid=" + "1" + "></terminal><card cardNumber=" + "XXXXXXXXXXXXXXXX" + "cvv=" + "555" + "><cardDates expiryDate=" + "2210" + " issueDate=" + "0000" + "></cardDates><avsData><address>Fulborn, Cambridge, Cambridgshire</address><postalCode>CB1 1AA</postalCode></avsData></card><fundsRecipient surname=" + "TestReciName" + " birthDate=" + "1980-08-06 00:00:00.0 UTC" + "accountNumber=" + "XXXXXXXXXXXXXXXX" + "postalCode=" + "CB4 2EY" + "></fundsRecipient><isDebtRepayTrans>false</isDebtRepayTrans><ewallet>0</ewallet></SalePostRequest>";
        //public static Object ObjectToXML(string xml, Type objectType)
        //{
        //    StringReader strReader = null;
        //    XmlSerializer serializer = null;
        //    XmlTextReader xmlReader = null;
        //    Object obj = null;
        //    try
        //    {
        //        strReader = new StringReader(xml);
        //        serializer = new XmlSerializer(objectType);
        //        xmlReader = new XmlTextReader(strReader);
        //        obj = serializer.Deserialize(xmlReader);
        //    }
        //    catch (Exception exp)
        //    {
        //        //Handle Exception Code
        //    }
        //    finally
        //    {
        //        if (xmlReader != null)
        //        {
        //            xmlReader.Close();
        //        }
        //        if (strReader != null)
        //        {
        //            strReader.Close();
        //        }
        //    }
        //    return obj;
        //}
        public static void Main(string[] args)
        {

            //string xmlString = "<Products><Product><Id>1</Id><Name>My XML product</Name></Product><Product><Id>2</Id><Name>My second product</Name></Product></Products>";
            //XmlSerializer serializer1 = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
            //StringReader stringReader1 = new StringReader(xmlString);
            //List<Product> productList1 = (List<Product>)serializer1.Deserialize(stringReader1);


            //string pathSource = @"D:\\TestAPI.xml";

            //Serializer ser = new Serializer();
            //string path = string.Empty;
            //string xmlInputData = string.Empty;
            //string xmlOutputData = string.Empty;

            //path = Directory.GetCurrentDirectory() + @"D:TestAPI.xml";
            //xmlInputData = File.ReadAllText(pathSource);
            // Object obj = ObjectToXML(xmlInputData, typeof(SalePostXMLRequest));           
            //XmlSerializer serializer = new XmlSerializer(typeof(List<SalePostXMLRequest>), new XmlRootAttribute("SalePostRequest"));

            //StringReader stringReader = new StringReader(xmlInputData);
            //List<SalePostXMLRequest> productList = (List<SalePostXMLRequest>)serializer.Deserialize(stringReader);


            //SalePostIncoming incomingRequest = ser.Deserialize<SalePostIncoming>(xmlInputData);
            // SalePostXMLRequest customer = ser.Deserialize<SalePostXMLRequest>(xmlInputData);
            //xmlOutputData = ser.Serialize<SalePostXMLRequest>(customer);

            //APIRequest request = apiRequest;
            //TestAPIRequest testAPIRequest = new TestAPIRequest();
            // XmlSerializer serializer = new XmlSerializer(typeof(SalePostXMLRequest));
            //FileStream fileStream = new FileStream(pathSource, FileMode.Open);
            //SalePostXMLRequest result = (SalePostXMLRequest)serializer.Deserialize(fileStream);

            //APIRequest request = (APIRequest)result;            
            //SalePostRequest result1;
            // XmlSerializer serializer = new XmlSerializer(typeof(SalePostRequest));
            //result = (SalePostRequest)serializer.Deserialize(reader);
            //XmlSerializer serializer = new XmlSerializer(typeof(SalePostIncoming));
            //result = (SalePostIncoming)serializer.Deserialize(reader);

            var myInput = new SalePostXMLRequest
            {
                gatewayReference = "01S00BE20CF",
                authTypeCode = "ECOM",
                recurrenceFlag = "SINGLE",
                authMode = AuthMode.FINAL,
                exemptionIndicator = string.Empty,
                money = new MoneyXML
                {
                    amount = 300,
                    //cashback = 2,
                    currencyCode = "GBP",
                },

                terminal = new TerminalXML
                {
                    mid = "100121943",
                    tid = "1",
                },
                card = new CardXML
                {
                    cardNumber = "XXXXXXXXXXXXXXXX",
                    cvv = "555",
                    cardDates = new CardDatesXML
                    {
                        expiryDate = "2210",
                        issueDate = "0000",
                    },
                    avsData = new AVSDataXML
                    {
                        address = "Fulborn, Cambridge, Cambridgshire",
                        postalCode = "CB1 1AA",
                    }

                },
                //authentData = new AuthenticationDataXML
                //{
                //    eciFlag = 1,
                //    xid = "ABC",
                //    acsData = "ABC",
                //    version = "ABC",
                //    dsTransId = "ABC",
                //},
                fundsRecipient = new FundsRecipientXML
                {
                    surname = "TestReciName",
                    birthDate = DateTime.Now,
                    accountNumber = "XXXXXXXXXXXXXXXX",
                    postalCode = "CB4 2EY",
                },
                //dynamicAcceptor = new AcceptorDetailXML
                //{
                //    name="ABC",
                //    contactRecord=new MerchantContactRecordXML
                //    {
                //        street="ABC",
                //        city="ABC",
                //        state="ABC",
                //        postalCode="ABC",
                //        customerServicePhoneNumber="ABC",
                //        customerServiceEmail="ABC",                        
                //    },
                //    subMerchantId="ABC",
                //},
                //softDescriptor = "ABC",

                isDebtRepayTrans = false,
                ewallet = 0,



            };

            APIResponse apiResponse = null;
            MonitoredConnection clientData = null;
            apiResponse = submitRequest(myInput, clientData);
            //apiResponse = submitRequest(incomingRequest, clientData);
            //reader.Close();
        }

        public static APIResponse submitRequest(SalePostXMLRequest apiRequest, MonitoredConnection clientData)
        {
            try
            {
                string bid = "VCG";
                APIResponse apiResponse = null;
                //var request = apiRequest as APIRequest;
                apiResponse = handler.handleRequest(apiRequest, getIdent(), bid);
                return apiResponse;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static string getIdent()
        {
            string ident = "01S00BE20CF";
            return ident;
        }


    }

}