using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Validators;
using System.Diagnostics;

namespace Blasphemous.Modding.Installer.PageComponents.Starters;

internal class Blas2Starter : IGameStarter
{
    private readonly IValidator _validator;

    public Blas2Starter(IValidator validator)
    {
        _validator = validator;
    }

    public void Start()
    {
        LaunchOptions launch = Core.SettingsHandler.Properties.CurrentLaunchOptions;
        string args = string.Empty;

        if (!launch.RunModded)
            args += "--no-mods ";
        if (!launch.RunConsole)
            args += "--melonloader.hideconsole ";

        StartProcess(args.Trim());
    }

    private void StartProcess(string args)
    {
        string gameDir = Core.SettingsHandler.Properties.Blas2RootFolder;
        string gameExe = Path.Combine(gameDir, _validator.ExeName);
        Logger.Info("Starting process at " + gameExe);

        try
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = gameExe,
                WorkingDirectory = gameDir,
                Arguments = args
            });
        }
        catch
        {
            FailWithMessage($"Can not open game at {gameExe}");
        }
    }

    private void FailWithMessage(string message)
    {
        Logger.Error(message);
        MessageBox.Show(message, "Failed to start game");
    }
}
