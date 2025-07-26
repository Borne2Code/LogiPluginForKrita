# Logi Krita Plugin (For Logitech MX Creative and Loupedeck devices)
![](./docs/images/ReadmeImage.png)
This plugin allows a better control of Krita with Logitech MX Creative and Loupedeck devices, using a direct control of the application without throwing keyboard shortcuts.
It has been developed and tested with a Loupedeck CT, then adapted to the Logitech MX Creative device, it works on Windows and Mac OS.

*If you're a developer and if you want want to contribute, please let me know.*
*I'm also searching for beta-testers.*

Please see the [official plugin webpage](https://christophe-borne.github.io/LogiPluginForKrita/index.html) for more information.

# Requirements
To use this plugin you need:
- Krita with Python capabilities (tested on Krita 5.2.9)
- A compatible device:
  - Loupedeck device with recent driver (Tested on Loupedeck CT and driver version 5.9.x and 6.1.0+)
  - Logitech MX Creative with Logi Options+
- A compatible computer with:
  - Windows 10 or later
  - Mac OS 12 or later for MX Creative or Mac OS 10.15 or later for Loupedeck CT

# Installation
From the Loupedeck Marketplace (https://loupedeckmp.logi.com/asset/Krita), search for the Krita plugin, and install it.
From the Logi Options+ marketplace (https://www.logitech.com/software/marketplace/plugin-listing.html) search for the Krita plugin, and install it.
The installation process will configure an extension into Krita, the name of this extension is "*Logi API Server*", please don't remove it.
For the very first installation, you may have to activate the plugin extension in Krita:
- Start Krita
- Go to *Settings*/*Configure Krita...*
- Go to the *Python Plugin Manager* section
- Check the box on the line "*Logi API Server*"
- Press *OK* to validate, then restart Krita.

The plugin and the Krita extension communicate through a socket on port 1247, for the moment this cannot be changed.

# Known Issues
- In some rare cases, due to an issue with socket management in Python, Krita will freeze at start-up.
Unfortunately, we couldn't understand why, you may restart Krita until it starts correctly.
- When stopping the Loupedeck Driver, or uninstalling the Krita Plugin, any running instance of Krita can freeze, please be sure to save any open document and close Krita while doing a maintenance operation in the Loupedeck driver.
You won't be anoyed if you enter the Loupedeck driver or Logi Options+ to manage and modify profiles.

# Features
The full list of features is on the [official plugin webpage](https://christophe-borne.github.io/LogiPluginForKrita/index.html#features).
