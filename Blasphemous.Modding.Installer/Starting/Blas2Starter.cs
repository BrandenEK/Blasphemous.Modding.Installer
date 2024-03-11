using Blasphemous.Modding.Installer.Validation;
using System.Diagnostics;

namespace Blasphemous.Modding.Installer.Starting;

internal class Blas2Starter : IGameStarter
{
    private readonly IValidator _validator;

    public Blas2Starter(IValidator validator)
    {
        _validator = validator;
    }

    public void StartModded()
    {
        StartProcess(string.Empty);
    }

    public void StartVanilla()
    {
        StartProcess("--no-mods");
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
