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
        private readonly SaleRepo _saleRepo;
        private readonly SalePostPipelineStage _nextStage;
        //private readonly SalePostFailedSaleCreation _spf;
        //private readonly SalePostFailedSaleCreation _nextStage;
        //private readonly UserManager<ApplicationUser> _userManager;
        public SalePostSetupContext(SaleRepo saleRepo, SalePostPipelineStage next, MyServiceResolver sr) : base(next)
        {
            _saleRepo = saleRepo;
            _nextStage = sr(this);
            //_spf = spf;
        }

        //public SalePostSetupContext(SalePostFailedSaleCreation nxt) : base(nxt)
        //{
        //    _nextStage = nxt;
        //}

        //public override void Invoke(SalePostContext context)
        //{
        //    SaleRepo.SaleBuilder builder = _saleRepo.initialSaleBuilder();
        //    context.SaleBuilder = (SaleRepo)builder;
        //    _next.Invoke(context);
        //}

        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder builder = _saleRepo.initialSaleBuilder();
            context.SaleBuilder = (SaleRepo)builder;
            nextStg(context);
        }
    }
}
