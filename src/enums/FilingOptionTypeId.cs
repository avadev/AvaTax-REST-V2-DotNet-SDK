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
    /// A list of possible AvaFile filing option types.
    /// </summary>
    public enum FilingOptionTypeId
    {
        /// <summary>
        /// Denotes the tax return is being filed on paper.
        /// </summary>
        Paper,

        /// <summary>
        /// Denotes the form can be efiled optionally.
        /// </summary>
        OptionalEfile,

        /// <summary>
        /// Denotes the form is being filed via efile.
        /// </summary>
        MandatoryEfile,

    }
}
