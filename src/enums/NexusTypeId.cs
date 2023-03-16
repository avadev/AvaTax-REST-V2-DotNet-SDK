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
    /// Describes the different types of statuses which describe an entity (company).
    /// </summary>
    public enum NexusTypeId
    {
        /// <summary>
        /// Indicates no nexus
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates the entity is voluntarily collecting tax (default)
        /// </summary>
        SalesOrSellersUseTax = 1,

        /// <summary>
        /// Indicates the entity is required to collect tax in the state
        /// </summary>
        SalesTax = 2,

        /// <summary>
        /// Indicates the entity is registered as a Volunteer in an SST state.
        ///  Only your SST administrator may set this option.
        /// </summary>
        SSTVolunteer = 3,

        /// <summary>
        /// Indicates the entity is registered as a Non-Volunteer in an SST state.
        ///  Only your SST administrator may set this option.
        /// </summary>
        SSTNonVolunteer = 4,

    }
}
