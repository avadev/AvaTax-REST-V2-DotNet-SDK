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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The data type that must be passed in a parameter bag
    /// </summary>
    public enum ParameterBagDataType
    {
        /// <summary>
        /// This data type is a string.
        /// </summary>
        String,

        /// <summary>
        /// This data type is either 'true' or 'false'.
        /// </summary>
        Boolean,

        /// <summary>
        /// This data type is a numeric value. It can include decimals.
        /// </summary>
        Numeric,

    }
}
