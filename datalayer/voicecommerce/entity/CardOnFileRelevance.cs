using System;
using System.Collections.Generic;
using System.Text;

namespace datalayer.voicecommerce.entity
{
    public sealed class CardOnFileRelevance
    {
        public static readonly CardOnFileRelevance IRRELEVANT = new CardOnFileRelevance("IRRELEVANT", InnerEnum.IRRELEVANT, false);
        public static readonly CardOnFileRelevance INITIAL = new CardOnFileRelevance("INITIAL", InnerEnum.INITIAL, false);
        public static readonly CardOnFileRelevance SUBSEQUENT = new CardOnFileRelevance("SUBSEQUENT", InnerEnum.SUBSEQUENT, true);
        public static readonly CardOnFileRelevance LEGACY_SUBSEQUENT = new CardOnFileRelevance("LEGACY_SUBSEQUENT", InnerEnum.LEGACY_SUBSEQUENT, true);

        private static readonly List<CardOnFileRelevance> valueList = new List<CardOnFileRelevance>();

        static CardOnFileRelevance()
        {
            valueList.Add(IRRELEVANT);
            valueList.Add(INITIAL);
            valueList.Add(SUBSEQUENT);
            valueList.Add(LEGACY_SUBSEQUENT);
        }

        public enum InnerEnum
        {
            IRRELEVANT,
            INITIAL,
            SUBSEQUENT,
            LEGACY_SUBSEQUENT
        }

        public readonly InnerEnum innerEnumValue;
        private readonly string nameValue;
        private readonly int ordinalValue;
        private static int nextOrdinal = 0;

        private readonly bool repeating;


        internal CardOnFileRelevance(string name, InnerEnum innerEnum, bool repeating)
        {
            this.repeating = repeating;

            nameValue = name;
            ordinalValue = nextOrdinal++;
            innerEnumValue = innerEnum;
        }


        /// <summary>
        /// Whether the relevance represents a transaction that can repeat in a card holder agreed
        /// sequence.
        /// </summary>
        public bool Repeating
        {
            get
            {
                return repeating;
            }
        }



        public static CardOnFileRelevance[] values()
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

        public static CardOnFileRelevance valueOf(string name)
        {
            foreach (CardOnFileRelevance enumInstance in CardOnFileRelevance.valueList)
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
