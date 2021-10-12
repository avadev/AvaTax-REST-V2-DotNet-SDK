using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// Represents a list of statuses of returns available in skyscraper
    /// </summary>
    public class SkyscraperStatusModel
    {
        /// <summary>
        /// The specific name of the returns available in skyscraper
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The tax form codes available to file through skyscrper
        /// </summary>
        public List<String> taxFormCodes { get; set; }

        /// <summary>
        /// The country of the returns
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The Scraper type
        /// </summary>
        public ScraperType? scraperType { get; set; }

        /// <summary>
        /// Indicates if the return is currently available
        /// </summary>
        public Boolean? isAvailable { get; set; }

        /// <summary>
        /// The expected response time of the call
        /// </summary>
        public String expectedResponseTime { get; set; }

        /// <summary>
        /// Message on the returns
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// A list of required fields to file
        /// </summary>
        public List<requiredFilingCalendarDataFieldModel> requiredFilingCalendarDataFields { get; set; }


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
