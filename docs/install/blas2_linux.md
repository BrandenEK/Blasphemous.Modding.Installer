# Blasphemous 2 Manual Installation (Linux)

### Installing or updating the modding tools
1. Download the [MelonLoader installer](https://melonloader.co/download) (for Linux)
1. Run the installer, select Blasphemous 2, select the latest version (`0.7.1`)
1. Paste `WINEDLLOVERRIDES="version=n,b" %command%` in the launch options of the game on Steam (see Library > Blasphemous 2 > Properties > General)
1. Start the game to download and install the dependencies for MelonLoader (this is automatic, but be patient)
1. Close the game
1. Download the [Windows version](https://github.com/BrandenEK/BlasII.ModdingTools/raw/main/modding-tools-windows.zip) of the modding tools
1. Extract the contents of the zip file into the game's root directory
1. You should now have a folder called "Modding" in the same folder as "Blasphemous 2.exe"

### Installing or updating individual mods
1. On the mod's github page, navigate to the latest release
1. Download the file called "ModName.zip" and extract the contents of the zip file into the "Modding" folder
1. You should now have a file called "ModName.dll" in the "Modding/plugins" folder
1. Repeat this step for all of the mod's dependencies