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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a single notification.
    ///  
    /// A notification is a message from Avalara that may have relevance to your business. You may want
    /// to regularly review notifications and then dismiss them when you are certain that you have addressed
    /// any relevant concerns raised by this notification.
    ///  
    /// An example of a notification would be a message about new software, or a change to AvaTax that may
    /// affect you, or a potential issue with your company's tax profile.
    /// </summary>
    public class NotificationModel
    {
        /// <summary>
        /// The unique id of the notification.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the account that received this notification.
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// If this notification was tied to a specific company, this will be the
        /// unique ID number of the company that received the notification. Notifications that
        /// are tied to accounts will have a `NULL` value for `companyId`.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The type name of object referred to by this notification, if any.
        ///  
        /// Some notifications may include information about a related data object.
        ///  
        /// For example, if this notification was related to a nexus declaration, the `referenceObject` field would
        /// be `Nexus` and the `referenceId` field would be the unique ID number of that nexus.
        /// </summary>
        public String referenceObject { get; set; }

        /// <summary>
        /// The unique reference Id number of the object referred to by this notification, if any.
        ///  
        /// Some notifications may include information about a related data object.
        ///  
        /// For example, if this notification was related to a nexus declaration, the `referenceObject` field would
        /// be `Nexus` and the `referenceId` field would be the unique ID number of that nexus.
        /// </summary>
        public Int64? referenceId { get; set; }

        /// <summary>
        /// The severity level of the notification.
        /// </summary>
        public NotificationSeverityLevel severityLevelId { get; set; }

        /// <summary>
        /// The category of this notification.
        ///  
        /// Notification categories are a useful way to group related notifications together. Category names may change
        /// over time.
        ///  
        /// For Example: "Backdated Transactions" or "Nexus Jurisdiction Alerts", or "Certificate Expiration".
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// The topic of this notification.
        ///  
        /// Notification topics contain information about the notification. They are a summary of the issue and can
        /// help you decide what type of action to take.
        ///  
        /// For Example: "Backdated Transactions" or "Nexus Jurisdiction Alerts", or "Certificate Expiration".
        /// </summary>
        public String topic { get; set; }

        /// <summary>
        /// The message for this notification. This is a friendly description of the notification and any relevant
        /// information that can help you decide what kind of action, if any, to take in response.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// If this notification object requires user action to resolve, this value will be set to true.
        /// </summary>
        public Boolean? needsAction { get; set; }

        /// <summary>
        /// If there is a specific action suggested by this notification, this is the name of the action.
        ///  
        /// An action is a suggested next step such as "Review Your Tax Profile." If an action is suggested,
        /// you should give the viewer a hyperlink to the location referred to by `actionLink` and give the
        /// hyperlink the name `actionName`.
        /// </summary>
        public String actionName { get; set; }

        /// <summary>
        /// If there is a specific action suggested by this notification, this is the URL of the action.
        ///  
        /// An action is a suggested next step such as "Review Your Tax Profile." If an action is suggested,
        /// you should give the viewer a hyperlink to the location referred to by `actionLink` and give the
        /// hyperlink the name `actionName`.
        /// </summary>
        public String actionLink { get; set; }

        /// <summary>
        /// If there is a specific action suggested by this notification, and if this action is requested
        /// by a specific due date, this value will be the due date for the action.
        ///  
        /// An action is a suggested next step such as "Review Your Tax Profile." If an action is suggested,
        /// you should give the viewer a hyperlink to the location referred to by `actionLink` and give the
        /// hyperlink the name `actionName`.
        ///  
        /// For actions that have deadlines, such as "Confirm your tax registration before filing", this value
        /// will be set to the deadline date for the action. Otherwise, this value will be null.
        /// </summary>
        public DateTime? actionDueDate { get; set; }

        /// <summary>
        /// When a user has finished reviewing a notification, they may opt to dismiss it by calling the
        /// `DismissNotification` API. This API marks the notification as dismissed, and dismissed notifications
        /// will generally not appear in most user interfaces.
        /// </summary>
        public Boolean? dismissed { get; set; }

        /// <summary>
        /// If this notification has been dismissed, this indicates the unique ID number of the user that
        /// dismissed the notification.
        /// </summary>
        public Int32? dismissedByUserId { get; set; }

        /// <summary>
        /// If this notification has been dismissed, this indicates the timestamp (in UTC time) when the user
        /// dismissed the notification.
        /// </summary>
        public DateTime? dismissedDate { get; set; }

        /// <summary>
        /// If this notification is time sensitive, this is the latest date when the notification should be
        /// displayed to the user.
        /// </summary>
        public DateTime expireDate { get; set; }

        /// <summary>
        /// The unique ID number of the user who created the notification.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The UTC timestamp of the time when this notification was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The unique ID number of the user who most recently modified this notification.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// The UTC timestamp of the time when this notification was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }


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
