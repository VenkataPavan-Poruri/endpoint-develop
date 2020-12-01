using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostSoftDescriptor : SalePostPipelineStageBase
    {
        public SalePostSoftDescriptor(SalePostPipelineStage next) : base(next)
        {
        }
        public override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder builder = context.saleBuild();
            SalePostRequest request = context.Request;
            string softDescriptor = request.getSoftDescriptor();
            if (!string.ReferenceEquals(softDescriptor, null))
			{
                //Logger.info("Setting Soft Desciptor on Sale: " + softDescriptor);
                builder.SoftDescriptor = softDescriptor;
			}

			nextStage(context);
        }
    }
}
