using System;
using System.Collections.Generic;
#if PORTABLE
using System.Net.Http;
using System.Threading.Tasks;
#endif

/*
 * AvaTax Software Development Kit for C#
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author     Ted Spence <ted.spence@avalara.com>
 * @author     Zhenya Frolov <zhenya.frolov@avalara.com>
 * @author     Greg Hester <greg.hester@avalara.com>
 * @copyright  2004-2017 Avalara, Inc.
 * @license    https://www.apache.org/licenses/LICENSE-2.0
 * @version    18.1.2-161
 * @link       https://github.com/avadev/AvaTax-REST-V2-DotNet-SDK
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The AvaTax compatible client always returns a predictable response object, the "AvaTaxCallResult".
    /// The result object contains information about whether the call resulted in an error, and if so, what
    /// data was in its response.  The caller is expected to use the object and determine how to handle
    /// errors.
    /// 
    /// This class may be useful for programmers who prefer to use synchronous code or to not use exceptions.
    /// </summary>
    public partial class AvaTaxCompatibleClient
    {
        /// <summary>
        /// Keep this object hidden
        /// </summary>
        private AvaTaxClient _client = null;

        /// <summary>
        /// Generate a client that connects to one of the standard AvaTax servers
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <param name="environment"></param>
        public AvaTaxCompatibleClient(string appName, string appVersion, string machineName, AvaTaxEnvironment environment)
        {
            _client = new AvaTaxClient(appName, appVersion, machineName, environment);
        }

        /// <summary>
        /// Generate a client that connects to a custom server
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <param name="customEnvironment"></param>
        public AvaTaxCompatibleClient(string appName, string appVersion, string machineName, Uri customEnvironment)
        {
            _client = new AvaTaxClient(appName, appVersion, machineName, customEnvironment);
        }
    }
}
