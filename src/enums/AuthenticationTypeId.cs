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
    /// Represents the type of authentication provided to the API call
    /// </summary>
    public enum AuthenticationTypeId
    {
        /// <summary>
        /// This API call was not authenticated.
        /// </summary>
        None,

        /// <summary>
        /// This API call was authenticated by your username/password.
        /// </summary>
        UsernamePassword,

        /// <summary>
        /// This API call was authenticated by your Avalara Account ID and private license key.
        /// </summary>
        AccountIdLicenseKey,

        /// <summary>
        /// This API call was authenticated by OpenID Bearer Token.
        /// </summary>
        OpenIdBearerToken,

    }
}
