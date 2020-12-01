
namespace endpoint_impl.voicecommerce.stages.sale
{
    public interface ContextPipelineStage<CTXT>
    {
        void execute(CTXT context);
    }
}