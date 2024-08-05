using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Validators;
using System.Diagnostics;

namespace Blasphemous.Modding.Installer.PageComponents.Starters;

internal class Blas1Starter : IGameStarter
{
    private readonly IValidator _validator;

    public Blas1Starter(IValidator validator)
    {
        _validator = validator;
    }

    public void StartModded()
    {
        if (SetConfigProperty(true))
            StartProcess();
    }

    public void StartVanilla()
    {
        if (SetConfigProperty(false))
            StartProcess();
    }

    private bool SetConfigProperty(bool enabled)
    {
        string gameDir = Core.SettingsHandler.Properties.Blas1RootFolder;
        string configPath = Path.Combine(gameDir, "doorstop_config.ini");

        // Ensure doorstop file exists
        if (!File.Exists(configPath))
        {
            FailWithMessage($"Could not find config file at {configPath}");
            return false;
        }

        try
        {
            string[] lines = File.ReadAllLines(configPath);
            lines[2] = $"enabled={enabled.ToString().ToLower()}";
            File.WriteAllLines(configPath, lines);
            return true;
        }
        catch
        {
            FailWithMessage("Failed to write enabled property to doorstop config");
            return false;
        }
    }

    private void StartProcess()
    {
        string gameDir = Core.SettingsHandler.Properties.Blas1RootFolder;
        string gameExe = Path.Combine(gameDir, _validator.ExeName);
        Logger.Info("Starting process at " + gameExe);

        try
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = gameExe,
                WorkingDirectory = gameDir
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
