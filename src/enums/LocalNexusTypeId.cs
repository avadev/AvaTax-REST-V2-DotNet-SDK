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
    /// Describes nexus type id
    /// </summary>
    public enum LocalNexusTypeId
    {
        /// <summary>
        /// Only the specific nexus objects declared for this company are declared.
        /// </summary>
        Selected = 0,

        /// <summary>
        /// Customer declares nexus in all state administered taxing authorities.
        ///  
        ///  This value only takes effect if you set `hasLocalNexus` = true.
        /// </summary>
        StateAdministered = 1,

        /// <summary>
        /// Customer declares nexus in all local taxing authorities.
        ///  
        ///  This value only takes effect if you set `hasLocalNexus` = true.
        /// </summary>
        All = 2,

    }
}
