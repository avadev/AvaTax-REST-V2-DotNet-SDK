using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// This object is used to keep track of custom information about a company.
    /// 
    /// The company settings system is a metadata system that you can use to store extra information
    /// about a company. Your integration or connector could use this data storage to keep track of
    /// preference information, reminders, or any other storage that would need to persist even if
    /// the customer uninstalls your application.
    /// 
    /// A setting can refer to any type of data you need to remember about this company object.
    /// When creating this object, you may define your own `set`, `name`, and `value` parameters.
    /// To define your own values, please choose a `set` name that begins with `X-` to indicate an extension.
    /// </summary>
    public class SettingModel
    {
        /// <summary>
        /// The unique ID number of this setting.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the company this setting refers to.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// A user-defined "set" containing this setting.
        /// 
        /// Avalara defines some sets that cannot be changed. To create your own set, choose a set
        /// name that begins with `X-` to indicate that this is an extension value.
        /// 
        /// We recommend that you choose a set name that clearly identifies your application, and then
        /// store data within name/value pairs within that set. For example, if you were creating an 
        /// application called MyApp, you might choose to create a set named `X-MyCompany-MyApp`.
        /// </summary>
        public String set { get; set; }

        /// <summary>
        /// A user-defined "name" for this name-value pair.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The value of this name-value pair.
        /// </summary>
        public String value { get; set; }


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
