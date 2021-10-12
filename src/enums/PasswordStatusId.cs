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
    /// 
    /// </summary>
    public enum PasswordStatusId
    {
        /// <summary>
        /// 
        /// </summary>
        UserCannotChange = 0,

        /// <summary>
        /// 
        /// </summary>
        UserCanChange = 1,

        /// <summary>
        /// 
        /// </summary>
        UserMustChange = 2,

    }
}
