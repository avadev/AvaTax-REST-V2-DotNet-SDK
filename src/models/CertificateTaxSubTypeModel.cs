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
    /// Represents one TPS sub-tax-type node nested under a Avalara.AvaTax.AccountServices.Models.v2.CertificateTaxTypeModel.
    /// </summary>
    public class CertificateTaxSubTypeModel
    {
        /// <summary>
        /// TPS label for the sub-tax type.
        /// </summary>
        public String subTaxType { get; set; }

        /// <summary>
        /// TPS surrogate identifier for the sub-tax type.
        /// </summary>
        public Int32? subTaxTypeId { get; set; }

        /// <summary>
        /// TPS source mapping identifier for this (tax_type, sub_tax_type) pair. Round-trips into
        /// `CertificateJurisdictionTaxMappingModel.sourceMappingId` on POST/PUT certificates
        /// and is the diff key the CertCapture API uses to reconcile PUT updates.
        /// </summary>
        public Int32? sourceMappingId { get; set; }

        /// <summary>
        /// Jurisdictions in which the (tax_type, sub_tax_type) pair is registered.
        /// </summary>
        public List<CertificateTaxTypeJurisdictionModel> jurisdictions { get; set; }


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
