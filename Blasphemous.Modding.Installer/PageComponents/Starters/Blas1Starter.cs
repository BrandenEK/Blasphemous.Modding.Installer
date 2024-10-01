using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Validators;
using System.Diagnostics;

namespace Blasphemous.Modding.Installer.PageComponents.Starters;

internal class Blas1Starter : IGameStarter
{
    private readonly IValidator _validator;
    private readonly GameSettings _settings;

    public Blas1Starter(IValidator validator, GameSettings settings)
    {
        _validator = validator;
        _settings = settings;
    }

    public void Start()
    {
        if (!SetConfigProperty("doorstop_config.ini", "General", "enabled", _settings.Launch.RunModded))
            return;
        if (!SetConfigProperty(Path.Combine("BepInEx", "config", "BepInEx.cfg"), "Logging.Console", "Enabled", _settings.Launch.RunConsole))
            return;

        StartProcess();
    }

    private bool SetConfigProperty(string fileName, string sectionName, string propertyName, bool value)
    {
        string path = Path.Combine(_settings.RootFolder, fileName);

        // Ensure file exists
        if (!File.Exists(path))
        {
            FailWithMessage($"Could not find config file at {path}");
            return false;
        }

        // Try to set the property
        try
        {
            string[] lines = File.ReadAllLines(path);

            bool foundSection = false;
            for (int i = 0; i < lines.Length; i++)
            {
                if (foundSection)
                {
                    if (lines[i].StartsWith('['))
                        break;

                    if (lines[i].StartsWith(propertyName))
                    {
                        lines[i] = $"{propertyName} = {value.ToString().ToLower()}";
                        File.WriteAllLines(path, lines);

                        Logger.Info($"Wrote {propertyName} property to {fileName}");
                        return true;
                    }
                }
                else
                {
                    if (lines[i] == $"[{sectionName}]")
                        foundSection = true;
                }
            }

            throw new Exception();
        }
        catch
        {
            FailWithMessage($"Failed to write {propertyName} property to {fileName}");
            return false;
        }
    }

    private void StartProcess()
    {
        string gameDir = _settings.RootFolder;
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
