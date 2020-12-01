using datalayer.voicecommerce.entity.scheme;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostSTANGeneration : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        private readonly CostDesignatorParamCalculationStageUtility costingUtility;

        public SalePostSTANGeneration(SalePostPipelineStage next) : base(next)
        {
            _nextStage = new SalePostCostDesignatorParameterCalculation(costingUtility, next);
        }
        protected internal override void stageExecute(SalePostContext context)
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
            nextStg(context);
        }
    }
}
