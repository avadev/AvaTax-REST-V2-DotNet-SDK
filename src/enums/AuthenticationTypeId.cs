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
    public enum AuthenticationTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        UsernamePassword = 1,

        /// <summary>
        /// 
        /// </summary>
        AccountIdLicenseKey = 2,

        /// <summary>
        /// 
        /// </summary>
        OpenIdBearerToken = 3,

    }
}
