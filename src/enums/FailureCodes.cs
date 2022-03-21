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
    public enum FailureCodes
    {
        /// <summary>
        /// 
        /// </summary>
        BelowLegalDrinkingAge = 0,

        /// <summary>
        /// 
        /// </summary>
        ShippingProhibitedToAddress = 1,

        /// <summary>
        /// 
        /// </summary>
        MissingRequiredLicense = 2,

        /// <summary>
        /// 
        /// </summary>
        VolumeLimitExceeded = 3,

        /// <summary>
        /// 
        /// </summary>
        InvalidFieldValue = 4,

        /// <summary>
        /// 
        /// </summary>
        MissingRequiredField = 5,

        /// <summary>
        /// 
        /// </summary>
        InvalidFieldType = 6,

        /// <summary>
        /// 
        /// </summary>
        InvalidFormat = 7,

        /// <summary>
        /// 
        /// </summary>
        InvalidDate = 8,

        /// <summary>
        /// 
        /// </summary>
        AlcoholContentLimitExceeded = 9,

    }
}
