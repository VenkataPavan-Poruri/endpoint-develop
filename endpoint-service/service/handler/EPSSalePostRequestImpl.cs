using core_develop.cashflows.core.common;
using datalayer.voicecommerce.entity;
using endpoint_api.voicecommerce.api;
using endpoint_service.service.xml;
using System;
using System.Linq;

namespace endpoint_service.service.handler
{
    public class EPSSalePostRequestImpl : SalePostRequest
    {
        public SalePostXMLRequest xmlReq;
        public MoneyXML money;

        public string bid;
        public EPSSalePostRequestImpl(SalePostXMLRequest xmlReq, string bid)
        {
            this.xmlReq = xmlReq;
            this.bid = bid;
        }

        public string getBID()
        {
            return bid;
        }
        public string getGatewayReference()
        {
            return xmlReq.getGatewayReference();
        }
        public AuthType getAuthType()
        {
            return xmlReq.getAuthType();
        }
        public double? getAmount()
        {
            return xmlReq.getAmount();

        }


        public virtual CurrencyEnums getCurrency()
        {
            return Currency.currencynames.Where(x => x.isoCode == money.CurrencyCode).FirstOrDefault();

        }

        public RecurrenceFlag getRecurrenceFlag()
        {
            return xmlReq.getRecurrenceFlag();
        }

        public int getAuthenticationECIFlag()
        {
            AuthenticationDataXML authentData = xmlReq.getAuthenticationData();
            return authentData.getECIFlag();

            //return authentData != null ? authentData.getECIFlag() : null;
        }

        public string getAuthenticationXID()
        {
            AuthenticationDataXML authentData = xmlReq.getAuthenticationData();

            return authentData != null ? authentData.getXID() : null;
        }

        public string getAuthenticationACSData()
        {
            AuthenticationDataXML authentData = xmlReq.getAuthenticationData();

            return authentData != null ? authentData.getACSData() : null;
        }

        public string getCardNumber()
        {
            CardXML card = xmlReq.getCard();

            return (card != null) ? card.getCardNumber() : null;
        }
        public string getCardDateIssue()
        {
            CardXML card = xmlReq.getCard();

            return (card != null) ? card.getIssueDate() : null;
        }
        public string getCardDateExpiry()
        {
            CardXML card = xmlReq.getCard();

            return (card != null) ? card.getExpiryDate() : null;
        }

        public string getCardCVV()
        {
            CardXML card = xmlReq.getCard();

            return (card != null) ? card.getCVV() : null;
        }

        public string getCardAddress()
        {
            AVSDataXML avsData = null;
            CardXML card = xmlReq.getCard();

            if (card != null)
            {
                avsData = card.getAVSData();
            }
            return avsData != null ? avsData.getAddress() : null;
        }

        public string getCardPostalCode()
        {
            AVSDataXML avsData = null;
            CardXML card = xmlReq.getCard();

            if (card != null)
            {
                avsData = card.getAVSData();
            }
            return avsData != null ? avsData.getPostalCode() : null;
        }
        public string getTerminalMID()
        {
            return xmlReq.getMID();
        }
        public string getTerminalTID()
        {
            return xmlReq.getTID();
        }
        public string getRecipientSurname()
        {
            FundsRecipientXML recipient = xmlReq.getFundsRecipient();

            return recipient != null ? recipient.getSurname() : null;
        }

        public DateTime getRecipientDOB()
        {
            FundsRecipientXML recipient = xmlReq.getFundsRecipient();

            //return recipient != null ? recipient.getBirthDate() : null;
            return recipient.getBirthDate();
        }
        public string getRecipientPostalCode()
        {
            FundsRecipientXML recipient = xmlReq.getFundsRecipient();

            return recipient != null ? recipient.getPostalCode() : null;
        }
        public string getRecipientAccountNumber()
        {
            FundsRecipientXML recipient = xmlReq.getFundsRecipient();

            return recipient != null ? recipient.getAccountNumber() : null;
        }
        public bool hasDynamicAcceptor()
        {
            return (xmlReq.getDynamicAcceptor() != null);
        }
        public string getDynamicAcceptorName()
        {
            return hasDynamicAcceptor() ? xmlReq.getDynamicAcceptor().getName() : null;
        }
        public string getDynamicAcceptorStreet()
        {
            return hasDynamicAcceptor() ? xmlReq.getDynamicAcceptor().getContactRecord().getStreet() : null;
        }
        public string getDynamicAcceptorCity()
        {
            return hasDynamicAcceptor() ? xmlReq.getDynamicAcceptor().getContactRecord().getCity() : null;
        }
        public string getDynamicAcceptorState()
        {
            return hasDynamicAcceptor() ? xmlReq.getDynamicAcceptor().getContactRecord().getState() : null;
        }
        public string getDynamicAcceptorPostalCode()
        {
            return hasDynamicAcceptor() ? xmlReq.getDynamicAcceptor().getContactRecord().getPostalCode() : null;
        }
        public string getDynamicAcceptorCustomerServicePhone()
        {
            return hasDynamicAcceptor() ? xmlReq.getDynamicAcceptor().getContactRecord().getCustomerServicePhoneNumber() : null;
        }
        public string getDynamicAcceptorSubMerchantId()
        {
            return hasDynamicAcceptor() ? xmlReq.getDynamicAcceptor().getSubMerchantId() : null;
        }
        public string getSoftDescriptor()
        {
            return xmlReq.getSoftDescriptor();
        }
        public AuthMode getAuthMode()
        {
            return xmlReq.getAuthMode();
        }
        public bool getDebtRepayFlag()
        {
            return xmlReq.getDebtRepayFlag();
        }
        public string getAuthentication3DsVersion() //throws EndpointException
        {
            AuthenticationDataXML authentData = xmlReq.getAuthenticationData();
            return authentData != null ? authentData.getVersion() : null;
        }
        public string getAuthenticationDsTransId()
        {
            AuthenticationDataXML authentData = xmlReq.getAuthenticationData();
            return authentData != null ? authentData.getDsTransId() : null;
        }
        public string getExemptionIndicator()
        {

            return xmlReq.getExemptionIndicator();
        }

        //string SalePostRequest.BID { get; set; }

        //string SalePostRequest.GatewayReference { get; set; }

        //AuthType SalePostRequest.AuthType { get; set; }

        //long? SalePostRequest.Amount { get; set; }

        //Currency SalePostRequest.Currency { get; set; }

        //RecurrenceFlag SalePostRequest.RecurrenceFlag { get; set; }

        //int? SalePostRequest.AuthenticationECIFlag { get; set; }

        //string SalePostRequest.AuthenticationXID { get; set; }

        //string SalePostRequest.AuthenticationACSData { get; set; }

        //string SalePostRequest.Authentication3DsVersion { get; set; }

        //string SalePostRequest.AuthenticationDsTransId { get; set; }

        //string SalePostRequest.CardNumber { get; set; }

        //string SalePostRequest.CardDateIssue { get; set; }

        //string SalePostRequest.CardDateExpiry { get; set; }

        //string SalePostRequest.CardCVV { get; set; }

        //string SalePostRequest.CardAddress { get; set; }

        //string SalePostRequest.CardPostalCode { get; set; }

        //string SalePostRequest.TerminalMID { get; set; }

        //string SalePostRequest.TerminalTID { get; set; }

        //string SalePostRequest.RecipientSurname { get; set; }

        //DateTime SalePostRequest.RecipientDOB { get; set; }

        //string SalePostRequest.RecipientPostalCode { get; set; }

        //string SalePostRequest.RecipientAccountNumber { get; set; }

        //string SalePostRequest.DynamicAcceptorName { get; set; }

        //string SalePostRequest.DynamicAcceptorStreet { get; set; }

        //string SalePostRequest.DynamicAcceptorCity { get; set; }

        //string SalePostRequest.DynamicAcceptorState { get; set; }

        //string SalePostRequest.DynamicAcceptorPostalCode { get; set; }

        //string SalePostRequest.DynamicAcceptorCustomerServicePhone { get; set; }

        //string SalePostRequest.DynamicAcceptorSubMerchantId { get; set; }

        //string SalePostRequest.SoftDescriptor { get; set; }

        //AuthMode SalePostRequest.AuthMode { get; set; }

        //bool SalePostRequest.DebtRepayFlag { get; set; }

        //string SalePostRequest.ExemptionIndicator { get; set; }

        //bool SalePostRequest.hasDynamicAcceptor { get; set; }

    }
}
