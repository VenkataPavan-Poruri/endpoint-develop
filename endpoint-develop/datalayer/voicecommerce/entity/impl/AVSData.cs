namespace datalayer.voicecommerce.entity.impl
{
    public sealed class AVSData
    {
        private string address;
        private string postalCode;

        public AVSData(string address, string postalCode)
        {
            this.address = address;
            this.postalCode = postalCode;
        }
    }
}
