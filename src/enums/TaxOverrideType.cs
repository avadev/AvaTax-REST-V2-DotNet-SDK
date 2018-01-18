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
    /// TaxOverride reasons
    /// </summary>
    public enum TaxOverrideType
    {
        /// <summary>
        /// No override
        /// </summary>
        None,

        /// <summary>
        /// Tax was overriden by the client
        /// </summary>
        TaxAmount,

        /// <summary>
        /// Entity exemption was ignored (e.g. item was consumed)
        /// </summary>
        Exemption,

        /// <summary>
        /// Only the tax date was overriden
        /// </summary>
        TaxDate,

        /// <summary>
        /// To support Consumer Use Tax
        /// </summary>
        AccruedTaxAmount,

        /// <summary>
        /// Derive the taxable amount from the tax amount
        /// </summary>
        DeriveTaxable,

    }
}
