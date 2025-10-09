// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The enumeration of possible actions taken during an activity.
/// </summary>
public enum ActivityActionType
{
    /// <summary>
    ///     The action type is not specified.
    /// </summary>
    [Description("Unspecified")] Unspecified,

    /// <summary>
    ///     Data was created.
    /// </summary>
    [Description("Created")] Created,

    /// <summary>
    ///     Data was modified.
    /// </summary>
    [Description("Modified")] Modified,

    /// <summary>
    ///     Data was deleted.
    /// </summary>
    [Description("Deleted")] Deleted,

    /// <summary>
    ///     Something was activated.
    /// </summary>
    [Description("Activated")] Activated,

    /// <summary>
    ///     Data was archived.
    /// </summary>
    [Description("Archived")] Archived,

    /// <summary>
    ///     A publish operation failed.
    /// </summary>
    [Description("Publish Failed")] PublishFailed,

    /// <summary>
    ///     Data was published.
    /// </summary>
    [Description("Published")] Published,

    /// <summary>
    ///     A tracking status changed.
    /// </summary>
    [Description("Tracking Status Changed")]
    TrackingStatusChanged,

    /// <summary>
    ///     Something was shipped.
    /// </summary>
    [Description("Shipped")] Shipped,

    /// <summary>
    ///     Data was received.
    /// </summary>
    [Description("Received")] Received,

    /// <summary>
    ///     Something was marked as completed.
    /// </summary>
    [Description("Completed")] Completed,

    /// <summary>
    ///     Something was assigned to a station.
    /// </summary>
    [Description("Assigned To Station")] AssignedToStation,

    /// <summary>
    ///     A date was changed.
    /// </summary>
    [Description("Date Changed")] DateChanged,

    /// <summary>
    ///     Data was locked.
    /// </summary>
    [Description("Locked")] Locked,

    /// <summary>
    ///     Data was unlocked.
    /// </summary>
    [Description("Unlocked")] Unlocked,

    /// <summary>
    ///     An action was reverted.
    /// </summary>
    [Description("Reverted")] Reverted,

    /// <summary>
    ///     A quote was processed.
    /// </summary>
    [Description("Quote Processed")] QuoteProcessed,

    /// <summary>
    ///     A purchase order was processed.
    /// </summary>
    [Description("Purchase Order Processed")]
    PurchaseOrderProcessed,

    /// <summary>
    ///     Something was invoiced.
    /// </summary>
    [Description("Invoiced")] Invoiced,

    /// <summary>
    ///     A set of item numbers were deleted.
    /// </summary>
    [Description("Deleted Item Numbers")] DeletedItemNumbers,

    /// <summary>
    ///     Field Orderz was published.
    /// </summary>
    [Description("Field Orderz Published")]
    FieldOrderzPublished,

    /// <summary>
    ///     Field Orderz publish attempt failed.
    /// </summary>
    [Description("Field Orderz Publish Failed")]
    FieldOrderzPublishFailed,

    /// <summary>
    ///     A lightning catalog was published.
    /// </summary>
    [Description("Lightning Catalog Published")]
    LightningCatalogPublished,

    /// <summary>
    ///     A lightning catalog publish attempt failed.
    /// </summary>
    [Description("Lightning Catalog Publish Failed")]
    LightningCatalogPublishFailed,

    /// <summary>
    ///     A report failed to generate.
    /// </summary>
    [Description("Report Failed")] ReportFailed,

    /// <summary>
    ///     A set of dimensions was deleted.
    /// </summary>
    [Description("Deleted Dimensions")] DeletedDimensions,

    /// <summary>
    ///     An area for BIM was deleted.
    /// </summary>
    [Description("BIM Area Deleted")] BimAreaDeleted,

    /// <summary>
    ///     Areas for BIM were replaced.
    /// </summary>
    [Description("BIM Areas Replaced")] BimAreasReplaced,

    /// <summary>
    ///     An attachment was deleted.
    /// </summary>
    [Description("Attachment Deleted")] AttachmentDeleted,

    /// <summary>
    ///     Parts were deleted.
    /// </summary>
    [Description("Parts Deleted")] PartsDeleted,

    /// <summary>
    ///     A project role was added.
    /// </summary>
    [Description("Project Role Added")] ProjectRoleAdded,

    /// <summary>
    ///     A default project role was removed.
    /// </summary>
    [Description("Default Project Role Removed")]
    DefaultProjectRoleRemoved,

    /// <summary>
    ///     A default project role changed.
    /// </summary>
    [Description("Default Project Role Changed")]
    DefaultProjectRoleChanged,

    /// <summary>
    ///     A project role was removed.
    /// </summary>
    [Description("Project Role Removed")] ProjectRoleRemoved
}
