using System.Net.Http;

namespace ArkEcosystem.Client.Connections
{
    public interface IConnection
    {
        void SetClient(HttpClient httpClient);
    }
}
