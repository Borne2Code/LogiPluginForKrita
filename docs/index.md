Logi Plugin for Krita (Works with Logitech MX Creative and Loupedeck devices)
=============================================================================
![](./images/ReadmeImage.png)
# Table of content
* [Summary](#summary)
* [Hot News](#hot-news)
* [Requirements](#requirements)
* [Installation](#installation)
* [Features](#features)
* [Feedbacks and issues](#feedbacks-and-issues)
* [Default Profile configuration](#default-profile-configuration)

# Summary
This plugin allows a better control of Krita with Logitech MX Creative and Loupedeck devices, using a direct control of the application without throwing keyboard shortcuts.
It has been developed and tested with a Loupedeck CT, then adapted to the Logitech MX Creative device, it works on Windows and Mac OS.

*If you're a developer and if you want want to contribute, please let me know.*
*I'm also searching for beta-testers*

# Hot news
This version supports Krita 5.3.x and newest vesions, please note that it can produce unexpected behavior with older versions, espacially using the zoom rotary button.
It also fixes some security breaks in the communication between the plugin and Krita (many thanks to the Logitech team for their feedbacks).

# Requirements
To use this plugin you need:
- Latest Krita with Python capabilities (tested on Krita 5.3.4, may not work with 5.2.x and older versions)
- A compatible device:
  - Loupedeck device with recent driver (Tested on Loupedeck CT and driver version 5.9.x and 6.1.0+)
  - Logitech MX Creative with Logi Options+
- A compatible computer with:
  - Windows 10 or later
  - Mac OS 12 or later for MX Creative or Mac OS 10.15 or later for Loupedeck CT

# Installation
From the [Loupedeck Marketplace](https://loupedeckmp.logi.com/asset/Krita), search for the Krita plugin, and install it.
From the [Logi Options+ marketplace](https://www.logitech.com/software/marketplace/plugin-listing.html) search for the Krita plugin, and install it.
The installation process will configure an extension into Krita, the name of this extension is "*Logi API Server*", please don't remove it.
For the very first installation, you may have to activate the plugin extension in Krita:
- Start Krita
- Go to *Settings*/*Configure Krita...*
- Go to the *Python Plugin Manager* section
- Check the box on the line "*Logi API Server*"
- Press *OK* to validate, then restart Krita.

The plugin and the Krita extension communicate through a socket on port 1247, for the moment this cannot be changed.

# Feedbacks and issues
If you need to give a feedback or raise a bug issue, you can use the following page: [https://github.com/Borne2Code/LogiPluginForKrita/issues](https://github.com/Borne2Code/LogiPluginForKrita/issues).

In addition, you may face some freezing situations, I daily use my Loupedeck device with Krita and usually don't face them, but during the development process, these cases occurred:
- In some rare cases, due to an issue with socket management in Python, Krita will freeze at start-up.
Unfortunately, we couldn't understand why, you may restart Krita until it starts correctly.
- When stopping the Loupedeck Driver, or uninstalling the Krita Plugin, any running instance of Krita can freeze, please be sure to save any open document and close Krita while doing a maintenance operation in the Loupedeck or Logi drivers.
You won't be anoyed if you enter the Loupedeck driver or Logi Options+ to manage and modify profiles.

# Features
Here the list of features that the Loupedeck device or MX Creative can activate directly on Krita (without keyboard shortcuts).
They're organized by feature groups:
* [**View, Canvas and general features**](./view.md) <img src="./images/NewSymbol.png" width="20px">
* [**Brush tools**](./brush_tools.md) <img src="./images/NewSymbol.png" width="20px">
* [**Edit**](./edit.md) <img src="./images/NewSymbol.png" width="20px">
* [**Color selector**](./color.md) <img src="./images/NewSymbol.png" width="20px">
* [**Layers**](./layers.md) <img src="./images/NewSymbol.png" width="20px">
* [**Selection**](./selection.md) <img src="./images/NewSymbol.png" width="20px">
* [**Animation**](./animation.md) <img src="./images/NewSymbol.png" width="20px">
* [**Filters**](./filters.md)

# Default Profile configuration
Disclaimer: the default profile hasn't a real workflow approach, but a feature approach.
Each workspace of the default profile is a set of features organized by features group.
Some of you won't agree and are free to apply their own profile, each of us has his/her own way to use Krita.

