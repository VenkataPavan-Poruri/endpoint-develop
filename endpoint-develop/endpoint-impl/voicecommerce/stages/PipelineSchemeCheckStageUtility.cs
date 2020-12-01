using core_develop.cashflows.common;
using datalayer.voicecommerce.entity.scheme;
using datalayer.voicecommerce.model.card;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class PipelineSchemeCheckStageUtility
    {
		public virtual Scheme getSchemeFromPanRange(PANRange binRange)
		{
			if (binRange != null)
			{
				// Have a range - see what scheme it thinks it is.
				Scheme scheme = null;
				AuthScheme cardAuthScheme = binRange.Scheme;
				if (cardAuthScheme != null)
				{
					switch (cardAuthScheme)
					{
						case AuthScheme.VISA:
							//scheme = visaScheme;
							break;
						case AuthScheme.MASTERCARD:
							//scheme = mastercardScheme;
							break;
						case AuthScheme.AMEX:
							//scheme = amexScheme;
							break;
					}
				}
				if (scheme == null)
				{
					//LOGGER.error("Couldn't determine AuthScheme for available PanRange");
					return null;
				}
				else
				{
					return scheme;
				}
			}
			else
			{
				//LOGGER.error("Couldn't determine PanRange scheme for card.");
				return null;
			}
		}
	}
}