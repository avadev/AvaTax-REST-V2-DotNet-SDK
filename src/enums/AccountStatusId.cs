using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
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
        Inactive,

        /// <summary>
        /// This account is active and in use.
        /// </summary>
        Active,

        /// <summary>
        /// This account is flagged as a test account and may be temporary.
        /// </summary>
        Test,

        /// <summary>
        /// The account is new and is currently in the onboarding process.
        ///  
        ///  An account is considered new until the account administrator has reviewed and accepted 
        ///  [Avalara's terms and conditions](https://www.avalara.com/us/en/legal/terms.html).
        /// </summary>
        New,

    }
}
