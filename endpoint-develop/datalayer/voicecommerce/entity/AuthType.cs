namespace datalayer.voicecommerce.entity
{
    public enum AuthType
    {
        CONTACTLESS_CHIPDATA,
        //Contact-less transaction with MSD (Magnetic Stripe Data) Rules
        CONTACTLESS_MAGSTRIPE,
        //Contact integrated circuit card read using chip data rules
        CHIPREAD,
        //ChipRead and MSI (Magnetic Stripe Image) might be unreliable
        CHIPREAD_CONSTRUCTED,
        //Magnetic stripe read and exact content of Track included
        MAGSTRIPE,
        //Magnetic stripe read and MSD might be unreliable
        MAGSTRIPE_CONSTRUCTED,
        //Manual key entry
        CARD_PRESENT_MANUAL,
        MOTO,
        ECOM
    }
}
