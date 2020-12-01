using System.Collections.Generic;

namespace core_develop.cashflows.core.common
{
    public class CurrencyEnums
    {
        public string isoCode { get; set; }
        private int iso { get; set; }
        public string name { get; set; }
        public int MinorUnitPrecision { get; set; }
        public bool supported { get; set; }

        public CurrencyEnums(string isoCode, int iso, string name, int minorUnitPrecision, bool supported)
        {
            this.isoCode = isoCode;
            this.name = name;
            this.MinorUnitPrecision = minorUnitPrecision;
            this.supported = supported;
        }
    }
    public static class Currency
    {
        public static List<CurrencyEnums> currencynames = new List<CurrencyEnums>()
        {
           {new CurrencyEnums("AED", 784, "UAE Dirham", 2, true)},
{new CurrencyEnums("AFN", 971, "Afghani", 2, false)},
{new CurrencyEnums("ALL", 8, "Lek", 2, false)},
{new CurrencyEnums("AMD", 51, "Armenian Dram", 2, false)},
{new CurrencyEnums("ANG", 532, "Netherlands Antillian Guilder", 2, false)},
{new CurrencyEnums("AOA", 973, "Kwanza", 2, false)},
{new CurrencyEnums("ARS", 32, "Argentine Peso", 2, false)},
{new CurrencyEnums("AUD", 36, "Australian Dollar", 2, true)},
{new CurrencyEnums("AWG", 533, "Aruban Guilder", 2, false)},
{new CurrencyEnums("AZN", 944, "Azerbaijanian Manat", 2, false)},
{new CurrencyEnums("BAM", 977, "Convertible Marks", 2, false)},
{new CurrencyEnums("BBD", 52, "Barbados Dollar", 2, false)},
{new CurrencyEnums("BDT", 50, "Taka", 2, false)},
{new CurrencyEnums("BGN", 975, "Bulgarian Lev", 2, false)},
{new CurrencyEnums("BHD", 48, "Bahraini Dinar", 3, false)},
{new CurrencyEnums("BIF", 108, "Burundi Franc", 0, false)},
{new CurrencyEnums("BMD", 60, "Bermuda Dollar", 2, false)},
{new CurrencyEnums("BND", 96, "Brunei Dollar", 2, false)},
{new CurrencyEnums("BOB", 68, "Boliviano", 2, false)},
{new CurrencyEnums("BOV", 984, "Mvdol", 2, false)},
{new CurrencyEnums("BRL", 986, "Brazilian Real", 2, false)},
{new CurrencyEnums("BSD", 44, "Bahamian Dollar", 2, false)},
{new CurrencyEnums("BTN", 64, "Ngultrum", 2, false)},
{new CurrencyEnums("BWP", 72, "Pula", 2, false)},
{new CurrencyEnums("BYR", 974, "Belarussian Ruble", 0, false)},
{new CurrencyEnums("BZD", 84, "Belize Dollar", 2, false)},
{new CurrencyEnums("CAD", 124, "Canadian Dollar", 2, true)},
{new CurrencyEnums("CDF", 976, "Congolese Franc", 2, false)},
{new CurrencyEnums("CHF", 756, "Swiss Franc", 2, true)},
{new CurrencyEnums("CLF", 990, "Unidades de fomento", 0, false)},
{new CurrencyEnums("CLP", 152, "Chilean Peso", 0, false)},
{new CurrencyEnums("CNY", 156, "Yuan Renminbi", 2, false)},
{new CurrencyEnums("COP", 170, "Colombian Peso", 2, false)},
{new CurrencyEnums("COU", 970, "Unidad de Valor Real", 4, false)},
{new CurrencyEnums("CRC", 188, "Costa Rican Colon", 2, false)},
{new CurrencyEnums("CUP", 192, "Cuban Peso", 2, false)},
{new CurrencyEnums("CVE", 132, "Cape Verde Escudo", 0, false)},
{new CurrencyEnums("CZK", 203, "Czech Koruna", 2, false)},
{new CurrencyEnums("DJF", 262, "Djibouti Franc", 0, false)},
{new CurrencyEnums("DKK", 208, "Danish Krone", 2, true)},
{new CurrencyEnums("DOP", 214, "Dominican Peso", 2, false)},
{new CurrencyEnums("DZD", 12, "Algerian Dinar", 2, false)},
{new CurrencyEnums("EEK", 233, "Kroon", 2, false)},
{new CurrencyEnums("EGP", 818, "Egyptian Pound", 2, false)},
{new CurrencyEnums("ERN", 232, "Nakfa", 2, false)},
{new CurrencyEnums("ETB", 230, "Ethiopian Birr", 2, false)},
{new CurrencyEnums("EUR", 978, "Euro", 2, true)},
{new CurrencyEnums("FJD", 242, "Fiji Dollar", 2, false)},
{new CurrencyEnums("FKP", 238, "Falkland Islands Pound", 2, false)},
{new CurrencyEnums("GBP", 826, "Pound Sterling", 2, true)},
{new CurrencyEnums("GEL", 981, "Lari", 2, false)},
{new CurrencyEnums("GHS", 936, "Cedi", 2, false)},
{new CurrencyEnums("GIP", 292, "Gibraltar Pound", 2, false)},
{new CurrencyEnums("GMD", 270, "Dalasi", 2, false)},
{new CurrencyEnums("GNF", 324, "Guinea Franc", 0, false)},
{new CurrencyEnums("GTQ", 320, "Quetzal", 2, false)},
{new CurrencyEnums("GWP", 624, "Guinea-Bissau Peso", -1, false)},
{new CurrencyEnums("GYD", 328, "Guyana Dollar", 2, false)},
{new CurrencyEnums("HKD", 344, "Hong Kong Dollar", 2, true)},
{new CurrencyEnums("HNL", 340, "Lempira", 2, false)},
{new CurrencyEnums("HRK", 191, "Croatian Kuna", 2, false)},
{new CurrencyEnums("HTG", 332, "Gourde", 2, false)},
{new CurrencyEnums("HUF", 348, "Forint", 0, false)},
{new CurrencyEnums("IDR", 360, "Rupiah", 2, false)},
{new CurrencyEnums("ILS", 376, "New Israeli Sheqel", 2, false)},
{new CurrencyEnums("INR", 356, "Indian Rupee", 2, false)},
{new CurrencyEnums("IQD", 368, "Iraqi Dinar", 3, false)},
{new CurrencyEnums("IRR", 364, "Iranian Rial", 2, false)},
{new CurrencyEnums("ISK", 352, "Iceland Krona", 0, false)},
{new CurrencyEnums("JMD", 388, "Jamaican Dollar", 2, false)},
{new CurrencyEnums("JOD", 400, "Jordanian Dinar", 3, false)},
{new CurrencyEnums("JPY", 392, "Yen", 0, true)},
{new CurrencyEnums("KES", 404, "Kenyan Shilling", 2, false)},
{new CurrencyEnums("KGS", 417, "Som", 2, false)},
{new CurrencyEnums("KHR", 116, "Riel", 2, false)},
{new CurrencyEnums("KMF", 174, "Comoro Franc", 0, false)},
{new CurrencyEnums("KPW", 408, "North Korean Won", 2, false)},
{new CurrencyEnums("KRW", 410, "Won", 0, false)},
{new CurrencyEnums("KWD", 414, "Kuwaiti Dinar", 3, false)},
{new CurrencyEnums("KYD", 136, "Cayman Islands Dollar", 2, false)},
{new CurrencyEnums("KZT", 398, "Tenge", 2, false)},
{new CurrencyEnums("LAK", 418, "Kip", 2, false)},
{new CurrencyEnums("LBP", 422, "Lebanese Pound", 2, false)},
{new CurrencyEnums("LKR", 144, "Sri Lanka Rupee", 2, false)},
{new CurrencyEnums("LRD", 430, "Liberian Dollar", 2, false)},
{new CurrencyEnums("LSL", 426, "Loti", 2, false)},
{new CurrencyEnums("LTL", 440, "Lithuanian Litas", 2, false)},
{new CurrencyEnums("LVL", 428, "Latvian Lats", 2, false)},
{new CurrencyEnums("LYD", 434, "Libyan Dinar", 3, false)},
{new CurrencyEnums("MAD", 504, "Moroccan Dirham", 2, false)},
{new CurrencyEnums("MDL", 498, "Moldovan Leu", 2, false)},
{new CurrencyEnums("MGA", 969, "Malagasy Ariary", 2, false)},
{new CurrencyEnums("MKD", 807, "Denar", 2, false)},
{new CurrencyEnums("MMK", 104, "Kyat", 2, false)},
{new CurrencyEnums("MNT", 496, "Tugrik", 2, false)},
{new CurrencyEnums("MOP", 446, "Pataca", 2, false)},
{new CurrencyEnums("MRO", 478, "Ouguiya", 2, false)},
{new CurrencyEnums("MUR", 480, "Mauritius Rupee", 2, false)},
{new CurrencyEnums("MVR", 462, "Rufiyaa", 2, false)},
{new CurrencyEnums("MWK", 454, "Kwacha", 2, false)},
{new CurrencyEnums("MXN", 484, "Mexican Peso", 2, false)},
{new CurrencyEnums("MXV", 979, "Mexican UDI", 2, false)},
{new CurrencyEnums("MYR", 458, "Malaysian Ringgit", 2, false)},
{new CurrencyEnums("MZN", 943, "Metical", 2, false)},
{new CurrencyEnums("NAD", 516, "Namibia Dollar", 2, false)},
{new CurrencyEnums("NGN", 566, "Naira", 2, false)},
{new CurrencyEnums("NIO", 558, "Cordoba Oro", 2, false)},
{new CurrencyEnums("NOK", 578, "Norwegian Krone", 2, true)},
{new CurrencyEnums("NPR", 524, "Nepalese Rupee", 2, false)},
{new CurrencyEnums("NZD", 554, "New Zealand Dollar", 2, true)},
{new CurrencyEnums("OMR", 512, "Rial Omani", 3, false)},
{new CurrencyEnums("PAB", 590, "Balboa", 2, false)},
{new CurrencyEnums("PEN", 604, "Nuevo Sol", 2, false)},
{new CurrencyEnums("PGK", 598, "Kina", 2, false)},
{new CurrencyEnums("PHP", 608, "Philippine Peso", 2, false)},
{new CurrencyEnums("PKR", 586, "Pakistan Rupee", 2, false)},
{new CurrencyEnums("PLN", 985, "Zloty", 2, false)},
{new CurrencyEnums("PYG", 600, "Guarani", 0, false)},
{new CurrencyEnums("QAR", 634, "Qatari Rial", 2, false)},
{new CurrencyEnums("RON", 946, "New Leu", 2, false)},
{new CurrencyEnums("RSD", 941, "Serbian Dinar", 2, false)},
{new CurrencyEnums("RUB", 643, "Russian Ruble", 2, false)},
{new CurrencyEnums("RWF", 646, "Rwanda Franc", 0, false)},
{new CurrencyEnums("SAR", 682, "Saudi Riyal", 2, false)},
{new CurrencyEnums("SBD", 90, "Solomon Islands Dollar", 2, false)},
{new CurrencyEnums("SCR", 690, "Seychelles Rupee", 2, false)},
{new CurrencyEnums("SDG", 938, "Sudanese Pound", 2, false)},
{new CurrencyEnums("SEK", 752, "Swedish Krona", 2, true)},
{new CurrencyEnums("SGD", 702, "Singapore Dollar", 2, true)},
{new CurrencyEnums("SHP", 654, "Saint Helena Pound", 2, false)},
{new CurrencyEnums("SLL", 694, "Leone", 2, false)},
{new CurrencyEnums("SOS", 706, "Somali Shilling", 2, false)},
{new CurrencyEnums("SRD", 968, "Surinam Dollar", 2, false)},
{new CurrencyEnums("SSP", 728, "South Sudanese pound", 2, false)},
{new CurrencyEnums("STD", 678, "Dobra", 2, false)},
{new CurrencyEnums("SVC", 222, "El Salvador Colon", -1, false)},
{new CurrencyEnums("SYP", 760, "Syrian Pound", 2, false)},
{new CurrencyEnums("SZL", 748, "Lilangeni", 2, false)},
{new CurrencyEnums("THB", 764, "Baht", 2, false)},
{new CurrencyEnums("TJS", 972, "Somoni",2, false)},
{new CurrencyEnums("TMT", 934, "Manat", 2, false)},
{new CurrencyEnums("TND", 788, "Tunisian Dinar", 3, false)},
{new CurrencyEnums("TOP", 776, "Pa'anga", 2, false)},
{new CurrencyEnums("TRY", 949, "Turkish Lira", 2, false)},
{new CurrencyEnums("TTD", 780, "Trinidad and Tobago Dollar", 2, false)},
{new CurrencyEnums("TWD", 901, "New Taiwan Dollar", 2, false)},
{new CurrencyEnums("TZS", 834, "Tanzanian Shilling", 2, false)},
{new CurrencyEnums("UAH", 980, "Hryvnia", 2, false)},
{new CurrencyEnums("UGX", 800, "Uganda Shilling", 0, false)},
{new CurrencyEnums("USD", 840, "US Dollar", 2, true)},
{new CurrencyEnums("UYI", 940, "Uruguay Peso en Unidades Indexadas", 0, false)},
{new CurrencyEnums("UYU", 858, "Peso Uruguayo", 2, false)},
{new CurrencyEnums("UZS", 860, "Uzbekistan Sum", 2, false)},
{new CurrencyEnums("VEF", 937, "Bolivar Fuerte", 2, false)},
{new CurrencyEnums("VES", 928, "Bolívar Soberano", 2, false)},
{new CurrencyEnums("VND", 704, "Dong", 0, false)},
{new CurrencyEnums("VUV", 548, "Vatu", 0, false)},
{new CurrencyEnums("WST", 882, "Tala", 2, false)},
{new CurrencyEnums("XAF", 950, "CFA Franc BEAC", 0, false)},
{new CurrencyEnums("XCD", 951, "East Caribbean Dollar", 2, false)},
{new CurrencyEnums("XOF", 952, "CFA Franc BCEAO", 0, false)},
{new CurrencyEnums("XPF", 953, "CFP Franc", 0, false)},
{new CurrencyEnums("YER", 886, "Yemeni Rial", 2, false)},
{new CurrencyEnums("ZAR", 710, "Rand", 2, true)},
{new CurrencyEnums("ZMK", 894, "Zambian Kwacha", 2, false)},
{new CurrencyEnums("ZWR", 935, "Zimbabwe Dollar", 2, false)},

 };


        public static CurrencyEnums AED = currencynames[0];
        public static CurrencyEnums AFN = currencynames[1];
        public static CurrencyEnums ALL = currencynames[2];
        public static CurrencyEnums AMD = currencynames[3];
        public static CurrencyEnums ANG = currencynames[4];
        public static CurrencyEnums AOA = currencynames[5];
        public static CurrencyEnums ARS = currencynames[6];
        public static CurrencyEnums AUD = currencynames[7];
        public static CurrencyEnums AWG = currencynames[8];
        public static CurrencyEnums AZN = currencynames[9];
        public static CurrencyEnums BAM = currencynames[10];
        public static CurrencyEnums BBD = currencynames[11];
        public static CurrencyEnums BDT = currencynames[12];
        public static CurrencyEnums BGN = currencynames[13];
        public static CurrencyEnums BHD = currencynames[14];
        public static CurrencyEnums BIF = currencynames[15];
        public static CurrencyEnums BMD = currencynames[16];
        public static CurrencyEnums BND = currencynames[17];
        public static CurrencyEnums BOB = currencynames[18];
        public static CurrencyEnums BOV = currencynames[19];
        public static CurrencyEnums BRL = currencynames[20];
        public static CurrencyEnums BSD = currencynames[21];
        public static CurrencyEnums BTN = currencynames[22];
        public static CurrencyEnums BWP = currencynames[23];
        public static CurrencyEnums BYR = currencynames[24];
        public static CurrencyEnums BZD = currencynames[25];
        public static CurrencyEnums CAD = currencynames[26];
        public static CurrencyEnums CDF = currencynames[27];
        public static CurrencyEnums CHF = currencynames[28];
        public static CurrencyEnums CLF = currencynames[29];
        public static CurrencyEnums CLP = currencynames[30];
        public static CurrencyEnums CNY = currencynames[31];
        public static CurrencyEnums COP = currencynames[32];
        public static CurrencyEnums COU = currencynames[33];
        public static CurrencyEnums CRC = currencynames[34];
        public static CurrencyEnums CUP = currencynames[35];
        public static CurrencyEnums CVE = currencynames[36];
        public static CurrencyEnums CZK = currencynames[37];
        public static CurrencyEnums DJF = currencynames[38];
        public static CurrencyEnums DKK = currencynames[39];
        public static CurrencyEnums DOP = currencynames[40];
        public static CurrencyEnums DZD = currencynames[41];
        public static CurrencyEnums EEK = currencynames[42];
        public static CurrencyEnums EGP = currencynames[43];
        public static CurrencyEnums ERN = currencynames[44];
        public static CurrencyEnums ETB = currencynames[45];
        public static CurrencyEnums EUR = currencynames[46];
        public static CurrencyEnums FJD = currencynames[47];
        public static CurrencyEnums FKP = currencynames[48];
        public static CurrencyEnums GBP = currencynames[49];
        public static CurrencyEnums GEL = currencynames[50];
        public static CurrencyEnums GHS = currencynames[51];
        public static CurrencyEnums GIP = currencynames[52];
        public static CurrencyEnums GMD = currencynames[53];
        public static CurrencyEnums GNF = currencynames[54];
        public static CurrencyEnums GTQ = currencynames[55];
        public static CurrencyEnums GWP = currencynames[56];
        public static CurrencyEnums GYD = currencynames[57];
        public static CurrencyEnums HKD = currencynames[58];
        public static CurrencyEnums HNL = currencynames[59];
        public static CurrencyEnums HRK = currencynames[60];
        public static CurrencyEnums HTG = currencynames[61];
        public static CurrencyEnums HUF = currencynames[62];
        public static CurrencyEnums IDR = currencynames[63];
        public static CurrencyEnums ILS = currencynames[64];
        public static CurrencyEnums INR = currencynames[65];
        public static CurrencyEnums IQD = currencynames[66];
        public static CurrencyEnums IRR = currencynames[67];
        public static CurrencyEnums ISK = currencynames[68];
        public static CurrencyEnums JMD = currencynames[69];
        public static CurrencyEnums JOD = currencynames[70];
        public static CurrencyEnums JPY = currencynames[71];
        public static CurrencyEnums KES = currencynames[72];
        public static CurrencyEnums KGS = currencynames[73];
        public static CurrencyEnums KHR = currencynames[74];
        public static CurrencyEnums KMF = currencynames[75];
        public static CurrencyEnums KPW = currencynames[76];
        public static CurrencyEnums KRW = currencynames[77];
        public static CurrencyEnums KWD = currencynames[78];
        public static CurrencyEnums KYD = currencynames[79];
        public static CurrencyEnums KZT = currencynames[80];
        public static CurrencyEnums LAK = currencynames[81];
        public static CurrencyEnums LBP = currencynames[82];
        public static CurrencyEnums LKR = currencynames[83];
        public static CurrencyEnums LRD = currencynames[84];
        public static CurrencyEnums LSL = currencynames[85];
        public static CurrencyEnums LTL = currencynames[86];
        public static CurrencyEnums LVL = currencynames[87];
        public static CurrencyEnums LYD = currencynames[88];
        public static CurrencyEnums MAD = currencynames[89];
        public static CurrencyEnums MDL = currencynames[90];
        public static CurrencyEnums MGA = currencynames[91];
        public static CurrencyEnums MKD = currencynames[92];
        public static CurrencyEnums MMK = currencynames[93];
        public static CurrencyEnums MNT = currencynames[94];
        public static CurrencyEnums MOP = currencynames[95];
        public static CurrencyEnums MRO = currencynames[96];
        public static CurrencyEnums MUR = currencynames[97];
        public static CurrencyEnums MVR = currencynames[98];
        public static CurrencyEnums MWK = currencynames[99];
        public static CurrencyEnums MXN = currencynames[100];
        public static CurrencyEnums MXV = currencynames[101];
        public static CurrencyEnums MYR = currencynames[102];
        public static CurrencyEnums MZN = currencynames[103];
        public static CurrencyEnums NAD = currencynames[104];
        public static CurrencyEnums NGN = currencynames[105];
        public static CurrencyEnums NIO = currencynames[106];
        public static CurrencyEnums NOK = currencynames[107];
        public static CurrencyEnums NPR = currencynames[108];
        public static CurrencyEnums NZD = currencynames[109];
        public static CurrencyEnums OMR = currencynames[110];
        public static CurrencyEnums PAB = currencynames[111];
        public static CurrencyEnums PEN = currencynames[112];
        public static CurrencyEnums PGK = currencynames[113];
        public static CurrencyEnums PHP = currencynames[114];
        public static CurrencyEnums PKR = currencynames[115];
        public static CurrencyEnums PLN = currencynames[116];
        public static CurrencyEnums PYG = currencynames[117];
        public static CurrencyEnums QAR = currencynames[118];
        public static CurrencyEnums RON = currencynames[119];
        public static CurrencyEnums RSD = currencynames[120];
        public static CurrencyEnums RUB = currencynames[121];
        public static CurrencyEnums RWF = currencynames[122];
        public static CurrencyEnums SAR = currencynames[123];
        public static CurrencyEnums SBD = currencynames[124];
        public static CurrencyEnums SCR = currencynames[125];
        public static CurrencyEnums SDG = currencynames[126];
        public static CurrencyEnums SEK = currencynames[127];
        public static CurrencyEnums SGD = currencynames[128];
        public static CurrencyEnums SHP = currencynames[129];
        public static CurrencyEnums SLL = currencynames[130];
        public static CurrencyEnums SOS = currencynames[131];
        public static CurrencyEnums SRD = currencynames[132];
        public static CurrencyEnums SSP = currencynames[133];
        public static CurrencyEnums STD = currencynames[134];
        public static CurrencyEnums SVC = currencynames[135];
        public static CurrencyEnums SYP = currencynames[136];
        public static CurrencyEnums SZL = currencynames[137];
        public static CurrencyEnums THB = currencynames[138];
        public static CurrencyEnums TJS = currencynames[139];
        public static CurrencyEnums TMT = currencynames[140];
        public static CurrencyEnums TND = currencynames[141];
        public static CurrencyEnums TOP = currencynames[142];
        public static CurrencyEnums TRY = currencynames[143];
        public static CurrencyEnums TTD = currencynames[144];
        public static CurrencyEnums TWD = currencynames[145];
        public static CurrencyEnums TZS = currencynames[146];
        public static CurrencyEnums UAH = currencynames[147];
        public static CurrencyEnums UGX = currencynames[148];
        public static CurrencyEnums USD = currencynames[149];
        public static CurrencyEnums UYI = currencynames[150];
        public static CurrencyEnums UYU = currencynames[151];
        public static CurrencyEnums UZS = currencynames[152];
        public static CurrencyEnums VEF = currencynames[153];
        public static CurrencyEnums VES = currencynames[154];
        public static CurrencyEnums VND = currencynames[155];
        public static CurrencyEnums VUV = currencynames[156];
        public static CurrencyEnums WST = currencynames[157];
        public static CurrencyEnums XAF = currencynames[158];
        public static CurrencyEnums XCD = currencynames[159];
        public static CurrencyEnums XOF = currencynames[160];
        public static CurrencyEnums XPF = currencynames[161];
        public static CurrencyEnums YER = currencynames[162];
        public static CurrencyEnums ZAR = currencynames[163];
        public static CurrencyEnums ZMK = currencynames[164];
        public static CurrencyEnums ZWR = currencynames[165];


    }
}