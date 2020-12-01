using System;

namespace datalayer.voicecommerce.generators
{
    public class CardNumberObfuscator
    {
		public virtual string obfuscateCardNumber(string clearCardNumber)
		{
			string obfuscated;

			if (clearCardNumber.Length >= 11)
			{
				string first6 = clearCardNumber.Substring(0, 6);
				string last4 = clearCardNumber.Substring(clearCardNumber.Length - 4);
				string stars = (new string(new char[clearCardNumber.Length - 10])).Replace("\0", "*");

				obfuscated = first6 + stars + last4;
			}
			else
			{
				// Too short to care about, just return it as is.
				obfuscated = clearCardNumber;
			}
			return obfuscated;
		}
	}
}
