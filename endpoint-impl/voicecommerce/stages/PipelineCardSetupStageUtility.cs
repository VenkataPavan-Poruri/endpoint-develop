using datalayer.voicecommerce.entity.impl;
using datalayer.voicecommerce.model.card;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class PipelineCardSetupStageUtility
    {
		public virtual CardNumber buildCardNumber(string number)
		{
			CardNumber cardNum;

			//try
			//{
			//	cardNum = new ClearTextCardNumber(number);
			//}
			//catch (CardHandlingException e)
			//{
			//	throw new EndpointException("Failed building CardNumber", e);
			//}
			//return cardNum;
			return null;
		}

		public virtual CardDate buildCardDate(string strRep)
		{
			CardDate cardDate = null;

			// TODO: Handling parsing issues.
			if (!string.ReferenceEquals(strRep, null))
			{
				cardDate = new CardDate(strRep);
			}
			return cardDate;
		}

		public virtual AVSData buildAVSData(string address, string postalCode)
		{
			AVSData avsData = null;

			if ((!string.ReferenceEquals(address, null)) && (!string.ReferenceEquals(postalCode, null)))
			{
				avsData = new AVSData(address, postalCode);
			}
			return avsData;
		}
	}
}