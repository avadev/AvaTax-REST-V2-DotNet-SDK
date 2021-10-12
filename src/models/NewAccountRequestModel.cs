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
    /// Represents a request for a new account with Avalara for a new subscriber.
    /// Contains information about the account requested and the rate plan selected.
    /// </summary>
    public class NewAccountRequestModel
    {
        /// <summary>
        /// The offer code provided to you by your Avalara business development contact.
        ///  
        /// This code controls what services and rates the customer will be provisioned with upon creation.
        ///  
        /// If you do not know your offer code, please contact your Avalara business development representative.
        /// </summary>
        public String offer { get; set; }

        /// <summary>
        /// The id associated with the connector
        /// </summary>
        public String connectorId { get; set; }

        /// <summary>
        /// If your Avalara business development representative requests, please provide the campaign ID associated with your
        /// signup process. This campaign identifier helps Avalara match users to the context in which they learned about the product
        /// to help improve the accuracy of our messaging.
        ///  
        /// The `campaign` field must be either null or a value provided to you by an Avalara business development representative.
        /// If you provide an unexpected value in this field, your API call will fail.
        /// </summary>
        public String campaign { get; set; }

        /// <summary>
        /// If your Avalara business development representative requests, please provide the lead source value associated with your
        /// signup process. This lead source identifier helps Avalara match users to the context in which they learned about the product
        /// to help improve the accuracy of our messaging.
        ///  
        /// The `leadSource` field must be either null or a value provided to you by an Avalara business development representative.
        /// If you provide an unexpected value in this field, your API call will fail.
        /// </summary>
        public String leadSource { get; set; }

        /// <summary>
        /// The date on which the account should take effect. If null, defaults to today.
        ///  
        /// You should leave this value `null` unless specifically requested by your Avalara business development manager.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date on which the account should expire.
        ///  
        /// You should leave this value `null` unless specifically requested by your Avalara business development manager.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The name of the account to create
        /// </summary>
        public String accountName { get; set; }

        /// <summary>
        /// Website of the new customer whose account is being created.
        ///  
        /// It is strongly recommended to provide the customer's website URL, as this will help our support representatives better
        /// assist customers.
        /// </summary>
        public String website { get; set; }

        /// <summary>
        /// Payment Method to be associated with the account.
        ///  
        /// This is strictly to be used internally unless your Avalara business development manager specifically asks you to provide this value
        /// while attempting to create an account.
        /// </summary>
        public String paymentMethodId { get; set; }

        /// <summary>
        /// First name of the primary contact person for this account
        /// </summary>
        public String firstName { get; set; }

        /// <summary>
        /// Last name of the primary contact person for this account
        /// </summary>
        public String lastName { get; set; }

        /// <summary>
        /// Title of the primary contact person for this account
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// Phone number of the primary contact person for this account
        /// </summary>
        public String phoneNumber { get; set; }

        /// <summary>
        /// Email of the primary contact person for this account
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// The username to be associated with the user created.
        /// If this is not provided, email address will be used as the username.
        /// </summary>
        public String username { get; set; }

        /// <summary>
        /// If instructed by your Avalara business development manager, set this value to a temporary password to permit the user to continue their onboarding process.
        ///  
        /// If this value is null, a temporary password is generated by the system and emailed to the user.
        ///  
        /// The user will then be asked to choose a permanent password when they first log on to the AvaTax website.
        /// </summary>
        public String userPassword { get; set; }

        /// <summary>
        /// This option controls what type of a welcome email is sent when the account is created.
        ///  
        /// * `Normal` - A standard welcome email will be sent.
        /// * `Suppressed` - No email will be sent.
        /// * `Custom` - If your Avalara business development representative provides you with a customized welcome email for your customers, please select this option.
        /// </summary>
        public String welcomeEmail { get; set; }

        /// <summary>
        /// Address information of the account being created.
        /// </summary>
        public CompanyAddress companyAddress { get; set; }

        /// <summary>
        /// Company code to be assigned to the company created for this account.
        ///  
        /// If no company code is provided, this will be defaulted to "DEFAULT" company code.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Properties of the primary contact person for this account
        /// </summary>
        public List<String> properties { get; set; }

        /// <summary>
        /// Set this to true if and only if the owner of the newly created account accepts Avalara's terms and conditions for your account.
        ///  
        /// Reading and accepting Avalara's terms and conditions is necessary in order for the account to receive a license key.
        /// </summary>
        public Boolean? acceptAvalaraTermsAndConditions { get; set; }

        /// <summary>
        /// Set this to true if and only if the owner of the newly created account has fully read Avalara's terms and conditions for your account.
        ///  
        /// Reading and accepting Avalara's terms and conditions is necessary in order for the account to receive a license key.
        /// </summary>
        public Boolean? haveReadAvalaraTermsAndConditions { get; set; }

        /// <summary>
        /// A dynamic key-value pair for the marketing context information
        /// </summary>
        public object marketingContext { get; set; }

        /// <summary>
        /// Type of the account to be created. Regular, Firm or FirmClient
        /// </summary>
        public AccountTypeId? accountType { get; set; }

        /// <summary>
        /// United States Taxpayer ID number, usually your Employer Identification Number if you are a business or your
        /// Social Security Number if you are an individual.
        /// This value is required if the address provided is inside the US and if you subscribed to the Avalara Managed Returns or SST Certified Service Provider service. Otherwise it is optional.
        /// </summary>
        public String taxPayerIdNumber { get; set; }


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
