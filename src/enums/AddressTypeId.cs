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
    /// Indicates whether this address refers to a person or an business
    /// </summary>
    public enum AddressTypeId
    {
        /// <summary>
        /// A business location, for example a store, warehouse, or office.
        /// </summary>
        Location,

        /// <summary>
        /// A person's address who performs sales tasks for the company remotely from an office.
        /// </summary>
        Salesperson,

    }
}
