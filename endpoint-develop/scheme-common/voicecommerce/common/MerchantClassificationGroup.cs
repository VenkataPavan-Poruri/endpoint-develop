using System;
using System.Collections.Generic;
using System.Text;

namespace scheme_common.voicecommerce.common
{
    /// <summary>
    /// Interface for a representation of a Merchant Classificiation (MCC) group.
    /// </summary>
    public interface MerchantClassificationGroup
    {
        bool contains(int mcc);
    }
}
