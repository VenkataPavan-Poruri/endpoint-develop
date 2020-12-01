namespace datalayer.voicecommerce.model.card
{
    public interface Card
    {
        CardDate ExpiryDate { get; }
        PANRange PANRange { get; }

        PANRange getPANRange();
    }
}
