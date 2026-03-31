# Blasphemous 2 Manual Installation (Linux)

### Installing or updating the modding tools
1. Download and install Blasphemous 2 from Steam.
1. Download the [Windows version](https://github.com/BrandenEK/BlasII.ModdingTools/raw/main/win64.zip) of the modding tools
1. Extract the contents of the zip file into the game's root directory
1. Install [protontricks](https://github.com/Matoking/protontricks) from flatpak (recommended way) or from your distribution's package manager
1. Run the command `protontricks 2114740 dotnetdesktop6` in a terminal (`2114740` being the Steam app ID of Blasphemous 2) to start the installation of the .NET Desktop Runtime
1. Click on the "Install" button on the first window that pops up ("Microsoft Windows Desktop Runtime - 6.0.* (x86)")
1. Click on the "Install" button on the second window that pops up ("Microsoft Windows Desktop Runtime - 6.0.* (x64)")
1. Paste `WINEDLLOVERRIDES="version=n,b" %command%` in the launch options of the game on Steam (see Library > Blasphemous 2 > Properties > General)
1. You should now have a folder called "Modding" in the same folder as `Blasphemous 2.exe` (the default location is in `~/.local/share/Steam/steamapps/common/Blasphemous 2`)

### Installing or updating individual mods
1. On the mod's github page, navigate to the latest release
1. Download the file called "ModName.zip" and extract the contents of the zip file into the "Modding" folder
1. You should now have a file called "ModName.dll" in the "Modding/plugins" folder
1. Repeat this step for all of the mod's dependencies
