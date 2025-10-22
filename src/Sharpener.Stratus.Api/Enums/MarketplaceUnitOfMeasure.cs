// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     Measurement units used in business and inventory management.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MarketplaceUnitOfMeasure
{
    /// <summary>
    ///     Units by the bundle.
    /// </summary>
    [Description(nameof(Bundle))] Bundle,

    /// <summary>
    ///     Units by the bag.
    /// </summary>
    [Description(nameof(Bag))] Bag,

    /// <summary>
    ///     Units by the bank.
    /// </summary>
    [Description(nameof(Bank))] Bank,

    /// <summary>
    ///     Units by the barrel.
    /// </summary>
    [Description(nameof(Barrel))] Barrel,

    /// <summary>
    ///     Units by the bottle.
    /// </summary>
    [Description(nameof(Bottle))] Bottle,

    /// <summary>
    ///     Units by the box.
    /// </summary>
    [Description(nameof(Box))] Box,

    /// <summary>
    ///     Units by the can.
    /// </summary>
    [Description(nameof(Can))] Can,

    /// <summary>
    ///     Units by the case.
    /// </summary>
    [Description(nameof(Case))] Case,

    /// <summary>
    ///     Units in centimeters.
    /// </summary>
    [Description(nameof(Centimeter))] Centimeter,

    /// <summary>
    ///     Units by the coil.
    /// </summary>
    [Description(nameof(Coil))] Coil,

    /// <summary>
    ///     Units in cubic feet.
    /// </summary>
    [Description("Cubic Feet")] CubicFeet,

    /// <summary>
    ///     Units by the cylinder.
    /// </summary>
    [Description(nameof(Cylinder))] Cylinder,

    /// <summary>
    ///     Units by the dozen.
    /// </summary>
    [Description(nameof(Dozen))] Dozen,

    /// <summary>
    ///     Units by the drum.
    /// </summary>
    [Description(nameof(Drum))] Drum,

    /// <summary>
    ///     Each individual unit.
    /// </summary>
    [Description(nameof(Each))] Each,

    /// <summary>
    ///     Units in feet.
    /// </summary>
    [Description(nameof(Feet))] Feet,

    /// <summary>
    ///     Units in gallons.
    /// </summary>
    [Description(nameof(Gallon))] Gallon,

    /// <summary>
    ///     Units in inches.
    /// </summary>
    [Description(nameof(Inches))] Inches,

    /// <summary>
    ///     Units in kilograms.
    /// </summary>
    [Description(nameof(Kilograms))] Kilograms,

    /// <summary>
    ///     Units by the lot.
    /// </summary>
    [Description(nameof(Lot))] Lot,

    /// <summary>
    ///     Units in meters.
    /// </summary>
    [Description(nameof(Meter))] Meter,

    /// <summary>
    ///     Units in ounces.
    /// </summary>
    [Description(nameof(Ounce))] Ounce,

    /// <summary>
    ///     Units per hundred of a lower unit.
    /// </summary>
    [Description("Per Hundred")] PerHundred,

    /// <summary>
    ///     Units per thousand of a lower unit.
    /// </summary>
    [Description("Per Thousand")] PerThousand,

    /// <summary>
    ///     Units in pounds.
    /// </summary>
    [Description(nameof(Pounds))] Pounds,

    /// <summary>
    ///     Units by the piece.
    /// </summary>
    [Description(nameof(Piece))] Piece,

    /// <summary>
    ///     Units by the pack.
    /// </summary>
    [Description(nameof(Pack))] Pack,

    /// <summary>
    ///     Units by the pail.
    /// </summary>
    [Description(nameof(Pail))] Pail,

    /// <summary>
    ///     Units by the pair.
    /// </summary>
    [Description(nameof(Pair))] Pair,

    /// <summary>
    ///     Units by the pallet.
    /// </summary>
    [Description(nameof(Pallet))] Pallet,

    /// <summary>
    ///     Units in pints.
    /// </summary>
    [Description(nameof(Pint))] Pint,

    /// <summary>
    ///     Units in quarts.
    /// </summary>
    [Description(nameof(Quart))] Quart,

    /// <summary>
    ///     Units by the roll.
    /// </summary>
    [Description(nameof(Roll))] Roll,

    /// <summary>
    ///     Units by the set.
    /// </summary>
    [Description(nameof(Set))] Set,

    /// <summary>
    ///     Units by the stick.
    /// </summary>
    [Description(nameof(Stick))] Stick,

    /// <summary>
    ///     Units in square feet.
    /// </summary>
    [Description("Square Foot")] SquareFoot,

    /// <summary>
    ///     Units in square yards.
    /// </summary>
    [Description("Square Yard")] SquareYard,

    /// <summary>
    ///     Units by the tube.
    /// </summary>
    [Description(nameof(Tube))] Tube,

    /// <summary>
    ///     Units in yards.
    /// </summary>
    [Description(nameof(Yard))] Yard,

    /// <summary>
    ///     No unit of measure specified.
    /// </summary>
    [Description(nameof(None))] None
}
