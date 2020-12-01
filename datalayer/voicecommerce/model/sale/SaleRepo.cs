using core_develop.cashflows.common;
using core_develop.cashflows.core.authorisation;
using core_develop.cashflows.core.common;
using datalayer.voicecommerce.entity;
using datalayer.voicecommerce.entity.authorisation.impl;
using datalayer.voicecommerce.entity.costing;
using datalayer.voicecommerce.entity.impl;
using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.terminal;
using System;
namespace datalayer.voicecommerce.model.sale
{
    public interface SaleRepo
    {
        SaleBuilder initialSaleBuilder();
        public interface SaleBuilder
        {
            AuthScheme AuthScheme { get; }

            AuthMode AuthMode { get; set; }
            Card Card { get; }
            Terminal Terminal { get; }
            AcceptorDetail ExplictAcceptor { get; set; }
            string SoftDescriptor { get; set; }
            bool DebtRepayFlag { get; set; }
            FundsRecipient FundsRecipient { get; }
            DateTime Timestamp { get; }

            SaleBuilder setSTAN(AuthScheme scheme, long? stan);

            SaleBuilder setGatewayRef(string refe);

            SaleBuilder setBID(string bid);

            Card getCard();

            SaleBuilder setMID(string mid);

            SaleBuilder setTID(string tid);

            CardRepo_CardBuilder cardBuilder();

            SaleBuilder setCurrencyAmount(double? amount, CurrencyEnums currency);
            FundsRecipientBuilder fundsRecipientBuilder();
            SaleBuilder setAuthType(AuthType authType);

            SaleBuilder setRecurrenceFlag(RecurrenceFlag recurFlag);

            SaleBuilder setAuthMode(AuthMode authMode);

            SaleBuilder setDebtRepayFlag(bool debtRepayFlag);

            SaleBuilder setExemptionIndicator(string exemptionIndicator);

            bool getDebtRepayFlag();

            // SaleBuilder setExplictAcceptor(AcceptorDetail acceptor);

            SaleBuilder setSoftDescriptor(string softDescriptor);

            // FundsRecipientBuilder fundsRecipientBuilder();

            //CardRepo.CardBuilder cardBuilder();

            //Card getCard();

            AuthenticationDataBuilder authenticationDataBuilder();

            void validate();

            Sale create();
            FailedSaleBuilder failedSaleBuilder();
            SaleAuthorisationResponseBuilder responseBuilder();

            // FailedSaleBuilder failedSaleBuilder();

            //  AuthenticationData getAuthenticationData();

            /// Terminal getTerminal();

            AuthScheme getAuthScheme();

            //  FundsRecipient getFundsRecipient();

            Sale createdSale();

            DateTime getTimestamp();

            string getExemptionIndicator();
        }

        public interface FailedSaleBuilder
        {

            FailedSaleBuilder setAuthScheme(AuthScheme scheme);

            FailedSaleBuilder setResponseCode(ResponseCode code);

            FailedSaleBuilder setGatewayRef(string gwRef);

            FailedSaleBuilder setAmount(double? amount);

            FailedSaleBuilder setCurrencyCode(string currCode);

            FailedSaleBuilder setRecurrenceFlag(string recurFlag);

            FailedSaleBuilder setAuthType(string authType);

            FailedSaleBuilder setCardNumber(string cardNumber);

            FailedSaleBuilder setCardDateExpiry(string cardDateExpiry);

            FailedSaleBuilder setCardDateIssue(string cardDateIssue);

            FailedSaleBuilder setCardAddress(string cardAddress);

            FailedSaleBuilder setCardPostalCode(string cardPostalCode);

            FailedSaleBuilder setTerminalTID(string termTID);

            FailedSaleBuilder setTerminalBID(string termBID);

            FailedSaleBuilder setTerminalMID(string termMID);

            FailedSaleBuilder setAuthentECI(int? authECI);

            FailedSaleBuilder setAuthentXID(string authXID);

            FailedSaleBuilder setAuthent3DsVersion(string version);

            FailedSaleBuilder setAuthentACS(string authACS);

            FailedSaleBuilder setAuthentDsTransId(string dsTransId);

            FailedSaleBuilder setInitialARN(string initialARN);

            FailedSaleBuilder setAuthMode(string authMode);

            FailedSaleBuilder setDebtRepayFlag(bool debtRepayFlag);

            FailedSaleBuilder setChipDataId(long chipDataId);

            //  TODO: Funds recipient data?
            long create();

            long createdFailedSale();

        }
        public interface SaleAuthorisationResponseBuilder
        {
            ResponseCode ResponseCode { get; set; }
            AuthScheme AuthScheme { get; }
            string ARN { get; set; }
            SchemeAuthorisationResult AuthorisationResult { get; }
            CostDesignatorParameters CostDesignatorParameters { get; set; }
            VerificationResponse CvvResponseCode { get; set; }
            VerificationResponse AvsAddressResponseCode { get; set; }
            VerificationResponse AvsPostalCodeResponseCode { get; set; }

            SaleAuthorisationResponse createdResponse();
        }

        public interface AuthenticationDataBuilder
        {

            AuthenticationDataBuilder setECIFlag(int? eci);

            AuthenticationDataBuilder setXID(String xid);

            AuthenticationDataBuilder setACSData(String acsData);

            AuthenticationDataBuilder set3DsVersion(String version);

            void validate();

            //AuthenticationData create();

            //AuthenticationData createdAuthenticationData();

            AuthenticationDataBuilder setDsTransId(String dsTransId);
        }

        public interface FundsRecipientBuilder
        {

            FundsRecipientBuilder setDoB(DateTime date);

            FundsRecipientBuilder setSurname(String surname);

            FundsRecipientBuilder setAccountNumber(String accNumber);

            FundsRecipientBuilder setPostalCode(String postalCode);

            void validate();

            // FundsRecipient create();

            // FundsRecipient createdRecipient();
        }
    }
}
