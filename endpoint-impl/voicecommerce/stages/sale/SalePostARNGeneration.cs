using datalayer.voicecommerce.model.sale;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostARNGeneration : SalePostPipelineStageBase
    {
        private readonly PipelineArnGeneratorStageUtility arnGenerator;
        public SalePostARNGeneration(PipelineArnGeneratorStageUtility arnGenerator, SalePostPipelineStage next) : base(next)
        {

            this.arnGenerator = arnGenerator;
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            string arn;
            SaleRepo.SaleAuthorisationResponseBuilder saleRespBuilder;
            Sale builtSale;
            nextStg(context);

            saleRespBuilder = context.responseBuilder();
            builtSale = context.getSale();
            //arn = arnGenerator.generateARN(saleRespBuilder.ResponseCode, builtSale.Terminal.BID, saleRespBuilder.AuthScheme, builtSale.Timestamp, Action.APPROVE);
            arn = null;
            if (!string.ReferenceEquals(arn, null))
            {
                saleRespBuilder.ARN = arn;
            }
            else
            {
                //Logger.info("No ARN generated for Sale");
            }

        }
    }
}
