# Cycle Keybind Plugin for [OpenTabletDriver](https://github.com/OpenTabletDriver/OpenTabletDriver)

The Cycle Bind plugin for OpenTabletDriver offers users an enhanced key binding experience by allowing them to set multiple keys to be pressed in a sequential cycle.

### Installation:
1. Download the latest release from the release section.
2. Place the downloaded .dll file into your OpenTabletDriver Plugins folder.

### Usage:
After installing the plugin, you can set the keys you want to cycle through in the OpenTabletDriver settings. The keys should be input in the format "A+B+C+...", where each key is followed by a "+" sign and another key.

For example, if you wanted to cycle through the keys A, B, and C, you would input "A+B+C" into the settings.

### Code Explanation:
The `CycleBind` class is the main class of the plugin, implementing `IStateBinding` and `IBinding` from OpenTabletDriver.Plugin. 

The `Keys` property is used to set and get the keys to be cycled through, and the `Keyboard` property is used to interact with the virtual keyboard.

The `Press` and `Release` methods are used to press and release the keys when the tablet is pressed and released, respectively. The current key to be pressed/released is determined by the `currentKeyIndex`, which is incremented each time a key is pressed.

The `ParseKeys` method is used to parse the keys from the input string and checks if the key combination is supported.

### Troubleshooting:
If you encounter any issues while using this plugin, please check the debug log for any error messages. If the problem persists, please open an issue on this GitHub repository with a detailed description of the problem and any relevant error messages or screenshots.

### Contributing:
If you're interested in contributing to the development of this plugin, please feel free to open a pull request. All contributions are welcome and greatly appreciated.
