
namespace endpoint_impl.voicecommerce.stages.sale
{
    public interface ContextPipelineStage<CTXT>
    {
        public void execute(CTXT context);
    }
}