using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Information about questions that the local jurisdictions require for each location
    /// </summary>
    public class LocationQuestionModel
    {
        /// <summary>
        /// The unique ID number of this location setting type
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// This is the prompt for this question
        /// </summary>
        public String question { get; set; }

        /// <summary>
        /// If additional information is available about the location setting, this contains descriptive text to help
        /// you identify the correct value to provide in this setting.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// If available, this regular expression will verify that the input from the user is in the expected format.
        /// </summary>
        public String regularExpression { get; set; }

        /// <summary>
        /// If available, this is an example value that you can demonstrate to the user to show what is expected.
        /// </summary>
        public String exampleValue { get; set; }

        /// <summary>
        /// Indicates which jurisdiction requires this question
        /// </summary>
        public String jurisdictionName { get; set; }

        /// <summary>
        /// Indicates which type of jurisdiction requires this question
        /// </summary>
        public JurisdictionType? jurisdictionType { get; set; }

        /// <summary>
        /// Indicates the country that this jurisdiction belongs to
        /// </summary>
        public String jurisdictionCountry { get; set; }

        /// <summary>
        /// Indicates the state, region, or province that this jurisdiction belongs to
        /// </summary>
        public String jurisdictionRegion { get; set; }


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
