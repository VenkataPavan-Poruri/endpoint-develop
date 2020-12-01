using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using endpoint_service.service.handler;
using core_develop.cashflows.endpoint.service.api;
using endpoint_impl.voicecommerce.stages;
using endpoint_impl.voicecommerce.stages.sale;
using endpoint_service.service.xml;
using endpoint_service.service.handler;
using core_develop.cashflows.endpoint.sockets;
using datalayer.voicecommerce.entity;
using core_develop.cashflows.core.xml;
using datalayer.voicecommerce.model.sale;
using Microsoft.Extensions.DependencyInjection;
using endpoint_api;

namespace endpointWebApp
{
    public class Program
    {
        private static readonly SaleRepo _saleRepo;
        private static readonly SalePostPipelineStage _salePostPipelineStage;

        static EndpointServiceRequestHandlerImpl handler = null;
        //static EndpointImpl endpoint = new EndpointImpl(new SalePostSetupContext(_saleRepo, _salePostPipelineStage));
            ServerServiceAPIProtocol acquirerAPI;

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

            var collection = new ServiceCollection();
            //collection.AddSingleton<SaleRepo>();
            //collection.AddScoped<SalePostPipelineStage>();
            collection.AddScoped<EndpointImpl>();
            collection.AddScoped<SalePostSetupContext>();
            collection.AddScoped<SalePostFailedSaleCreation>();

            var provider = collection.BuildServiceProvider();

            SaleRepo sr = provider.GetService<SaleRepo>();
            SalePostSetupContext sp = provider.GetService<SalePostSetupContext>();
            Endpoint ep = provider.GetService<EndpointImpl>();

            handler = new EndpointServiceRequestHandlerImpl(ep);

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

                
            //ISalePostSetupContext sp = provider.GetService<SalePostSetupContext>();
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
            public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
