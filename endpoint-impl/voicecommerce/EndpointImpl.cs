using datalayer.voicecommerce.model.sale;
using endpoint_api;
using endpoint_api.voicecommerce.api;
using endpoint_impl.voicecommerce.stages.sale;

namespace endpoint_impl.voicecommerce.stages
{
    public class EndpointImpl : Endpoint
    {
        private SalePostPipelineStage _postSalePipelineStart;
        private static readonly SaleRepo saleRepo;

        public EndpointImpl(SalePostPipelineStage postSalePipelineStage)
        {
            _postSalePipelineStart = postSalePipelineStage;

        }

        public void postSale(SalePostRequest postRequest, SalePostResponse postResponse)
        {
            SalePostContext context;
            context = new SalePostContextImpl(postRequest, postResponse);
            _postSalePipelineStart.execute(context);
        }
    }

    //class TestClass : SalePostPipelineStageBase
    //{
    //    private SalePostPipelineStage _salePostPipelineStage;
    //    public TestClass(SalePostPipelineStage next) : base(next)
    //    {
    //        _salePostPipelineStage = next;
    //    }
    //    protected internal override void stageExecute(SalePostContext context)
    //    {
    //        //throw new NotImplementedException();
    //    }
    //}

}
