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
    /// One (provider, frequency) pair that AvaTax offers for exchange rate provider configuration.
    /// <br>
    /// Read this catalogue before writing an `ExchangeRateProviderConfig`: the write contract
    /// carries Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderDefinitionOutputModel.providerCode and Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderDefinitionOutputModel.frequency, and both must name a pair
    /// listed here. The pair also determines the configuration's currency, which is why
    /// Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderDefinitionOutputModel.baseCurrency is returned but never supplied.
    /// <br>
    /// A provider offered at more than one frequency appears as multiple entries sharing the same
    /// Avalara.AvaTax.AccountServices.Models.v2.ExchangeRateProviderDefinitionOutputModel.providerCode (for example SNB Daily and SNB Monthly).
    /// </summary>
    public class ExchangeRateProviderDefinitionOutputModel
    {
        /// <summary>
        /// The provider's code, for example `SNB` or `ECB`. Supply this as
        /// `providerCode` when creating a configuration.
        /// </summary>
        public String providerCode { get; set; }

        /// <summary>
        /// The provider's display name, for example `Swiss National Bank`.
        /// </summary>
        public String providerName { get; set; }

        /// <summary>
        /// The refresh frequency this provider is offered at, for example `Daily` or
        /// `Monthly`. Supply this as `frequency` when creating a configuration.
        /// </summary>
        public String frequency { get; set; }

        /// <summary>
        /// The currency this provider publishes rates against. A configuration's
        /// `currencyCode` is derived from this, which is why the write contract does not
        /// accept a currency.
        /// </summary>
        public String baseCurrency { get; set; }


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
