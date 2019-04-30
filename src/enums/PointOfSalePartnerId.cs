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
    /// A unique code assoicated with the Partner you may be working with. If you are not 
	/// working with a Partner or your Partner has not provided you an ID, leave 
	/// null.
    /// </summary>
    public enum PointOfSalePartnerId
    {
        /// <summary>
        /// DMA ID Type
        /// </summary>
        DMA = 1,

        /// <summary>
        /// AX7 ID Type
        /// </summary>
        AX7 = 2,

    }
}
