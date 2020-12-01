using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostSoftDescriptor : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        private PipelineDebtRepaymentSetUpStageUtility debtRepaymentSetUpUtility;
        public SalePostSoftDescriptor(SalePostPipelineStage next) : base(next)
        {
            _nextStage = new SalePostDebtRepaymentSetUp(next, debtRepaymentSetUpUtility);            
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder builder = context.saleBuild();
            SalePostRequest request = context.Request;
            string softDescriptor = request.getSoftDescriptor();
            if (!string.ReferenceEquals(softDescriptor, null))
			{
                //Logger.info("Setting Soft Desciptor on Sale: " + softDescriptor);
                builder.SoftDescriptor = softDescriptor;
			}

			nextStg(context);
        }
    }
}
