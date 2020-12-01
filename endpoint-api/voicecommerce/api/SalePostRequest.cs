using core_develop.cashflows.core.common;
using datalayer.voicecommerce.entity;
using System;

namespace endpoint_api.voicecommerce.api
{
    public interface SalePostRequest
    {
        string getBID();

        string getGatewayReference();
        AuthType getAuthType();

        double? getAmount();

        // Currency getCurrency();
        CurrencyEnums getCurrency();

        RecurrenceFlag getRecurrenceFlag();


        // Authentication Data..

        int getAuthenticationECIFlag();

        string getAuthenticationXID();

        string getAuthenticationACSData();

        string getAuthentication3DsVersion();// throws EndpointException;

        string getAuthenticationDsTransId();

        // Card details.

        string getCardNumber();

        string getCardDateIssue();

        string getCardDateExpiry();

        string getCardCVV();

        string getCardAddress();

        string getCardPostalCode();


        // Terminal details.

        string getTerminalMID();

        string getTerminalTID();


        // Funds Recipient
        string getRecipientSurname();

        DateTime getRecipientDOB();

        string getRecipientPostalCode();

        string getRecipientAccountNumber();


        // Dynamic Acceptor
        bool hasDynamicAcceptor();

        string getDynamicAcceptorName();

        string getDynamicAcceptorStreet();

        string getDynamicAcceptorCity();

        string getDynamicAcceptorState();

        string getDynamicAcceptorPostalCode();

        string getDynamicAcceptorCustomerServicePhone();

        string getDynamicAcceptorSubMerchantId();

        // Soft Descriptor
        string getSoftDescriptor();

        AuthMode getAuthMode();

        bool getDebtRepayFlag();

        string getExemptionIndicator();

        //AuthType AuthType { get; set; }

        //long? Amount { get; set; }

        //CurrencyEnums Currency { get; set; }
        //CurrencyEnums getCurrency();
        //RecurrenceFlag RecurrenceFlag { get; set; }


        //// Authentication Data..

        //int? AuthenticationECIFlag { get; set; }

        //string AuthenticationXID { get; set; }

        //string AuthenticationACSData { get; set; }

        ////JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        ////ORIGINAL LINE: String getAuthentication3DsVersion() throws com.cashflows.endpoint.EndpointException;
        //string Authentication3DsVersion { get; set; }

        //string AuthenticationDsTransId { get; set; }

        //// Card details.

        //string CardNumber { get; set; }

        //string CardDateIssue { get; set; }

        //string CardDateExpiry { get; set; }

        //string CardCVV { get; set; }

        //string CardAddress { get; set; }

        //string CardPostalCode { get; set; }


        //// Terminal details.

        //string TerminalMID { get; set; }

        //string TerminalTID { get; set; }


        //// Funds Recipient
        //string RecipientSurname { get; set; }

        //DateTime RecipientDOB { get; set; }

        //string RecipientPostalCode { get; set; }

        //string RecipientAccountNumber { get; set; }


        //// Dynamic Acceptor
        //bool hasDynamicAcceptor { get; set; }

        //string DynamicAcceptorName { get; set; }

        //string DynamicAcceptorStreet { get; set; }

        //string DynamicAcceptorCity { get; set; }

        //string DynamicAcceptorState { get; set; }

        //string DynamicAcceptorPostalCode { get; set; }

        //string DynamicAcceptorCustomerServicePhone { get; set; }

        //string DynamicAcceptorSubMerchantId { get; set; }

        //// Soft Descriptor
        //string SoftDescriptor { get; set; }

        //AuthMode AuthMode { get; set; }

        //bool DebtRepayFlag { get; set; }

        //string ExemptionIndicator { get; set; }

    }


}
