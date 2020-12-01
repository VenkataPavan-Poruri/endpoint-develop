using core_develop.cashflows.core.common;
using core_develop.cashflows.core.xml;
using core_develop.cashflows.endpoint.service.api;
using datalayer.voicecommerce.entity;
using System;
using System.Linq;
using System.Text;

namespace endpoint_service.service.xml
{
    public class SalePostXMLRequest : APIRequest
    {

        public string gatewayReference;

        public MoneyXML money;

        public string authTypeCode;

        public string recurrenceFlag;

        public TerminalXML terminal;

        public CardXML card;

        public AuthenticationDataXML authentData;

        public FundsRecipientXML fundsRecipient;

        public AcceptorDetailXML dynamicAcceptor;

        public string softDescriptor;

        public AuthMode authMode;

        public bool isDebtRepayTrans;

        public string exemptionIndicator;

        public double? ewallet;

        //public SalePostXMLRequest(string gatewayReference, string authTypeCode, MoneyXML money, string recurrenceFlag, TerminalXML terminal, CardXML card, AuthenticationDataXML authentData, FundsRecipientXML fundsRecipient, AcceptorDetailXML dynamicAcceptor, string softDescriptor, bool isDebtRepayTrans, string exemptionIndicator)
        //{
        //    this.gatewayReference = gatewayReference;
        //    this.authTypeCode = authTypeCode;
        //    this.money = money;
        //    this.terminal = terminal;
        //    this.recurrenceFlag = recurrenceFlag;
        //    this.card = card;
        //    this.authentData = authentData;
        //    this.fundsRecipient = fundsRecipient;
        //    this.dynamicAcceptor = dynamicAcceptor;
        //    this.softDescriptor = softDescriptor;
        //    this.isDebtRepayTrans = isDebtRepayTrans;
        //    this.exemptionIndicator = exemptionIndicator;
        //}

        //protected internal override
        public string getMessageIdent()
        {
            return this.gatewayReference;
        }

        public string getGatewayReference()
        {
            return this.gatewayReference;
        }

        public AuthType getAuthType()
        {
            //return AuthType.valueOf(this.authTypeCode);
            //return AuthType.MOTO;
            var authTypeCo = (AuthType)Enum.Parse(typeof(AuthType), authTypeCode);
            return authTypeCo;
        }

        //public AuthMode getAuthMode()
        //{
        //    return AuthMode.NONE;
        //}
        public AuthMode getAuthMode()
        {
            return authMode;
            // TODO: Warning!!!, inline IF is not supported ?
        }
        public void setAuthMode(AuthMode authMode)
        {
            this.authMode = authMode;
        }

        public double? getAmount()
        {
            return money.Amount;
        }

        public CurrencyEnums getCurrency()
        {
            // return Currency..valueOf(money.getCurrencyCode());
            CurrencyEnums getCurrencyCode = Currency.currencynames.Where(x => x.name == money.CurrencyCode).FirstOrDefault();
            return getCurrencyCode;
        }


        public RecurrenceFlag getRecurrenceFlag()
        {
            return RecurrenceFlag.valueOf(this.recurrenceFlag);
        }

        public string getMID()
        {
            return this.terminal.getMID();
        }

        public string getTID()
        {
            return this.terminal.getTID();
        }

        public CardXML getCard()
        {
            return this.card;
        }

        public AuthenticationDataXML getAuthenticationData()
        {
            return this.authentData;
        }

        public FundsRecipientXML getFundsRecipient()
        {
            return this.fundsRecipient;
        }

        public AcceptorDetailXML getDynamicAcceptor()
        {
            return this.dynamicAcceptor;
        }

        public string getSoftDescriptor()
        {
            return this.softDescriptor;
        }

        public bool getDebtRepayFlag()
        {
            return this.isDebtRepayTrans;
        }

        public string getExemptionIndicator()
        {
            return this.exemptionIndicator;
        }

        // protected internal override
        public string toString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("gatewayRef", this.gatewayReference);
            str.AppendFormat("amount", this.money.Amount);
            str.AppendFormat("currency", this.money.CurrencyCode);
            str.AppendFormat("card", this.card);
            return str.ToString();           
        }

        // protected internal override
        //public void log(Logger logger) {
        //     logger.info(this.toString());
        // }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
