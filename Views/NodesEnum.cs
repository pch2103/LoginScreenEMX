using Eremex.AvaloniaUI.Controls.Common;
using System.ComponentModel.DataAnnotations;

namespace LoginScreenEMX.Views;
public enum NodesEnum
{
    // The images assigned to the enumeration values below are placed 
    // in the ComboBoxTestSample/Images folder.
    // They have their "Build Action" properties set to "AvaloniaResource".
    [Image("avares://LoginScreenEMX/Assets/node.svg")]
    [Display(Name = "Node Name 1", Description = "Node Item to connect")]
    NodeItem1,

    [Image("avares://LoginScreenEMX/Assets/node.svg")]
    [Display(Name = "Node Name 2", Description = "Node Item to connect")]
    NodeItem2,

    [Image("avares://LoginScreenEMX/Assets/node.svg")]
    [Display(Name = "Node Name 3", Description = "Node Item to connect")]
    NodeItem3,

    [Image("avares://LoginScreenEMX/Assets/node.svg")]
    [Display(Name = "Node Name 4", Description = "Node Item to connect")]
    NodeItem4,

    [Image("avares://LoginScreenEMX/Assets/node.svg")]
    [Display(Name = "Node Name 4", Description = "Node Item to connect")]
    NodeItem5,
    
    [Image("avares://LoginScreenEMX/Assets/node.svg")]
    [Display(Name = "Node Name 6", Description = "Node Item to connect")]
    NodeItem6
}