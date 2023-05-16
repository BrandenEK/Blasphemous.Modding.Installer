# Blasphemous Mod Installer
A mod installer for the game Blasphemous that allows mods to be installed, updated, and enabled/disabled with only one click.

<br>

## How to use

1. Download the most recent version of the installer from the [Releases](https://github.com/BrandenEK/Blasphemous-Mod-Installer/releases) page
2. Run the 'BlasModInstaller.exe' program
3. When asked, navigate to your 'Blashemous.exe' file, which is most likely in 'C:\Program Files (x86)\Steam\steamapps\common\Blasphemous'
    - This can be changed later on in the 'installer.cfg' file
4. Once connected to the internet, it will find the most recent version of all Blasphemous mods and display them

<br>

## Github Rate limit

Since these mods are hosted on Github, checking version status and downloading them uses the Github API, which is subject to rate limits.
Normal users of the mod installer only have 60 requests per hour, so if you are unable to download mods or they stop showing that an update is available, this could be why.
If you want to increase this limit and you have a github account, you can set the GithubToken property in the 'installer.cfg' file to your Github OAuth token.

<br>

## Adding your own mod to the installer

If you have created your own Blasphemous mod and want it to be available in the mod installer, simply edit the 'mods.json' file in this repository with your mod's info, and submit a pull request.
