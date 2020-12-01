using core_develop.cashflows.common;
using database.voicecommerce.daos;
using database.voicecommerce.domain;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostCurrencyCheck : SalePostPipelineStageBase
    {
        private readonly AmexServiceEstablishmentDao serviceEstablishmentDao;
        public SalePostCurrencyCheck(AmexServiceEstablishmentDao serviceEstablishmentDao, SalePostPipelineStage next) : base(next)
        {
            this.serviceEstablishmentDao = serviceEstablishmentDao;
        }
        public override void stageExecute(SalePostContext context)
        {
            if (AuthScheme.AMEX.Equals(context.getScheme().AuthScheme))
            {
                AmexServiceEstablishmentEntity entity = serviceEstablishmentDao.findByCurrency(context.Request.getCurrency().ToString());
                //AmexServiceEstablishmentEntity entity = serviceEstablishmentDao.findByCurrency(context.Request.Currency.CurrencyCode);
                if (entity == null)
                {
                    // throw new EndpointException(string.Format("Invalid Amex Currency: '{0}'", context.Request.Currency.CurrencyCode));
                }
            }

            nextStage(context);
        }
    }
}
