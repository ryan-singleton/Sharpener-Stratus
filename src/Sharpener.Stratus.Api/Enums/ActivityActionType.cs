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
    [Description("")] Created,

    /// <summary>
    ///     Data was modified.
    /// </summary>
    [Description("")] Modified,

    /// <summary>
    ///     Data was deleted.
    /// </summary>
    [Description("")] Deleted,

    /// <summary>
    ///     Something was activated.
    /// </summary>
    [Description("")] Activated,

    /// <summary>
    ///     Data was archived.
    /// </summary>
    [Description("")] Archived,

    /// <summary>
    ///     A publish failed.
    /// </summary>
    [Description("")] PublishFailed,

    /// <summary>
    ///     Data was published.
    /// </summary>
    [Description("")] Published,

    /// <summary>
    ///     A tracking status changed.
    /// </summary>
    [Description("")] TrackingStatusChanged,

    /// <summary>
    ///     Something was shipped.
    /// </summary>
    [Description("")] Shipped,

    /// <summary>
    ///     Data was received.
    /// </summary>
    [Description("")] Received,

    /// <summary>
    ///     Something was marked as completed.
    /// </summary>
    [Description("")] Completed,

    /// <summary>
    ///     Something was assigned to a station.
    /// </summary>
    [Description("")] AssignedToStation,

    /// <summary>
    ///     A date was changed.
    /// </summary>
    [Description("")] DateChanged,

    /// <summary>
    ///     Data was locked.
    /// </summary>
    [Description("")] Locked,

    /// <summary>
    ///     Data was unlocked.
    /// </summary>
    [Description("")] Unlocked,

    /// <summary>
    ///     An action was reverted.
    /// </summary>
    [Description("")] Reverted,

    /// <summary>
    ///     A quote was processed.
    /// </summary>
    [Description("")] QuoteProcessed,

    /// <summary>
    ///     A purchase order was processed.
    /// </summary>
    [Description("")] PurchaseOrderProcessed,

    /// <summary>
    ///     Something was invoiced.
    /// </summary>
    [Description("")] Invoiced,

    /// <summary>
    ///     A set of item numbers were deleted.
    /// </summary>
    [Description("")] DeletedItemNumbers,

    /// <summary>
    ///     Field Orderz was published.
    /// </summary>
    [Description("")] FieldOrderzPublished,

    /// <summary>
    ///     Field Orderz publish attempt failed.
    /// </summary>
    [Description("")] FieldOrderzPublishFailed,

    /// <summary>
    ///     A lightning catalog was published.
    /// </summary>
    [Description("")] LightningCatalogPublished,

    /// <summary>
    ///     A lightning catalog publish attempt failed.
    /// </summary>
    [Description("")] LightningCatalogPublishFailed,

    /// <summary>
    ///     A report failed to generate.
    /// </summary>
    [Description("")] ReportFailed,

    /// <summary>
    ///     A set of dimensions was deleted.
    /// </summary>
    [Description("")] DeletedDimensions,

    /// <summary>
    ///     An area for BIM was deleted.
    /// </summary>
    [Description("")] BimAreaDeleted,

    /// <summary>
    ///     Areas for BIM were replaced.
    /// </summary>
    [Description("")] BimAreasReplaced,

    /// <summary>
    ///     An attachment was deleted.
    /// </summary>
    [Description("")] AttachmentDeleted,

    /// <summary>
    ///     Parts were deleted.
    /// </summary>
    [Description("")] PartsDeleted,

    /// <summary>
    ///     A project role was added.
    /// </summary>
    [Description("")] ProjectRoleAdded,

    /// <summary>
    ///     A default project role was removed.
    /// </summary>
    [Description("")] DefaultProjectRoleRemoved,

    /// <summary>
    ///     A default project role changed.
    /// </summary>
    [Description("")] DefaultProjectRoleChanged,

    /// <summary>
    ///     A project role was removed.
    /// </summary>
    [Description("")] ProjectRoleRemoved
}
