using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// An exchange rate provider configuration: which ERS provider feed and refresh frequency a
    /// company uses when converting a given currency, optionally narrowed to a country.
    /// <br>`currencyCode` is derived from the resolved provider's base currency. The internal
    /// mapping id is not returned. System-default configurations are read-only over this API.
    /// </summary>
    public class ExchangeRateProviderConfigOutputModel
    {
        /// <summary>
        /// The unique ID of this exchange rate provider configuration row.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The ID of the company that owns this configuration. Inherited defaults are system-owned.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// ISO 4217 alpha-3 code of the currency this configuration applies to. Derived from the
        /// resolved provider's base currency; not supplied by the caller.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code this configuration applies to. Null appears only on
        /// system default rows.
        /// </summary>
        public String countryCode { get; set; }

        /// <summary>
        /// The provider feed this configuration selects (for example `SNB` or `ECB`).
        /// </summary>
        public String providerCode { get; set; }

        /// <summary>
        /// The refresh frequency this configuration selects (for example `Daily` or
        /// `Monthly`).
        /// </summary>
        public String frequency { get; set; }

        /// <summary>
        /// The date from which this configuration takes effect.
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// The date on which this configuration expires. A stored open-ended row uses
        /// 9999-12-31.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Whether this row's country and provider combination is available for customer
        /// configuration. System-default rows return the stored policy value; customer rows return a
        /// value computed from their country and provider. In the first release, this is true only
        /// for Switzerland with SNB. This value is null only when a system-default row has no stored
        /// policy value.
        /// </summary>
        public Boolean? isConfigurable { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The user ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
