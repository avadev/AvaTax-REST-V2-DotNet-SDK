using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Status when deleting an error transaction
    /// </summary>
    public enum AvataxDeleteErrorTransactionStatus
    {
        /// <summary>
        /// Successful delete
        /// </summary>
        Success = 0,

        /// <summary>
        /// Failed delete
        /// </summary>
        Failure = 1,

    }
}
