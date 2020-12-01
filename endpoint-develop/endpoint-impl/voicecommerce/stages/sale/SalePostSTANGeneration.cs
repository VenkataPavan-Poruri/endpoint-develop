using datalayer.voicecommerce.entity.scheme;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostSTANGeneration : SalePostPipelineStageBase
    {
        public SalePostSTANGeneration(SalePostPipelineStage next) : base(next)
        {
        }
        public override void stageExecute(SalePostContext context)
        {
            long? stan;
            Scheme scheme = context.getScheme();
            if (scheme == null)
            {
                //throw new EndpointException("Context Scheme not yet defined");
            }
            stan = scheme.createStan(context.saleBuild().Timestamp);
            //Logger.info("STAN generated for sale: " + stan);
            context.saleBuild().setSTAN(scheme.AuthScheme, stan);
            nextStage(context);
        }
    }
}
