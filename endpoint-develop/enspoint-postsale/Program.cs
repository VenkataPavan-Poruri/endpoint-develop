using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_develop.cashflows.core.xml;
using core_develop.cashflows.endpoint.service.api;
using core_develop.cashflows.endpoint.sockets;
using datalayer.voicecommerce.entity;
using datalayer.voicecommerce.model.sale;
using endpoint_impl.voicecommerce.stages;
using endpoint_impl.voicecommerce.stages.sale;
using endpoint_service.service.handler;
using endpoint_service.service.xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace enspoint_postsale
{
   

    public class Program
    {
        private static readonly SaleRepo _saleRepo;
        private static readonly SalePostPipelineStage _salePostPipelineStage;

        static EndpointImpl endpoint = new EndpointImpl(new SalePostSetupContext(_saleRepo, _salePostPipelineStage));
        static EndpointServiceRequestHandlerImpl handler = new EndpointServiceRequestHandlerImpl(endpoint);
        ServerServiceAPIProtocol acquirerAPI;

       
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
