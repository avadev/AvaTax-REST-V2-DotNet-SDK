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
    /// Input model for creating or updating a company exchange rate provider configuration.
    /// <br>
    /// Name the feed with Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderConfigInputModel.providerCode and Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderConfigInputModel.frequency; both are resolved
    /// server-side against the catalogue from `ListExchangeRateProviderDefinitions`. The
    /// server derives `currencyCode` from that pair. Do not send
    /// `providerFrequencyMappingId`.
    /// <br>
    /// First release: only Switzerland (`CH`) with provider `SNB` may be written, and
    /// frequency is the only customer choice on that slot. System defaults are read-only.
    /// <br>
    /// On create, Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderConfigInputModel.effDate must be today or later (UTC). On update, restate the
    /// immutable fields and change only Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderConfigInputModel.endDate (today or later).
    /// </summary>
    public class ExchangeRateProviderConfigInputModel
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code this configuration applies to. Required on a customer
        /// write.
        /// </summary>
        public String countryCode { get; set; }

        /// <summary>
        /// The provider feed this configuration selects, as reported by the definition endpoint
        /// (for example `SNB` or `ECB`). Matched case-insensitively.
        /// </summary>
        public String providerCode { get; set; }

        /// <summary>
        /// The refresh frequency this configuration selects, as reported by the definition
        /// endpoint (for example `Daily` or `Monthly`). Matched case-insensitively.
        /// </summary>
        public String frequency { get; set; }

        /// <summary>
        /// The date from which this configuration takes effect. Required on create; must be today
        /// or a future date (UTC). Immutable after create.
        /// </summary>
        public DateTime effDate { get; set; }

        /// <summary>
        /// The date on which this configuration expires. Omitting it on create stores
        /// 9999-12-31. Required on update; must be today or a future date (UTC).
        /// </summary>
        public DateTime? endDate { get; set; }


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
