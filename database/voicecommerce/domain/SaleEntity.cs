using System;

namespace database.voicecommerce.domain
{
    public class SaleEntity
    {
        public string Reference { get; set; }
        public Int64 Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string EncCardNumber { get; set; }
        public string HashedCardNumber { get; set; } // hashed value used in searches
        public string ObfuscatedCardNumber { get; set; } // 6 * 4 format
        public string ExpiryDate { get; set; }
        public string IssueDate { get; set; }
        public string CardholderAddress { get; set; }
        public string PostalCode { get; set; }
        public string Mid { get; set; }
        public string Tid { get; set; }
        public string Bid { get; set; }
        public string TerminalCurrencyCode { get; set; } // NOPMD - Don't use any more.
        public string AuthType { get; set; }
        public string RecurrenceFlag { get; set; }
        public DateTime Timestamp { get; set; }
        public int EciFlag { get; set; }
        public string Xid { get; set; }
        public string AcsData { get; set; }
        public string ProgProtocol { get; set; }
        public string DsTransId { get; set; }
        public Int64 Stan { get; set; }
        public int Ttn { get; set; }
        public DateTime RecipientDOB { get; set; }
        public string RecipientSurname { get; set; }
        public string RecipientAccountNumber { get; set; }
        public string RecipientPostalCode { get; set; }
        public Int64 ExplicitAcceptorId { get; set; }
        public string SoftDescriptor { get; set; }
        public string InitialSaleARN { get; set; }
        public string AuthMode { get; set; }
        public Boolean DebtRepayFlag { get; set; }
        public Int64 ChipDataId { get; set; }
        public int CardSequenceNumber { get; set; }
        public Int64 OtherAmountsTransaction { get; set; }
        public Boolean FallBackFlag { get; set; }
        public DateTime LocalTransTimestamp { get; set; }
        public string TrackTwoServiceCode { get; set; }
        public string ExemptionIndicator { get; set; }
        public Int64 Id { get; set; }
    }
}