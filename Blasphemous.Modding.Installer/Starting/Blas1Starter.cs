using System.Diagnostics;

namespace Blasphemous.Modding.Installer.Starting;

public class Blas1Starter : IGameStarter
{
    public void StartModded()
    {
        throw new NotImplementedException();
    }

    public void StartVanilla()
    {
        throw new NotImplementedException();
    }

    private void StartProcess()
    {
        string gameDir = Core.SettingsHandler.Properties.CurrentRootPath;
        string gameExe = Path.Combine(gameDir, Core.CurrentPage.Validator.ExeName);
        Logger.Info("Starting game process for " + gameExe);

        try
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = gameExe,
                WorkingDirectory = gameDir,
                //UseShellExecute = true
            });
        }
        catch
        {
            MessageBox.Show($"Can not open game at {gameExe}", "Failed to start game");
        }
    }
}
