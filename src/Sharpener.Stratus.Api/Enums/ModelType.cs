// The Sharpener project licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

/// <summary>
///     The types of models available on Stratus.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ModelType
{
    /// <summary>
    ///     The model type was not specified.
    /// </summary>
    [Description("Unspecified")] Unspecified,

    /// <summary>
    ///     The model is from Autodesk Revit.
    /// </summary>
    [Description("Revit")] Revit,

    /// <summary>
    ///     The model is from Autodesk AutoCAD.
    /// </summary>
    [Description("AutoCAD")] AutoCad,

    /// <summary>
    ///     The model is from Autodesk Fabrication CAMduct.
    /// </summary>
    [Description("CAMduct")] CamDuct,

    /// <summary>
    ///     The model is from Autodesk Fabrication ESTmep.
    /// </summary>
    [Description("ESTmep")] EstMep,

    /// <summary>
    ///     The model is from Autodesk Navisworks.
    /// </summary>
    [Description("Navisworks")] Navisworks,

    /// <summary>
    ///     The model is of the IFC file type.
    /// </summary>
    [Description("IFC")] Ifc,

    /// <summary>
    ///     The model is from Autodesk Inventor.
    /// </summary>
    [Description("Inventor")] Inventor,

    /// <summary>
    ///     The model is from SketchUp.
    /// </summary>
    [Description("SketchUp")] SketchUp,

    /// <summary>
    ///     The model is from Autodesk Revit Cloud.
    /// </summary>
    [Description("RevitCloud")] RevitCloud,

    /// <summary>
    ///     The model is from Autodesk AutoCAD Cloud.
    /// </summary>
    [Description("AutoCADCloud")] AutoCadCloud,

    /// <summary>
    ///     The model is from FieldOrderz.
    /// </summary>
    [Description("FieldOrderz")] FieldOrderz
}
