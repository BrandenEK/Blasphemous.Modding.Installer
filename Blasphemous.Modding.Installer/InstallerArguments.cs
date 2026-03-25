using Basalt.BetterForms;
using Basalt.CommandParser.Attributes;

namespace Blasphemous.Modding.Installer;

public class InstallerArguments : BasaltArguments
{
    [StringArgument("github", "g", "The github token to use for API requests")]
    public string GithubToken { get; set; } = string.Empty;

    [BooleanArgument("ignore-wait", "i", "Whether the wait time for API requests should be ignored")]
    public bool IgnoreTime { get; set; } = false;
}
