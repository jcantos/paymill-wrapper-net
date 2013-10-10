using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class ClientService : AbstractService<Client>
    {
        public ClientService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }
        
        /// <summary>
        /// This function allows request a client list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list clients-object</returns>
        public async Task<IReadOnlyCollection<Client>> GetAsync(Filter filter = null)
        {
            return await GetAsync(Resource.Clients, filter);
        }

        /// <summary>
        /// This function creates a client object
        /// </summary>
        /// <param name="client">Object-client</param>
        /// <returns>New object-client just add</returns>
        public async Task<Client> AddAsync(Client client)
        {
            return await AddAsync(
                Resource.Clients,
                client,
                null,
                new UrlEncoder().Encode<Client>(client));
        }
        
        /// <summary>
        /// To GetAsync the details of an existing client you’ll need to supply the client ID
        /// </summary>
        /// <param name="clientId">Client identifier</param>
        /// <returns>Client-object</returns>
        public async Task<Client> GetAsync(string clientId)
        {
            return await GetAsync(Resource.Clients, clientId);
        }

        /// <summary>
        /// This function deletes a client, but your transactions aren’t deleted
        /// </summary>
        /// <param name="clientId">Client identifier</param>
        /// <returns>Return true if remove was ok, false if not possible</returns>
        public async Task<bool> RemoveAsync(string clientId)
        {
            return await RemoveAsync(Resource.Clients, clientId);
        }

        /// <summary>
        /// This function updates the data of a client
        /// </summary>
        /// <param name="client">Object-client</param>
        /// <returns>Object-client just updated</returns>
        public async Task<Client> UpdateAsync(Client client)
        {
            return await UpdateAsync(
                Resource.Clients,
                client,
                client.Id,
                new UrlEncoder().EncodeClientUpdate(client));
        }
    }
}