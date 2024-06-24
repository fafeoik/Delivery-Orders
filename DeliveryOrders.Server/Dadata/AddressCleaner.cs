using Dadata;
using Dadata.Model;

namespace DeliveryOrders.Server.Dadata
{
    public static class AddressCleaner
    {
        public static async Task<string> CleanAddress(string addressLine, string cityName)
        {
            var api = GetApi();

            var address = (await api.Clean<Address>(cityName + " " + addressLine)).result;

            string result = address.Substring(address.IndexOf(',') + 2);

            if( result != null)
            {
                return result;
            }

            return addressLine;
        }

        public static async Task<string> CleanCity(string addressLine, string cityName)
        {
            var api = GetApi();

            var address = (await api.Clean<Address>(cityName + " " + addressLine));
            string result = address.result.Substring(2, address.result.IndexOf(',') - 2);

            if (result != null)
            {
                return result;
            }

            return cityName;
        }

        private static CleanClientAsync GetApi()
        {
            var token = "40bd0a87bbec83ce5b2b1dd485f25a89e4aba61c";
            var secret = "2a8e5459c2b9a50fa832b00eab5246d6152a41f7";

            return new CleanClientAsync(token, secret);
        }
    }
}
