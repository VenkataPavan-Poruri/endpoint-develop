using core_develop.cashflows.common;
using core_develop.cashflows.core.authorisation;
using core_develop.cashflows.core.common;
using datalayer.voicecommerce.entity.impl;
using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.sale;
using datalayer.voicecommerce.model.terminal;
using endpoint_api.voicecommerce.api;
using scheme_visa.voicecommerce.common;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostFundsRecipientCheck : SalePostPipelineStageBase
    {
        private bool isDebtRepaySale;

        public SalePostFundsRecipientCheck(SalePostPipelineStage next) : base(next)
        {
        }
       public override void stageExecute(SalePostContext context)
        {
            SalePostResponse response = context.Response;
            SaleRepo.SaleBuilder saleBuilder = context.saleBuild();
            PANRange binRange = null;
            Card card = saleBuilder.Card;
            ResponseCode? failureResponseCode = null; ;
            if (card != null)
            {
                binRange = card.PANRange;
            }
            if (binRange != null)
            {
                Terminal terminal = saleBuilder.Terminal;
                if (terminal != null)
                {
                    failureResponseCode = checkSchemeFundsRecipient(binRange, terminal, saleBuilder.FundsRecipient, binRange.Scheme, saleBuilder.DebtRepayFlag);
                }
                else
                {
                    //Logger.warn("Sale doesn't have associated terminal = " + "Cannot perform Funds recipient check");
                }
            }
            else
            {
                //Logger.info("Not performing FundsRecipient check - Not a VISA/Mastercard card");
            }
            //nextStage(context);
            if (failureResponseCode.HasValue)
            {
                response.ResponseCode = (ResponseCode)failureResponseCode;
            }
            else
            {
                nextStage(context);
            }
        }
        private static bool missingRecipientData(string data)
        {
            return ((string.ReferenceEquals(data, null)) || (data.Trim().Length == 0));
        }
        private ResponseCode checkSchemeFundsRecipient(PANRange binRange, Terminal terminal, FundsRecipient recipient, AuthScheme authScheme, bool debtRepayFlag)
        {
            ResponseCode? errorCode = null; ;
            bool isVisaFinancial = VisaMerchantClassificationGroup.FINANCAL_INSTITUTION.contains(terminal.MCC);
            bool isVisaDebtRepayment = VisaMerchantClassificationGroup.DEBT_REPAYMENT.contains(terminal.MCC) && isDebtRepaySale;

            if ((binRange.IssueCountry == Country.GB) && (terminal.Country == Country.GB) && (((isVisaFinancial || isVisaDebtRepayment) && authScheme == AuthScheme.VISA) || (isDebtRepaySale && authScheme == AuthScheme.MASTERCARD)))
            {

                //Logger.info(authScheme.name() + " Funds Recipient data is required for this Sale");
                bool dataMissing;

                // VISA : GB merchant and shopper, and an 6012 or 7299 merchant 
                // MC : if debt repayment transaction 
                // Then - All FraudRecipient fields are required..
                dataMissing = (recipient == null);
                if (recipient != null)
                {
                    dataMissing |= (recipient.DateOfBirth == null);
                    dataMissing |= missingRecipientData(recipient.AccountNumber);
                    dataMissing |= missingRecipientData(recipient.PostalCode);
                    dataMissing |= missingRecipientData(recipient.Surname);
                }
                if (dataMissing)
                {
                    //Logger.info("Not all Funds Recipient data was provided");
                    errorCode = ResponseCode.FUNDSRECIPIENT_MISSING;
                }
                else
                {
                    // .. and the postcode must look like a UK one.
                    if (missingRecipientData(recipient.UKPostalCodePrefix))
                    {
                        //Logger.info("Recipient Postal code doesn't appear to be UK based");
                        errorCode = ResponseCode.FUNDSRECIPIENT_INVALID;
                    }
                }
            }
            return errorCode.Value;
            //throw new NotImplementedException();
        }
    }
}
