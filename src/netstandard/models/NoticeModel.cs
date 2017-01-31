using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a letter received from a tax authority regarding tax filing.
        /// These letters often have the warning "Notice" printed at the top, which is why
        /// they are called "Notices".
    /// </summary>
    public class NoticeModel
    {
        /// <summary>
        /// The unique ID number of this notice.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the company to which this notice belongs.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// taxNoticeStatusId
        /// </summary>
        public Int32? statusId { get; set; }

        /// <summary>
        /// taxNoticeStatus
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// receivedDate
        /// </summary>
        public DateTime? receivedDate { get; set; }

        /// <summary>
        /// closedDate
        /// </summary>
        public DateTime? closedDate { get; set; }

        /// <summary>
        /// TaxNoticeCustomerTypeId
        /// </summary>
        public Int32 customerTypeId { get; set; }

        /// <summary>
        /// TaxNoticeCustomerTypeId
        /// </summary>
        public String customerType { get; set; }

        /// <summary>
        /// taxNoticeCountry
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// taxNoticeState
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// taxNoticeTaxAuthorityId
        /// </summary>
        public Int32? taxAuthorityId { get; set; }

        /// <summary>
        /// taxNoticeFilingFrequencyId
        /// </summary>
        public FilingFrequencyId? filingFrequency { get; set; }

        /// <summary>
        /// taxNoticeFilingTypeId
        /// </summary>
        public Int32? filingTypeId { get; set; }

        /// <summary>
        /// taxNoticeFilingTypeId
        /// </summary>
        public String filingType { get; set; }

        /// <summary>
        /// ticketReferenceNo
        /// </summary>
        public String ticketReferenceNo { get; set; }

        /// <summary>
        /// ticketReferenceUrl
        /// </summary>
        public String ticketReferenceUrl { get; set; }

        /// <summary>
        /// salesForceCaseNo
        /// </summary>
        public String salesForceCase { get; set; }

        /// <summary>
        /// SalesForceCaseUrl
        /// </summary>
        public String salesForceCaseUrl { get; set; }

        /// <summary>
        /// TaxPeriod
        /// </summary>
        public String taxPeriod { get; set; }

        /// <summary>
        /// taxNoticeReasonId
        /// </summary>
        public Int32? reasonId { get; set; }

        /// <summary>
        /// taxNoticeReason
        /// </summary>
        public String reason { get; set; }

        /// <summary>
        /// taxNoticeTypeId
        /// </summary>
        public Int32? typeId { get; set; }

        /// <summary>
        /// taxNoticeTypeId
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// taxNoticeCustomerFundingOptionId
        /// </summary>
        public Int32? customerFundingOptionId { get; set; }

        /// <summary>
        /// taxNoticeCustomerFundingOptionId
        /// </summary>
        public String customerFundingOption { get; set; }

        /// <summary>
        /// taxNoticePriorityId
        /// </summary>
        public Int32 priorityId { get; set; }

        /// <summary>
        /// taxNoticePriorityId
        /// </summary>
        public String priority { get; set; }

        /// <summary>
        /// CustomerComment
        /// </summary>
        public String customerComment { get; set; }

        /// <summary>
        /// hideFromCustomer
        /// </summary>
        public Boolean hideFromCustomer { get; set; }

        /// <summary>
        /// expectedResolutionDate
        /// </summary>
        public DateTime? expectedResolutionDate { get; set; }

        /// <summary>
        /// showResolutionDateToCustomer
        /// </summary>
        public Boolean showResolutionDateToCustomer { get; set; }

        /// <summary>
        /// The unique ID number of the user that closed the notice
        /// </summary>
        public Int32? closedByUserId { get; set; }

        /// <summary>
        /// createdByUser
        /// </summary>
        public String createdByUserName { get; set; }

        /// <summary>
        /// The unique ID number of the user that owns the notice
        /// </summary>
        public Int32? ownedByUserId { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// avaFileFormId
        /// </summary>
        public Int32? avaFileFormId { get; set; }

        /// <summary>
        /// revenueContactId
        /// </summary>
        public Int32? revenueContactId { get; set; }

        /// <summary>
        /// complianceContactId
        /// </summary>
        public Int32? complianceContactId { get; set; }

        /// <summary>
        /// taxNoticeMailCheckToId
        /// </summary>
        public Int32? taxNoticeMailCheckToId { get; set; }

        /// <summary>
        /// documentReference
        /// </summary>
        public String documentReference { get; set; }

        /// <summary>
        /// jurisdictionName
        /// </summary>
        public String jurisdictionName { get; set; }

        /// <summary>
        /// jurisdictionType
        /// </summary>
        public String jurisdictionType { get; set; }

        /// <summary>
        /// taxNoticeComments
        /// </summary>
        public List<NoticeCommentModel> comments { get; set; }

        /// <summary>
        /// taxNoticeFinanceDetails
        /// </summary>
        public List<NoticeFinanceModel> finances { get; set; }

        /// <summary>
        /// salesForceCaseNo
        /// </summary>
        public String downloadAttachmentsUrl { get; set; }

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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
