using scheme_common.voicecommerce.common;
using System;
using System.Collections.Generic;

namespace scheme_visa.voicecommerce.common
{
    public sealed class VisaMerchantClassificationGroup : MerchantClassificationGroup
    {
        //public static object FINANCAL_INSTITUTION { get; set; }
        //public static object DEBT_REPAYMENT { get; set; }

        public bool contains(int mcc)
        {
            throw new NotImplementedException();
            //return MerchantClassificationGroupUtil.contains(checks, mcc);
        }
        
        public static readonly VisaMerchantClassificationGroup FINANCAL_INSTITUTION = new VisaMerchantClassificationGroup("FINANCAL_INSTITUTION", InnerEnum.FINANCAL_INSTITUTION, include(6012));

        private static MerchantClassificationGroupUtil.Check[] include(int v)
        {
            throw new NotImplementedException();
        }

        public static readonly VisaMerchantClassificationGroup DEBT_REPAYMENT = new VisaMerchantClassificationGroup("DEBT_REPAYMENT", InnerEnum.DEBT_REPAYMENT, include(6012, 6051, 7299));

        private static MerchantClassificationGroupUtil.Check[] include(int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }

        public enum InnerEnum
        {
            GAMING,
            FINANCAL_INSTITUTION,
            DEBT_REPAYMENT,
            ME2ME,
            MARKETPLACE
        }
        private static readonly List<VisaMerchantClassificationGroup> valueList = new List<VisaMerchantClassificationGroup>();
        static VisaMerchantClassificationGroup()
        {
            //valueList.Add(GAMING);
            valueList.Add(FINANCAL_INSTITUTION);
            valueList.Add(DEBT_REPAYMENT);
            //valueList.Add(ME2ME);
            //valueList.Add(MARKETPLACE);
        }
        private readonly MerchantClassificationGroupUtil.Check[] checks;
        public readonly InnerEnum innerEnumValue;
        private readonly string nameValue;
        private readonly int ordinalValue;
        private static int nextOrdinal = 0;
        private VisaMerchantClassificationGroup(string name, InnerEnum innerEnum, params MerchantClassificationGroupUtil.Check[] checks)
		{
			this.checks = checks;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

    }
}
