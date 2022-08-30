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
    /// Visibility for a parameter.
    /// </summary>
    public enum Visibility
    {
        /// <summary>
        /// Denotes the Parameter is required
        /// </summary>
        Required = 0,

        /// <summary>
        /// Denotes the Parameter is recommended
        /// </summary>
        Recommended = 1,

        /// <summary>
        /// Denotes the Parameter is optional
        /// </summary>
        Optional = 2,

        /// <summary>
        /// Denotes the Parameter is conditional
        /// </summary>
        Conditional = 3,

    }
}
