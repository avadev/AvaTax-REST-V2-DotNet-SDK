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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Comment Types
    /// </summary>
    public enum CommentType
    {
        /// <summary>
        /// Internal comments are those comments only intended to be for compliance users
        /// </summary>
        Internal,

        /// <summary>
        /// Customer comments are those comments that both compliance and the customer can read
        /// </summary>
        Customer,

    }
}
