using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Indicates the type of payments
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// The payment is for the current payment
        /// </summary>
        CurrentPeriod,

        /// <summary>
        /// The payment is a prepayment
        /// </summary>
        Prepayment,

        /// <summary>
        /// The payment is a prior payment
        /// </summary>
        PriorPayment,

        /// <summary>
        /// The payment is a prior CSP fee
        /// </summary>
        PriorCspFee,

    }
}
