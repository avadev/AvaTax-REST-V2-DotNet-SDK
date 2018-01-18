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
    /// Describes the different types of statuses which describe an entity (company).
    /// </summary>
    public enum NexusTypeId
    {
        /// <summary>
        /// Indicates no nexus
        /// </summary>
        None,

        /// <summary>
        /// Indicates the entity is voluntarily collecting tax (default)
        ///  
        ///  This has replaced Collect
        /// </summary>
        SalesOrSellersUseTax,

        /// <summary>
        /// Indicates the entity is required to collect tax in the state
        ///  
        ///  This has replaced Legal
        /// </summary>
        SalesTax,

        /// <summary>
        /// Indicates the entity is registered as a Volunteer in an SST state.
        ///  Only your SST administrator may set this option.
        /// </summary>
        SSTVolunteer,

        /// <summary>
        /// Indicates the entity is registered as a Non-Volunteer in an SST state.
        ///  Only your SST administrator may set this option.
        /// </summary>
        SSTNonVolunteer,

    }
}
