
using Dapper;
using System;
using System.Data;

namespace database
{
    public class PanRanges : NonTxnlDAOBase
    {
        public PanRangeEntity findPanRange(long loweriin)
        {
            DynamicParameters dynamicParams = new DynamicParameters();
            dynamicParams.Add("@cv_1", ParameterDirection.Output);
            dynamicParams.Add("@p_loweriin", loweriin);
            return fetchSingleResult<PanRangeEntity>("PANRANGE_FIND", dynamicParams);
        }
        public AcceptorDetailEntity find(long loweriin)
        {
            DynamicParameters dynamicParams = new DynamicParameters();
            //dynamicParams.Add("@cv_1", ParameterDirection.Output);
            //dynamicParams.Add("@p_id", id);
            //return fetchSingleResult<AcceptorDetailEntity>("ACCEPTORDETS_FIND", dynamicParams);
            dynamicParams.Add("@cv_1", ParameterDirection.Output);
            dynamicParams.Add("@p_loweriin", loweriin);
            return fetchSingleResult<AcceptorDetailEntity>("PANRANGE_FIND", dynamicParams);
        }
    }
    public class AcceptorDetailEntity
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string STREET { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string POSTAL_CODE { get; set; }
        public string CUSTOMER_SERVICE_P { get; set; }
        public string CUSTOMER_SERVICE_EMAIL { get; set; }
        public string SUB_MERCHANT_ID { get; set; }
    }

    public class PanRangeEntity
    {
        public const string RESULTMAPPING_UpdateSyncRowCount = "PanRangeEntity.SYNC_ROW_COUNT";

        public const string QUERY_FindByIIN = "PanRangeEntitytImpl.FIND_BY_IIN";

        public const string QUERY_Load = "PanRangeEntity.LOAD";

        public const string QUERY_BinUpdateAdvisement = "PanRangeEntity.PANRANGE_FIND_BY_UPDATE_DATE";

        private const string DELETE = "";

        public DateTime DATE_CREATED { get; set; }
        public DateTime DATE_UPDATED { get; set; }
        public Int64 LOWER_IIN { get; set; }
        public Int64 UPPER_IIN { get; set; }
        public string ISO_COUNTRY_CODE { get; set; }
        public string SCHEME_PRODUCT_ID { get; set; }
        public string DATA_SOURCE { get; set; }
        public int LENGTH { get; set; }
        public Boolean LuhnCheckNeeded { get; set; }
        public Boolean IssueNumberNeeded { get; set; }
        public Boolean StartDateNeeded { get; set; }
        public Char ActiveInactiveCode { get; set; }
        public string Scheme { get; set; }
        public string CARD_BRAND { get; set; }
        public Char Region { get; set; }
        public Int64 BrandMappingId { get; set; }
        public string PaymentTypes { get; set; }
        public Int64 Id { get; set; }
    }
}





