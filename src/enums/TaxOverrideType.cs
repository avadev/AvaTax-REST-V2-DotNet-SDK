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
    /// Represents a type of tax override requested by the customer.
    ///  
    ///  AvaTax allows customers to override some behavior of the AvaTax engine. When you use a
    ///  Tax Override, you can import tax that was previously calculated and charged to the customer exactly
    ///  as it was charged. AvaTax will record the type of override used for each transaction.
    /// </summary>
    public enum TaxOverrideType
    {
        /// <summary>
        /// AvaTax calculated the tax for this transaction, and no override occurred.
        /// </summary>
        None = 0,

        /// <summary>
        /// AvaTax calculated tax for this transaction, but the final tax amount on the transaction was
        ///  determined outside of AvaTax. To see the tax amounts determined by AvaTax, look at the
        ///  `taxCalculated` field. To see the tax amounts determined by the customer's outside tax engine,
        ///  look at the `taxAmount` field.
        ///  
        ///  This behavior can also occur when a customer requests a refund. For refunds calculated using the
        ///  `RefundTransaction` API, AvaTax will ensure that the exact tax charged to the customer is refunded
        ///  to the customer using a tax amount override.
        /// </summary>
        TaxAmount = 1,

        /// <summary>
        /// Entity exemption was ignored (e.g. item was consumed)
        /// </summary>
        Exemption = 2,

        /// <summary>
        /// AvaTax was instructed to calculate this transaction using the tax rules that were in effect
        ///  on a different day than the transaction occurred.
        ///  
        ///  This behavior typically occurs during refunds. If the customer attempts to return a product
        ///  without a receipt that shows the exact tax amount paid, AvaTax can calculate tax on the date
        ///  when they believed that the product was purchased.
        /// </summary>
        TaxDate = 3,

        /// <summary>
        /// To support Consumer Use Tax
        /// </summary>
        AccruedTaxAmount = 4,

        /// <summary>
        /// Derive the taxable amount from the tax amount
        /// </summary>
        DeriveTaxable = 5,

        /// <summary>
        /// This is for the documents that are calculated outside of AvaTax and passed in to AvaTax
        ///  specifically for reporting/Returns purposes
        /// </summary>
        OutOfHarbor = 6,

    }
}
