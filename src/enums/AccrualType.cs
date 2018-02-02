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
    /// Accrual types
    /// </summary>
    public enum AccrualType
    {
        /// <summary>
        /// Filing indicates that this tax return should be filed with its tax authority by its due date. For example, if you file annually, you will have eleven months of Accrual returns and one Filing return.
        /// </summary>
        Filing,

        /// <summary>
        /// An Accrual filing indicates taxes that are accrued, intended to be filed on a future tax return. For example, if you file annually, you will have eleven months of Accrual returns and one Filing return.
        /// </summary>
        Accrual,

    }
}
