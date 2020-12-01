namespace endpoint_impl.voicecommerce.stages.sale
{
    public abstract class ContextPipelineStageBase<CTXT> : ContextPipelineStage<CTXT>
    {
        private readonly ContextPipelineStage<CTXT> _currentStage;

        public ContextPipelineStageBase(ContextPipelineStage<CTXT> nextStage)
        {
            _currentStage = nextStage;
        }

        public ContextPipelineStageBase(ContextPipelineStage<CTXT> nextStage, MyServiceResolver sr)
        {
            _currentStage = nextStage;
        }

        public virtual void execute(CTXT context)
        {
            stageExecute(context);
        }
        protected internal virtual void nextStg(CTXT context)
        {
            if (_currentStage != null)
            {
                _currentStage.execute(context);
            }
        }

        //public virtual void Invoke(CTXT context)
        //{
        //    if (nextStage_Conflict != null)
        //    {
        //        nextStage_Conflict.execute(context);
        //    }
        //}

        protected internal abstract void stageExecute(CTXT context);

    }
}