using Basalt.BetterForms;
using Basalt.CommandParser;

namespace Blasphemous.Modding.Installer;

public class InstallerCommand : BasaltCommand
{
    [StringArgument('g', "github")]
    public string GithubToken { get; set; } = string.Empty;

    [BooleanArgument('i', "ignore")]
    public bool IgnoreTime { get; set; } = false;
}
