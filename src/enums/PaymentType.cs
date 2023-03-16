using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient 
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
        CurrentPeriod = 0,

        /// <summary>
        /// The payment is a prepayment
        /// </summary>
        Prepayment = 1,

        /// <summary>
        /// The payment is a prior payment
        /// </summary>
        PriorPayment = 2,

        /// <summary>
        /// The payment is a prior CSP fee
        /// </summary>
        PriorCspFee = 3,

    }
}
