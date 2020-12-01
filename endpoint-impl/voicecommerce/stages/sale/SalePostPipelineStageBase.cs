namespace endpoint_impl.voicecommerce.stages.sale
{


    public abstract class SalePostPipelineStageBase : ContextPipelineStageBase<SalePostContext>, SalePostPipelineStage
    {
        public SalePostPipelineStageBase(SalePostPipelineStage next) : base(next)
        {
        }
        public SalePostPipelineStageBase(SalePostPipelineStage next, MyServiceResolver sr) : base(next, sr)
        {
        }

    }

    public delegate SalePostPipelineStageBase MyServiceResolver(SalePostPipelineStageBase type);
}
