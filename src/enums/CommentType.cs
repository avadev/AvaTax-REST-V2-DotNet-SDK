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
    /// Comment Types
    /// </summary>
    public enum CommentType
    {
        /// <summary>
        /// Internal comments are those comments only intended to be for compliance users
        /// </summary>
        Internal = 1,

        /// <summary>
        /// Customer comments are those comments that both compliance and the customer can read
        /// </summary>
        Customer = 2,

        /// <summary>
        /// A comment that has a POA Attachment on it
        /// </summary>
        POAAttachment = 3,

        /// <summary>
        /// Used when creating Notice Comments in Returns Console
        /// </summary>
        NoticeVoucher = 4,

    }
}
