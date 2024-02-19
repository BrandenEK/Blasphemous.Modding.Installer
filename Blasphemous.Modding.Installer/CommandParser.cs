
namespace Blasphemous.Modding.Installer;

public class CommandParser
{
    public string GithubToken { get; } = string.Empty;
    public bool IgnoreTime { get; } = false;

    public CommandParser(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];

            // [i]gnore flag
            if (arg == "-i" || arg == "-ignore")
            {
                IgnoreTime = true;
                continue;
            }

            // [g]ithub setting
            if (arg == "-g" || arg == "-github")
            {
                if (i == args.Length)
                    throw new Exception("The [g]ithub parameter needs a value after it");

                GithubToken = args[++i];
                continue;
            }

            throw new Exception($"Invalid argument {arg}");
        }
    }
}
