using System.Collections.Generic;

namespace datalayer.voicecommerce.entity
{
    public sealed class RecurrenceFlag
    {
		/// <summary>
		/// A one-off transaction </summary>
		public static readonly RecurrenceFlag SINGLE = new RecurrenceFlag("SINGLE", InnerEnum.SINGLE);
		/// <summary>
		/// Legacy: A subscription recurring transaction - ie. paying before service delivered </summary>
		public static readonly RecurrenceFlag SUBSCRIPTION = new RecurrenceFlag("SUBSCRIPTION", InnerEnum.SUBSCRIPTION, CardOnFileRelevance.LEGACY_SUBSEQUENT);
		/// <summary>
		/// Legacy: An installment recurring transaction - i.e. paying after service delivered </summary>
		public static readonly RecurrenceFlag INSTALMENT = new RecurrenceFlag("INSTALMENT", InnerEnum.INSTALMENT, CardOnFileRelevance.LEGACY_SUBSEQUENT);
		/// <summary>
		/// The initial sale for card holder initiated sequence </summary>
		public static readonly RecurrenceFlag INIT_CARDHOLDER = new RecurrenceFlag("INIT_CARDHOLDER", InnerEnum.INIT_CARDHOLDER, CardOnFileRelevance.INITIAL);
		/// <summary>
		/// The initial sale for an unscheduled sequence </summary>
		public static readonly RecurrenceFlag INIT_UNSCHED = new RecurrenceFlag("INIT_UNSCHED", InnerEnum.INIT_UNSCHED, CardOnFileRelevance.INITIAL);
		/// <summary>
		/// The initial sale for a subscription COF sequence </summary>
		public static readonly RecurrenceFlag INIT_SUBSCRIPT = new RecurrenceFlag("INIT_SUBSCRIPT", InnerEnum.INIT_SUBSCRIPT, CardOnFileRelevance.INITIAL);
		/// <summary>
		/// The initial sale for an installment COF sequence </summary>
		public static readonly RecurrenceFlag INIT_INSTALMENT = new RecurrenceFlag("INIT_INSTALMENT", InnerEnum.INIT_INSTALMENT, CardOnFileRelevance.INITIAL);
		/// <summary>
		/// Merchant initiated COF (subsequent) transaction * </summary>
		public static readonly RecurrenceFlag SUBS_UNSCHED = new RecurrenceFlag("SUBS_UNSCHED", InnerEnum.SUBS_UNSCHED, CardOnFileRelevance.SUBSEQUENT);
		/// <summary>
		/// Card Holder initiated COF (subsequent) transaction * </summary>
		public static readonly RecurrenceFlag SUBS_CARDHOLDER = new RecurrenceFlag("SUBS_CARDHOLDER", InnerEnum.SUBS_CARDHOLDER, CardOnFileRelevance.SUBSEQUENT);
		/// <summary>
		/// Subsequent installment * </summary>
		public static readonly RecurrenceFlag SUBS_INSTALMENT = new RecurrenceFlag("SUBS_INSTALMENT", InnerEnum.SUBS_INSTALMENT, CardOnFileRelevance.SUBSEQUENT);
		/// <summary>
		/// Subsequent subscription * </summary>
		public static readonly RecurrenceFlag SUBS_SUBSCRIPT = new RecurrenceFlag("SUBS_SUBSCRIPT", InnerEnum.SUBS_SUBSCRIPT, CardOnFileRelevance.SUBSEQUENT);
		// Legacy: Support for a new recurrence type.
		public static readonly RecurrenceFlag CARDHOLDER = new RecurrenceFlag("CARDHOLDER", InnerEnum.CARDHOLDER, CardOnFileRelevance.LEGACY_SUBSEQUENT);
		// Legacy: Support for a new recurrence type.
		public static readonly RecurrenceFlag UNSCHEDULED = new RecurrenceFlag("UNSCHEDULED", InnerEnum.UNSCHEDULED, CardOnFileRelevance.LEGACY_SUBSEQUENT);

		private static readonly List<RecurrenceFlag> valueList = new List<RecurrenceFlag>();

		static RecurrenceFlag()
		{
			valueList.Add(SINGLE);
			valueList.Add(SUBSCRIPTION);
			valueList.Add(INSTALMENT);
			valueList.Add(INIT_CARDHOLDER);
			valueList.Add(INIT_UNSCHED);
			valueList.Add(INIT_SUBSCRIPT);
			valueList.Add(INIT_INSTALMENT);
			valueList.Add(SUBS_UNSCHED);
			valueList.Add(SUBS_CARDHOLDER);
			valueList.Add(SUBS_INSTALMENT);
			valueList.Add(SUBS_SUBSCRIPT);
			valueList.Add(CARDHOLDER);
			valueList.Add(UNSCHEDULED);
		}

		public enum InnerEnum
		{
			SINGLE,
			SUBSCRIPTION,
			INSTALMENT,
			INIT_CARDHOLDER,
			INIT_UNSCHED,
			INIT_SUBSCRIPT,
			INIT_INSTALMENT,
			SUBS_UNSCHED,
			SUBS_CARDHOLDER,
			SUBS_INSTALMENT,
			SUBS_SUBSCRIPT,
			CARDHOLDER,
			UNSCHEDULED
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;
        private CardOnFileRelevance iRRELEVANT;
        private readonly CardOnFileRelevance cofRelevance;


		private RecurrenceFlag(string name, InnerEnum innerEnum) : this(CardOnFileRelevance.IRRELEVANT)
		{

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}


		private RecurrenceFlag(string name, InnerEnum innerEnum, CardOnFileRelevance relevance)
		{
			this.cofRelevance = relevance;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

        public RecurrenceFlag(CardOnFileRelevance iRRELEVANT)
        {
            this.iRRELEVANT = iRRELEVANT;
        }

        public CardOnFileRelevance CardOnFileRelevance
		{
			get
			{
				return cofRelevance;
			}
		}

		public static RecurrenceFlag[] values()
		{
			return valueList.ToArray();
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static RecurrenceFlag valueOf(string name)
		{
			foreach (RecurrenceFlag enumInstance in RecurrenceFlag.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}
}
