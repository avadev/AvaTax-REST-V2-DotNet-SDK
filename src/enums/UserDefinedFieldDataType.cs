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
    /// 
    /// </summary>
    public enum UserDefinedFieldDataType
    {
        /// <summary>
        /// Represents String dataType
        /// </summary>
        String = 0,

        /// <summary>
        /// Represents Number dataType
        /// </summary>
        Number = 1,

        /// <summary>
        /// Represents Date dataType
        /// </summary>
        Date = 2,

        /// <summary>
        /// Represents Boolean dataType
        /// </summary>
        Boolean = 3,

    }
}
