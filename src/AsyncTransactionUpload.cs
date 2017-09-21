using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient
{
#if NET45 || PORTABLE
    /// <summary>
    /// This class contains a method to upload transactions in bulk using multiple threads.
    /// Please ensure that concurrency is set to an appropriate value.
    /// </summary>
    public class AsyncTransactionUpload
    {
        /// <summary>
        /// Represents the results from a threaded transaction API call
        /// </summary>
        public class ThreadedTransactionResult
        {
            /// <summary>
            /// Errors received
            /// </summary>
            public List<AvaTaxError> Errors { get; set; }

            /// <summary>
            /// Transactions created
            /// </summary>
            public List<TransactionModel> TransactionsCreated { get; set; }
        }

        /// <summary>
        /// Create multiple transactions using the async behavior 
        /// </summary>
        /// <param name="models">The transactions to create</param>
        /// <param name="concurrency">Number of threads to use</param>
        /// <param name="client">The AvaTaxClient object to use</param>
        /// <param name="include">The include values to send</param>
        /// <returns></returns>
        public static async Task<ThreadedTransactionResult> CreateMultipleTransactions(AvaTaxClient client, List<CreateTransactionModel> models, string include, int concurrency)
        {
            // Limit concurrency to a sensible maximum
            if (concurrency > 10) throw new Exception("Please do not run more than 10 threads simultaneously.");

            // Prepare our result
            var result = new ThreadedTransactionResult();
            result.Errors = new List<AvaTaxError>();
            result.TransactionsCreated = new List<TransactionModel>();

            // Start launching threads with the specified concurrency level
            List<Task> allTasks = new List<Task>();
            using (SemaphoreSlim semaphore = new SemaphoreSlim(concurrency)) {

                // Run all your tasks
                foreach (var model in models) {
                    await semaphore.WaitAsync();
                    allTasks.Add(Task.Run(async () => {
                        try {
                            System.Diagnostics.Debug.WriteLine($"Beginning {model.code}");
                            var transaction = await client.CreateTransactionAsync(null, model);
                            result.TransactionsCreated.Add(transaction);
                        } catch (AvaTaxError err) {
                            result.Errors.Add(err);
                        } finally {
                            System.Diagnostics.Debug.WriteLine($"Finishing {model.code}");
                            semaphore.Release();
                        }
                    }));
                }

                // Wait until everything is done
                await Task.WhenAll(allTasks);
                return result;
            }
        }
    }
#endif
}
