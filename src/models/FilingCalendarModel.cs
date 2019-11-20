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
    /// Represents a commitment to file a tax return on a recurring basis.
    /// Only used if you subscribe to Avalara Returns.
    /// </summary>
    public class FilingCalendarModel
    {
        /// <summary>
        /// The unique ID number of this filing calendar.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the company to which this filing calendar belongs.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 9/13/2018, Version: 18.10, Message: Please use `taxFormCode` instead.
        /// The legacy return name of the tax form to file.
        /// </summary>
        public String returnName { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country that issued the tax form for this filing calendar.
        ///  
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        ///  
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.
        /// </summary>
        public String formCountry { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region that issued the tax form for this filing calendar.
        ///  
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        ///  
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.
        /// </summary>
        public String formRegion { get; set; }

        /// <summary>
        /// The Avalara standard tax form code of the tax form for this filing calendar. The first two characters of the tax form code
        /// are the ISO 3166 country code of the country that issued this form.
        /// </summary>
        public String taxFormCode { get; set; }

        /// <summary>
        /// The start period of a fiscal year for this form/company
        /// </summary>
        public Int32? fiscalYearStartMonth { get; set; }

        /// <summary>
        /// If this calendar is for a location-specific tax return, specify the location code here. To file for all locations, leave this value NULL.
        /// </summary>
        public String locationCode { get; set; }

        /// <summary>
        /// If this calendar is for a location-specific tax return, specify the location-specific behavior here.
        /// </summary>
        public OutletTypeId? outletTypeId { get; set; }

        /// <summary>
        /// Specify the ISO 4217 currency code for the currency to remit for this tax return. For all tax returns in the United States, specify "USD".
        /// </summary>
        public String paymentCurrency { get; set; }

        /// <summary>
        /// The frequency on which this tax form is filed.
        /// </summary>
        public FilingFrequencyId filingFrequencyId { get; set; }

        /// <summary>
        /// A 16-bit bitmap containing a 1 for each month when the return should be filed.
        /// </summary>
        public Int16? months { get; set; }

        /// <summary>
        /// Tax Registration ID for this Region - in the U.S., this is for your state.
        /// </summary>
        public String stateRegistrationId { get; set; }

        /// <summary>
        /// Tax Registration ID for the local jurisdiction, if any.
        /// </summary>
        public String localRegistrationId { get; set; }

        /// <summary>
        /// The Employer Identification Number or Taxpayer Identification Number that is to be used when filing this return.
        /// </summary>
        public String employerIdentificationNumber { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 9/1/2017, Version: 17.9, Message: Field will be no longer be available after the 17.9 release.
        /// The first line of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 9/1/2017, Version: 17.9, Message: Field will be no longer be available after the 17.9 release.
        /// The second line of the mailing address that will be used when filling out this tax return.
        /// Please note that some tax forms do not support multiple address lines.
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 9/1/2017, Version: 17.9, Message: Field will be no longer be available after the 17.9 release.
        /// The city name of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 9/1/2017, Version: 17.9, Message: Field will be no longer be available after the 17.9 release.
        /// The state, region, or province of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 9/1/2017, Version: 17.9, Message: Field will be no longer be available after the 17.9 release.
        /// The postal code or zip code of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 9/1/2017, Version: 17.9, Message: Field will be no longer be available after the 17.9 release.
        /// The two character ISO-3166 country code of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The first line of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String mailingAddressLine1 { get; set; }

        /// <summary>
        /// The second line of the mailing address that will be used when filling out this tax return.
        /// Please note that some tax forms do not support multiple address lines.
        /// </summary>
        public String mailingAddressLine2 { get; set; }

        /// <summary>
        /// The city name of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String mailingAddressCity { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region of the mailing address that will be used when filling out this tax return.
        ///  
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        ///  
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.
        /// </summary>
        public String mailingAddressRegion { get; set; }

        /// <summary>
        /// The postal code or zip code of the mailing address that will be used when filling out this tax return.
        /// </summary>
        public String mailingAddressPostalCode { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country of the mailing address that will be used when filling out this tax return.
        ///  
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        ///  
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.
        /// </summary>
        public String mailingAddressCountry { get; set; }

        /// <summary>
        /// The phone number to be used when filing this return.
        /// </summary>
        public String phone { get; set; }

        /// <summary>
        /// Special filing instructions to be used when filing this return.
        /// Please note that requesting special filing instructions may incur additional costs.
        /// </summary>
        public String customerFilingInstructions { get; set; }

        /// <summary>
        /// The legal entity name to be used when filing this return.
        /// </summary>
        public String legalEntityName { get; set; }

        /// <summary>
        /// The earliest date for the tax period when this return should be filed.
        /// This date specifies the earliest date for tax transactions that should be reported on this filing calendar.
        /// Please note that tax is usually filed one month in arrears: for example, tax for January transactions is typically filed during the month of February.
        /// </summary>
        public DateTime effectiveDate { get; set; }

        /// <summary>
        /// The last date for the tax period when this return should be filed.
        /// This date specifies the last date for tax transactions that should be reported on this filing calendar.
        /// Please note that tax is usually filed one month in arrears: for example, tax for January transactions is typically filed during the month of February.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The method to be used when filing this return.
        /// </summary>
        public FilingTypeId? filingTypeId { get; set; }

        /// <summary>
        /// If you file electronically, this is the username you use to log in to the tax authority's website.
        /// </summary>
        public String eFileUsername { get; set; }

        /// <summary>
        /// If you file electronically, this is the password or pass code you use to log in to the tax authority's website.
        /// </summary>
        public String eFilePassword { get; set; }

        /// <summary>
        /// If you are required to prepay a percentage of taxes for future periods, please specify the percentage in whole numbers;
        /// for example, the value 90 would indicate 90%.
        /// </summary>
        public Int32? prepayPercentage { get; set; }

        /// <summary>
        /// Determines if a prepayment is required for this filing calendar
        /// </summary>
        public Boolean? prePaymentRequired { get; set; }

        /// <summary>
        /// If your company is required to make a prepayment that is designated by a fixed amount each period, please specify the amount here.
        /// </summary>
        public Decimal? fixedPrepaymentAmount { get; set; }

        /// <summary>
        /// The type of tax to report on this return.
        /// </summary>
        public MatchingTaxType taxTypeId { get; set; }

        /// <summary>
        /// Internal filing notes.
        /// </summary>
        public String internalNotes { get; set; }

        /// <summary>
        /// Custom filing information field for Alabama.
        /// </summary>
        public String alSignOn { get; set; }

        /// <summary>
        /// Custom filing information field for Alabama.
        /// </summary>
        public String alAccessCode { get; set; }

        /// <summary>
        /// Custom filing information field for Maine.
        /// </summary>
        public String meBusinessCode { get; set; }

        /// <summary>
        /// Custom filing information field for Iowa.
        /// </summary>
        public String iaBen { get; set; }

        /// <summary>
        /// Custom filing information field for Connecticut.
        /// </summary>
        public String ctReg { get; set; }

        /// <summary>
        /// Custom filing information field. Leave blank.
        /// </summary>
        public String other1Name { get; set; }

        /// <summary>
        /// Custom filing information field. Leave blank.
        /// </summary>
        public String other1Value { get; set; }

        /// <summary>
        /// Custom filing information field. Leave blank.
        /// </summary>
        public String other2Name { get; set; }

        /// <summary>
        /// Custom filing information field. Leave blank.
        /// </summary>
        public String other2Value { get; set; }

        /// <summary>
        /// Custom filing information field. Leave blank.
        /// </summary>
        public String other3Name { get; set; }

        /// <summary>
        /// Custom filing information field. Leave blank.
        /// </summary>
        public String other3Value { get; set; }

        /// <summary>
        /// The unique ID of the tax authority of this return.
        /// </summary>
        public Int32? taxAuthorityId { get; set; }

        /// <summary>
        /// The name of the tax authority of this return.
        /// </summary>
        public String taxAuthorityName { get; set; }

        /// <summary>
        /// The type description of the tax authority of this return.
        /// </summary>
        public String taxAuthorityType { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// CompanyReturn settings for complext filing calendar
        /// </summary>
        public List<CompanyReturnSettingModel> settings { get; set; }


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
