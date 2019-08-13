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
    /// Tax type
    /// </summary>
    public enum TaxType
    {
        /// <summary>
        /// Match Lodging tax type
        /// </summary>
        Lodging = 6,

        /// <summary>
        /// Match bottle tax type
        /// </summary>
        Bottle = 7,

        /// <summary>
        /// EWaste tax type
        /// </summary>
        EWaste = 10,

        /// <summary>
        /// LandedCost tax type
        /// </summary>
        LandedCost = 12,

        /// <summary>
        /// Consumer Use Tax
        /// </summary>
        ConsumerUse = 67,

        /// <summary>
        /// Medical Excise Tax
        /// </summary>
        Excise = 69,

        /// <summary>
        /// Fee - PIFs (Public Improvement Fees) and RSFs (Retail Sales Fees)
        /// </summary>
        Fee = 70,

        /// <summary>
        /// VAT/GST Input tax
        /// </summary>
        Input = 73,

        /// <summary>
        /// VAT/GST Nonrecoverable Input tax
        /// </summary>
        Nonrecoverable = 78,

        /// <summary>
        /// VAT/GST Output tax
        /// </summary>
        Output = 79,

        /// <summary>
        /// Rental Tax
        /// </summary>
        Rental = 82,

        /// <summary>
        /// Sales tax
        /// </summary>
        Sales = 83,

        /// <summary>
        /// Use tax
        /// </summary>
        Use = 85,

        /// <summary>
        /// Alcohol tax type
        /// </summary>
        Alcohol = 1014,

        /// <summary>
        /// Batteries tax type
        /// </summary>
        Batteries = 1015,

        /// <summary>
        /// LightBulbs
        /// </summary>
        LightBulbs = 1016,

    }
}
