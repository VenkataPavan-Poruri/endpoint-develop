namespace endpoint_impl.voicecommerce.stages.sale
{
    public abstract class ContextPipelineStageBase<CTXT> : ContextPipelineStage<CTXT>
    {
        private readonly ContextPipelineStage<CTXT> nextStage_Conflict;

        public ContextPipelineStageBase(ContextPipelineStage<CTXT> next)
        {
            nextStage_Conflict = next;
        }

        public virtual void execute(CTXT context)
        {
            stageExecute(context);
        }
        public virtual void nextStage(CTXT context)
        {
            if (nextStage_Conflict != null)
            {
                nextStage_Conflict.execute(context);
            }
        }

        public virtual void Invoke(CTXT context)
        {
            if (nextStage_Conflict != null)
            {
                nextStage_Conflict.execute(context);
            }
        }

        public abstract void stageExecute(CTXT context);

    }
}