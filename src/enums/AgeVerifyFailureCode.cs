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
 * Swagger name: AvaTaxBeverageClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public enum AgeVerifyFailureCode
    {
        /// <summary>
        /// 
        /// </summary>
        not_found = 0,

        /// <summary>
        /// 
        /// </summary>
        dob_unverifiable = 1,

        /// <summary>
        /// 
        /// </summary>
        under_age = 2,

        /// <summary>
        /// 
        /// </summary>
        suspected_fraud = 3,

        /// <summary>
        /// 
        /// </summary>
        deceased = 4,

        /// <summary>
        /// 
        /// </summary>
        unknown_error = 5,

    }
}
