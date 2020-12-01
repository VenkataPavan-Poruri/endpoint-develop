namespace core_develop.cashflows.core.authorisation
{
    
    public enum ResponseCode
    {

        //UNKNOWN(-99, Action.UNKNOWN);
        UNKNOWN,
        NO_BIN_FOR_CARD_NUMBER,
        CARD_EXPIRY_DATE_INVALID,
        INVALID_TERMINAL,
        TERMINAL_NOT_LIVE,
        FUNDSRECIPIENT_MISSING,
        FUNDSRECIPIENT_INVALID,
        Action,
        TXN_TERMINAL_CONFIG_MISMATCH,
        COULD_NOT_DETERMINE_COST,
        CONCURRENT_AUTHS,
        COULD_NOT_CHECK_AUTH_LIMIT,
        CARD_AUTH_LIMIT_REACHED,
        SCHEME_AUTH_LIMIT_REACHED,
        FORMAT_ERROR,
    }
}
