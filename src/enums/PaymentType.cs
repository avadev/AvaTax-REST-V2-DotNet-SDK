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
    /// 
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// 
        /// </summary>
        CurrentPeriod = 0,

        /// <summary>
        /// 
        /// </summary>
        Prepayment = 1,

        /// <summary>
        /// 
        /// </summary>
        PriorPayment = 2,

        /// <summary>
        /// 
        /// </summary>
        PriorCspFee = 3,

    }
}
