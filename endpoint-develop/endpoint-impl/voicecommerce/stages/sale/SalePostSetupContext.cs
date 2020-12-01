using datalayer.voicecommerce.model.sale;
using System.Threading.Tasks;

namespace endpoint_impl.voicecommerce.stages.sale
{
    //public class SalePostSetupContext : SalePostPipelineStageBase
    //{
    //    private readonly SaleRepo saleRepo;
    //    public SalePostSetupContext(SaleRepo saleRepo, SalePostPipelineStage next) : base(next)
    //    {
    //        this.saleRepo = saleRepo;
    //    }
    //    protected internal override void stageExecute(SalePostContext context)
    //    {
    //        SaleRepo.SaleBuilder builder = saleRepo.initialSaleBuilder();
    //        context.SaleBuilder = (SaleRepo)builder;
    //        nextStage(context);
    //    }
    //}

    public class SalePostSetupContext : SalePostPipelineStageBase
    {
        private readonly SaleRepo saleRepo;
        private readonly SalePostPipelineStage _next;

        
        //private readonly UserManager<ApplicationUser> _userManager;

        public SalePostSetupContext(SaleRepo saleRepo, SalePostPipelineStage next, SalePostFailedSaleCreation salePostFailedSaleCreation) : base(next)
        {
            _next = next;
        }

        public override void Invoke(SalePostContext context)
        {
           _next.Invoke(context);
        }

        public override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder builder = saleRepo.initialSaleBuilder();
            context.SaleBuilder = (SaleRepo)builder;
            nextStage(context);
        }
    }
   
}
