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
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A list of possible AvaFile filing option types.
    /// </summary>
    public enum FilingOptionTypeId
    {
        /// <summary>
        /// Denotes the tax return is being filed on paper.
        /// </summary>
        Paper = 0,

        /// <summary>
        /// Denotes the form can be efiled optionally.
        /// </summary>
        OptionalEfile = 1,

        /// <summary>
        /// Denotes the form is being filed via efile.
        /// </summary>
        MandatoryEfile = 2,

    }
}
