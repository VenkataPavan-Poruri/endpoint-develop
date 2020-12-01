namespace endpoint_service.service.xml
{
    public class MoneyXML
    {

		public double? amount;
		public string currencyCode;
		public long? cashback;

  //      	public MoneyXML(double? amount, string currencyCode, long? cashback)
		//{
		//	this.currencyCode = currencyCode;
		//	this.amount = amount;
		//	this.cashback = cashback;
		//}

		public virtual string CurrencyCode
		{
			get
			{
				return currencyCode;
			}
			set
			{
				this.currencyCode = value;
			}
		}


		public virtual double? Amount
		{
			get
			{
				return amount;
			}
			set
			{
				this.amount = value;
			}
		}


		public virtual long? Cashback
		{
			get
			{
				return cashback;
			}
			set
			{
				this.cashback = value;
			}
		}


		//public override string ToString()
		//{
		//	 return (new ToStringBuilder(this)).append("amount", amount).append("currencyCode", currencyCode).append("cashback", cashback).ToString();
		//}
    }
}
