namespace endpoint_impl.voicecommerce.stages.sale
{
	public interface SalePostPipelineStage : ContextPipelineStage<SalePostContext>
	{
		public void Invoke(SalePostContext context);
	}
}