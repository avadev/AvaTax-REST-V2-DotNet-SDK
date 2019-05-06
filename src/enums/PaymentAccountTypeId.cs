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
    /// The account type of the adjustment.
    /// </summary>
    public enum PaymentAccountTypeId
    {
        /// <summary>
        /// no account type
        /// </summary>
        None = 0,

        /// <summary>
        ///  Accounts receivable and accounts payable account type
        /// </summary>
        AccountsReceivableAccountsPayable = 1,

        /// <summary>
        /// Accounts receivable account type 
        /// </summary>
        AccountsReceivable = 2,

        /// <summary>
        /// Accounts payable account type
        /// </summary>
        AccountsPayable = 3,

    }
}
