using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class TransactionService : AbstractService<Transaction>
    {
        public TransactionService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a transaction list
        /// </summary>
        /// <returns>Returns a list transactions-object</returns>
        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await GetListAsync(Resource.Transactions);
        }

        /// <summary>
        /// This function allows request a transaction list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list transaction-object</returns>
        public async Task<List<Transaction>> GetTransactionsAsync(Filter filter)
        {
            return await GetListAsync(Resource.Transactions, filter);
        }

        /// <summary>
        /// This function creates a transaction object
        /// </summary>
        /// <param name="transaction">Object-transaction</param>
        /// <returns>New object-transaction just add</returns>
        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            return await AddAsync(
                Resource.Transactions,
                transaction,
                null,
                new UrlEncoder().EncodeTransaction(transaction));
        }

        /// <summary>
        /// To GetAsync the details of an existing transaction you’ll need to supply the transaction ID
        /// </summary>
        /// <param name="transactionId">Client identifier</param>
        /// <returns>Client-object</returns>
        public async Task<Transaction> GetTransactionAsync(string transactionId)
        {
            return await GetAsync(Resource.Transactions, transactionId);
        }
    }
}