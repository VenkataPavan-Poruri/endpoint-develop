namespace scheme_common.voicecommerce.common
{
    public class MerchantClassificationGroupUtil
	{
		private MerchantClassificationGroupUtil()
		{
			// Stop construction of instance - this is just a collection of utility methods.
		}

		public static bool contains(Check[] checks, int mcc)
		{
			bool? contains = null;

			if (checks != null)
			{
				// Check any ranges we have.
				foreach (Check check in checks)
				{
					contains = check.matches(mcc);
					if (contains != null)
					{
						// A positive value has been asserted by the check, so that's what we'll use.
						break;
					}
				}
			}
			return (contains != null) && contains.Value;
		}


		public static Range range(int min, int max)
		{
			return new Range(true, min, max);
		}


		public static Range exclude_range(int min, int max)
		{
			return new Range(false, min, max);
		}


		public static Check groups(params MerchantClassificationGroup[] groups)
		{
			return new Grouping(true, groups);
		}


		public static Check exclude_groups(params MerchantClassificationGroup[] groups)
		{
			return new Grouping(false, groups);
		}

		public static Check include(params int[] mccs)
		{
			return new List(true, mccs);
		}


		public static Check exclude(params int[] mccs)
		{
			return new List(false, mccs);
		}


		public class Grouping : Check
		{
			internal readonly MerchantClassificationGroup[] groups;
			internal readonly bool? matchResult;

			internal Grouping(bool? matchResult, MerchantClassificationGroup[] groups)
			{
				this.groups = groups;
				this.matchResult = matchResult;
			}


			public virtual bool? matches(int checkMCC)
			{
				bool? result = null;

				if (groups != null)
				{
					foreach (MerchantClassificationGroup grp in groups)
					{
						if (grp.contains(checkMCC))
						{
							result = matchResult;
						}
					}
				}
				return result;
			}
		}


		public class Range : Check
		{
			internal readonly int min;
			internal readonly int max;
			internal readonly bool? matchResult;

			internal Range(bool? matchResult, int min, int max)
			{
				this.matchResult = matchResult;
				this.min = min;
				this.max = max;
			}


			public virtual bool? matches(int mcc)
			{
				return (min <= mcc) && (mcc <= max) ? matchResult : null;
			}
		}


		public class List : Check
		{
			internal readonly int[] mccs;
			internal readonly bool? matchResult;

			internal List(bool? matchResult, params int[] mccs)
			{
				this.matchResult = matchResult;
				this.mccs = mccs;
			}


			public virtual bool? matches(int checkMCC)
			{
				bool inList = false;

				if (mccs != null)
				{
					foreach (int mcc in mccs)
					{
						if (mcc == checkMCC)
						{
							inList = true;
							break;
						}
					}
				}
				return inList ? matchResult : null;
			}
		}


		public interface Check
		{
			bool? matches(int checkMCC);
		}


	}
}
