using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
using static datalayer.voicecommerce.model.sale.SaleRepo;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostFailedSaleCreation : SalePostPipelineStageBase
    {
        public SalePostFailedSaleCreation(SalePostPipelineStage next) : base(next)
        {
        }
        public override void stageExecute(SalePostContext context)
        {
            bool createFailed = true;
            SaleBuilder saleBuilder;
            nextStage(context);
            saleBuilder = context.saleBuild();
            if (saleBuilder.createdSale() == null)
            {
                //Logger.warn("Sale was not stored - Creating Failed Sale");
            }
            else if (context.responseBuilder().createdResponse() == null)
            {
                //Logger.warn("SaleAuthResponse was not stored - Creating Failed Sale");
            }
            else
            {
                createFailed = false;
            }
            if (createFailed)
            {
                SalePostRequest request;

                ResponseCode responseCode;
                FailedSaleBuilder failedSaleBuilder = saleBuilder.failedSaleBuilder();
                responseCode = context.Response.ResponseCode;
                if (responseCode == null)
                {
                    // Oh - Don't have anything, set a sensible default...
                    responseCode = ResponseCode.UNKNOWN;
                    context.Response.ResponseCode = responseCode;
                }
                request = context.Request;
                failedSaleBuilder.setAuthScheme(saleBuilder.AuthScheme).setResponseCode(responseCode).setGatewayRef(request.getGatewayReference()).setAuthType((request.getAuthType() != null) ? request.getAuthType().ToString() : null).setAmount(request.getAmount()).setCurrencyCode((request.getCurrency() != null) ? request.getCurrency().ToString() : null).setRecurrenceFlag((request.getRecurrenceFlag() != null) ? request.getRecurrenceFlag().ToString() : null).setTerminalBID(request.getBID()).setTerminalMID(request.getTerminalMID()).setTerminalTID(request.getTerminalTID()).setCardNumber(request.getCardNumber()).setCardDateIssue(request.getCardDateIssue()).setCardDateExpiry(request.getCardDateExpiry()).setCardAddress(request.getCardAddress()).setCardPostalCode(request.getCardPostalCode()).setAuthentECI(request.getAuthenticationECIFlag()).setAuthentXID(request.getAuthenticationXID()).setAuthentACS(request.getAuthenticationACSData()).setAuthent3DsVersion(request.getAuthentication3DsVersion()).setAuthMode((request.getAuthMode() != null) ? request.getAuthMode().ToString() : null).setDebtRepayFlag(saleBuilder.getDebtRepayFlag());

                long? failedSaleId = failedSaleBuilder.create();
                //Logger.warn("Failed sale stored with Id: " + failedSaleId);
            }
        }
    }
}