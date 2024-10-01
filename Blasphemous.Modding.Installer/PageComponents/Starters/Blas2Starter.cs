using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Validators;
using System.Diagnostics;

namespace Blasphemous.Modding.Installer.PageComponents.Starters;

internal class Blas2Starter : IGameStarter
{
    private readonly IValidator _validator;
    private readonly GameSettings _settings;

    public Blas2Starter(IValidator validator, GameSettings settings)
    {
        _validator = validator;
        _settings = settings;
    }

    public void Start()
    {
        string args = string.Empty;

        if (!_settings.Launch.RunModded)
            args += "--no-mods ";
        if (!_settings.Launch.RunConsole)
            args += "--melonloader.hideconsole ";

        StartProcess(args.Trim());
    }

    private void StartProcess(string args)
    {
        string gameDir = _settings.RootFolder;
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
