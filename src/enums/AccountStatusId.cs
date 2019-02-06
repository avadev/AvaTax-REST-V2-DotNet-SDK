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
    /// Status of an Avalara account
    /// </summary>
    public enum AccountStatusId
    {
        /// <summary>
        /// This account is not currently active.
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// This account is active and in use.
        /// </summary>
        Active = 1,

        /// <summary>
        /// This account is flagged as a test account and may be temporary.
        /// </summary>
        Test = 2,

        /// <summary>
        /// The account is new and is currently in the onboarding process.
        ///  
        ///  An account is considered new until the account administrator has reviewed and accepted 
        ///  [Avalara's terms and conditions](https://www.avalara.com/us/en/legal/terms.html).
        /// </summary>
        New = 3,

    }
}
