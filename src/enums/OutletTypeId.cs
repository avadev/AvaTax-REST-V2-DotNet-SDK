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
    /// Indicates the behavior of a tax form for a company with multiple places of business.
    ///  
    ///  Some tax authorities require that a separate form must be filed for each place of business.
    /// </summary>
    public enum OutletTypeId
    {
        /// <summary>
        /// File a single return per cycle for your entire business.
        /// </summary>
        None,

        /// <summary>
        /// You may file separate forms for each outlet; contact the tax authority for more details about location based reporting requirements.
        /// </summary>
        Schedule,

        /// <summary>
        /// You may file separate forms for each outlet; contact the tax authority for more details about location based reporting requirements.
        /// </summary>
        Duplicate,

        /// <summary>
        /// File a single return, but you must have a line item for each place of business.
        /// </summary>
        Consolidated,

    }
}
