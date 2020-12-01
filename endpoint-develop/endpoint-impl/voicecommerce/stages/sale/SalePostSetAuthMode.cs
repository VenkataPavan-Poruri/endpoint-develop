using datalayer.voicecommerce.entity;
using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
using System;
using visa_edit_ftp.enterprisedt.util;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostSetAuthMode : SalePostPipelineStageBase
    {
        public SalePostSetAuthMode(SalePostPipelineStage next) : base(next)
        {
        }

        public override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder saleBuilder = context.saleBuild();
            SalePostRequest request = context.Request;
            if (String.IsNullOrEmpty(request.getAuthMode().ToString()))
            {
                //Logger.info("Setting Sale auth mode to default:" + defaultAuthMode);
                //saleBuilder.AuthMode = DefaultAuthMode;
                saleBuilder.AuthMode = AuthMode.FINAL;
            }
            else
            {
                //Logger.info("Setting Sale auth mode to:" + request.AuthMode);
                saleBuilder.AuthMode = request.getAuthMode();
            }
            nextStage(context);
        }
        public virtual AuthMode DefaultAuthMode { get; set; }

    }
}