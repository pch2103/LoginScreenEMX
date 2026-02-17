using Eremex.AvaloniaUI.Controls.Common;
using System.ComponentModel.DataAnnotations;

namespace LoginScreenEMX.Views;

public enum HostsEnum
{
    // The images assigned to the enumeration values below are placed 
    // in the ComboBoxTestSample/Images folder.
    // They have their "Build Action" properties set to "AvaloniaResource".
    [Image("avares://LoginScreenEMX/Assets/host.svg")]
    [Display(Name = "Dell-Host", Description = "Host Item to connect")]
    HostItem1,

    [Image("avares://LoginScreenEMX/Assets/host.svg")]
    [Display(Name = "Host Item 2", Description = "Host Item to connect")]
    HostItem2,

    [Image("avares://LoginScreenEMX/Assets/host.svg")]
    [Display(Name = "Host Item 3", Description = "Host Item to connect")]
    HostItem3,

    [Image("avares://LoginScreenEMX/Assets/host.svg")]
    [Display(Name = "Host Item 4", Description = "HostItem3")]
    HostItem4
}