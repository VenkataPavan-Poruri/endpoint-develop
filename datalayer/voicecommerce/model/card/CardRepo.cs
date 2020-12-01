using datalayer.voicecommerce.entity.impl;

namespace datalayer.voicecommerce.model.card
{
    public interface CardRepo
    {
        CardRepo_CardBuilder builder();
    }
    public interface CardRepo_CardBuilder
    {
        CardRepo_CardBuilder setNumber(CardNumber cardNumber);
        CardRepo_CardBuilder setIssueDate(CardDate issueDate);
        CardRepo_CardBuilder setExpiryDate(CardDate expiry);
        CardRepo_CardBuilder setAVSData(AVSData avsData);
        CardRepo_CardBuilder setCVV(string cvv);
    }
}
