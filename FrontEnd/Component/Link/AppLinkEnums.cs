using System.ComponentModel.DataAnnotations;
using PokeDex.Lib.Enums;

namespace PokeDex.FrontEnd.Component.Link;

public enum LinkTarget
{
    [Display (Name = "_blank")]
    Blank,
    [Display(Name = "_self")]
    Self,
    [Display(Name = "_parent")]
    Parent,
    [Display(Name = "_top")]
    Top
}

public enum TextDecoration
{
    [Style (Name = "none")]
    None,
    [Style (Name = "underline")]
    Underline,
    [Style (Name = "overline")]
    Overline,
    [Style (Name = "line-through")]
    LineThrough,
    [Style (Name = "initial")]
    Initial,
    [Style (Name = "inherit")]
    Inherit
}