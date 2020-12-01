namespace endpoint_impl.voicecommerce.stages.sale
{


    public abstract class SalePostPipelineStageBase : ContextPipelineStageBase<SalePostContext>, SalePostPipelineStage
    {        

        public SalePostPipelineStageBase(SalePostPipelineStage next) : base(next)
        {
        }

    }

}
