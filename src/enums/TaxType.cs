using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// Tax type
    /// </summary>
    public enum TaxType
    {
        /// <summary>
        /// Sales tax
        /// </summary>
        Sales,

        /// <summary>
        /// Use tax
        /// </summary>
        Use,

        /// <summary>
        /// Consumer Use Tax
        /// </summary>
        ConsumerUse,

        /// <summary>
        /// VAT/GST Output tax
        /// </summary>
        Output,

        /// <summary>
        /// VAT/GST Input tax
        /// </summary>
        Input,

        /// <summary>
        /// VAT/GST Nonrecoverable Input tax
        /// </summary>
        Nonrecoverable,

        /// <summary>
        /// Fee - PIFs (Public Improvement Fees) and RSFs (Retail Sales Fees)
        /// </summary>
        Fee,

        /// <summary>
        /// Rental Tax
        /// </summary>
        Rental,

        /// <summary>
        /// Medical Excise Tax
        /// </summary>
        Excise,

        /// <summary>
        /// Match Lodging tax type
        /// </summary>
        Lodging,

        /// <summary>
        /// Match bottle tax type
        /// </summary>
        Bottle,

        /// <summary>
        /// EWaste tax type
        /// </summary>
        EWaste,

        /// <summary>
        /// LandedCost tax type
        /// </summary>
        LandedCost,

    }
}
