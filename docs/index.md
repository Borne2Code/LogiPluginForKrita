# Logi Krita Plugin (For Logitech MX Creative and Loupedeck devices)
![](./images/ReadmeImage.png)
This plugin allows a better control of Krita with Logitech MX Creative and Loupedeck devices, using a direct control of the application without throwing keyboard shortcuts.
It has been developed and tested with a Loupedeck CT, then adapted to the Logitech MX Creative device, it works on Windows and Mac OS.

*If you're a developer and if you want want to contribute, please let me know.*
*I'm also searching for beta-testers*

# Hot news
This version has been deeply refunded to be compatible with Logitech MX Creative and Mac OS.

The support of Loupedeck devices and Windows remains, of course.

It has some added features (with the <img src="./images/NewSymbol.png" width="20px"> prefix in the documentation below), and many new dynamic folders.

New sets of features has been added:
* [**Edit**](./edit.md): to manage clipboard,
* **Color selector**: to manage the brush's current color,
* **Animation**: to manage animations

**WARNING**: Unfortunately, making this plugin compatible with MX Creative and Mac OS required to do structural changes that make your current profiles not working with this new version. You will have to recreate it, from the plugin's default profile or an empty profile.

**I promise, that will not happen again in the future.**

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
Here the list of features that the Loupedeck device or MX Creative can activate directly on Krita (without keyboard shortcuts).

## View, Canvas and general features

### Adjustments
* **Canvas zoom**: adjusts current view zoom (push to reset to 100%)
* **Canvas rotation**: adjusts current view rotation (push to reset to 0°)
* **Brush size**: adjusts brush size (no push)
* **Brush opacity**: adjusts brush opcity (push to reset 100%)
* **Brush flow**: adjusts brush flow (push to reset 100%)
* <img src="./images/NewSymbol.png" width="20px"> **Brush fade**: adjusts brush fade (no push)
* **Brush rotation**: adjusts brush pattern rotation (push to reset 0°)
* **Brush pattern size**: adjusts brush pattern size multiplier (push to reset x1)*

**: only with Krita 5.3.x - not tested*

### Commands
* **Mirror**: toggles canvas mirror mode
* **Action**: generic command to run Krita scripting actions*
* **Pen pressure**: Active/deactivate pen pressure sensor on the current brush

**: action names can be found at https://scripting.krita.org/action-dictionary.*

### <img src="./images/NewSymbol.png" width="20px"> Dynamic folders
* <img src="./images/NewSymbol.png" width="20px"> **View/Brush Tools**: opens a dynamic folder with the following actions and adjustments:
  * **Zoom adjustment**
  * **Rotation adjustment**
  * **Brush size adjustment**
  * **Brush opacity adjustment**
  * **Brush flow adjustment**
  * **Brush fade adjustment**
  * **Brush rotation adjustment**
  * **Brush pattern size adjustment**
  * **Mirror**

## Tools

### Commands
* **Bezier**: activates Bezier tool
* **Brush**: activates brush tool
* **Calligraphy**: activates calligraphy tool
* **Colorize mask**: activates colorize mask tool
* **Crop**: activates crop tool
* **Dynamic brush**: activates dynamic brush tool
* **Edit shape**: enters shape edit mode
* **Ellipse**: activates ellipse tool
* **Enclose and fill**: activates enclose and fill tool
* **Eraser**: toggles eraser mode
* **Fill**: activates fill tool
* **Freehand path**: activates freehand path tool
* **Gradient**: activates gradient tool
* **Line**: activates line tool
* **Move**: activates move tool
* **Multi Brush**: activates multibrush tool
* **Polygon**: activates polygone tool
* **Rectangle**: activates rectangle tool
* **Select Shape**: activates shape selector in a vector layer
* **Smart Patch**: activates smart Patch tool
* **Text**: activates Text tool
* **Transform**: activates Transform tool

### <img src="./images/NewSymbol.png" width="20px"> Dynamic folders
* <img src="./images/NewSymbol.png" width="20px"> **Paint Tools**: opens a dynamic folder with the following actions and adjustments:
  * **Brush**
  * **Fill**
  * **Gradient**
  * **DynamicBrush**
  * **MultiBrush**
  * **ColorizeMask**
  * **SmartPatch**
  * **EncloseAndFill**
* <img src="./images/NewSymbol.png" width="20px"> **Vector Tools**: opens a dynamic folder with the following actions and adjustments:
  * **SelectShape**
  * **Text**
  * **EditShape** 
  * **Calligraphy**
  * **Line**
  * **Ellipse**
  * **Rectangle**
  * **Polygon**
  * **Polyline**
  * **Bezier**
  * **FreeHandPath**
* <img src="./images/NewSymbol.png" width="20px"> **Transform Tools**: opens a dynamic folder with the following actions and adjustments:
  * **Transform**
  * **Move**
  * **Crop**

## <img src="./images/NewSymbol.png" width="20px"> Edit

### Commands
* <img src="./images/NewSymbol.png" width="20px"> **Copy**: Copies the current layer content or selection into clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Cut**: Cuts the current layer content or selection into clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Paste**: Pastes the clipboard into a new layer
* <img src="./images/NewSymbol.png" width="20px"> **Delete**: Deletes the current layer content or selection
* <img src="./images/NewSymbol.png" width="20px"> **Fill with Foreground**: Fills the current layer content or selection with the foreground color
* <img src="./images/NewSymbol.png" width="20px"> **Fill with Background**: Fills the current layer content or selection with the background color
* <img src="./images/NewSymbol.png" width="20px"> **Paste Into Layer**: Pastes the clipboard into the current layer
* <img src="./images/NewSymbol.png" width="20px"> **Paste New Image**: Pastes the clipboard as new image
* <img src="./images/NewSymbol.png" width="20px"> **Copy Sharp**: Copies the current layer content or selection without transparency into clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Cut Sharp**: Cuts the current layer content or selection without transparency into clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Paste Cursor**: Pastes the clipboard at cursor location
* <img src="./images/NewSymbol.png" width="20px"> **Paste As Ref**: Pastes the clipboard as reference image

### Dynamic folders
* <img src="./images/NewSymbol.png" width="20px"> **Edit tools**: opens a dynamic folder with the following actions and adjustments:
  * **Copy**
  * **Cut**
  * **Paste**
  * **Delete**
  * **Fill with Foreground**
  * **Fill with Background**
  * **Paste Into Layer**
  * **Paste New Image**
  * **Copy Sharp**
  * **Cut Sharp**
  * **Paste Cursor**
  * **Paste As Ref**

## <img src="./images/NewSymbol.png" width="20px"> Color selector

### <img src="./images/NewSymbol.png" width="20px"> Adjustments
* <img src="./images/NewSymbol.png" width="20px"> **Adjust color Hue**: Adjusts the Hue of the brush's color (no push)
* <img src="./images/NewSymbol.png" width="20px"> **Adjust color lightness**: Adjusts the lightness of the brush's color (no push)
* <img src="./images/NewSymbol.png" width="20px"> **Adjust color saturation**: Adjusts the saturation of the brush's color (no push)
* <img src="./images/NewSymbol.png" width="20px"> **Adjust color Red/Green**: Adjusts the brush's color more Red or more Green
* <img src="./images/NewSymbol.png" width="20px"> **Adjust color Yellow/Blue**: Adjusts the brush's color more Yellow or more Blue

### <img src="./images/NewSymbol.png" width="20px"> Commands
* <img src="./images/NewSymbol.png" width="20px"> **Swap colors**: Swap colors between foreground and background
* <img src="./images/NewSymbol.png" width="20px"> **Sample color**: Samples the color under the cursor and sets it as foreground color

### <img src="./images/NewSymbol.png" width="20px"> Dynamic folders
* <img src="./images/NewSymbol.png" width="20px"> **ColorSelector tools**: opens a dynamic folder with the following actions and adjustments:
  * **Adjust color Hue**
  * **Adjust color lightness**
  * **Adjust color saturation**
  * **Adjust color Red/Green**
  * **Adjust color Yellow/Blue**
  * **Swap colors**
  * **Sample color**

## Layers

### Adjustments
* **Current Layer**: adjusts current selected layer (push to soloing current layer)
* **Layer Opacity**: adjusts current layer opacity (push to reset to 100%)
* **Move layer**: moves selected layer up/down (push to toggle layer visible)

### Commands
* <img src="./images/NewSymbol.png" width="20px"> **Copy layer**: copy the current layer to clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Copy layer style**: copy the current layer style to clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Cut layer**: cut the current layer to clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Isolate**: make only the current layer visible for display
* <img src="./images/NewSymbol.png" width="20px"> **Paste layer**: paste the layer from clipboard
* <img src="./images/NewSymbol.png" width="20px"> **Paste layer style**: Paste the layer style from clipboard to the current layer
* **Delete Layer**: deletes selected layer
* **Duplicate layer**: duplicates selected layer
* **Flatten layer**: flattens selected group/layer into a single raster layer
* **Global selection**: selects global selection mask
* **Inherit alpha**: toogles selected layer's alpha inheritance
* **Layer properties***: shows selected layer properties
* **Layer style**: shows layer style dialog
* **Lock alpha**: toogles selected layer's alpha locking
* **Lock/Unlock layer**: toggles selected layer's locking
* **Merge with below**: merges the selected layer with the layer below
* **New clone layer**: adds a clone layer based on the selected layer
* **New colorize mask**: adds a new colorize mask
* **New file layer**: adds a new file layer
* **New fill layer**: adds a new fill layer
* **New filter layer**: adds a new filter layer
* **New filter mask**: adds a filter mask to the selected layer
* **New group**: adds a new group
* **New local selection**: adds a new local selection to the selected layer
* **New paint layer**: adds a new raster layer
* **New transform mask**: adds a new transform mask to the selected layer
* **New vector layer**: adds a new vector layer
* **Quick clipping group**: builds a new clipping group based a the selected layer
* **Quick group**: adds a group containing the selected layer(s)
* **Rename layer**: renames the selected layer
* **Toggle layer visible**: toggles the selected layer visibility
* **Ungroup**: ungroups the selected group

**: this layer properties is a simple command, you may prefer the layer properties (dynamic) command which opens a dynamic folder on the Loupedeck device with some controls (see below)*

### Dynamic Folders
* **Layer properties (dynamic)**: shows selected layer properties
  * On a Raster layer, a Group, a Clone layer or a Vector layer, allows the following actions in the dialog:
	* **Visible command**: toggles the visible checkbox
	* **Locked command**: toggles the Locked checkbox
	* **Inherit Alpha command**: toggles the Inherit Alpha checkbox
	* **Alpha Locked command**: toggles the Alpha Locked checkbox
	* **Channel Blue command**: toggles the blue channel activation
	* **Channel Green command**: toggles the green channel activation
	* **Channel Red command**: toggles the red channel activation
	* **Channel Alpha command**: toggles the alpha channel activation
	* **Opacity adjustment**: adjust the layer's opacity
  * On a file layer, allows the following actions in the dialog:
	* **Choose file**: opens the file selection dialog
	* **No scale**: selects the No scale radio for scaling mode
	* **Scale to image**: selects the Scale to image radio for scaling mode
	* **Scale  to PPI**: selects the Scale  to PPI radio for scaling mode
  * On a filter layer or a filter mask, allows the control of the dialog as described in the Filters' section.
  * On other layer types, the dynamic folder is empty.
* <img src="./images/NewSymbol.png" width="20px"> **Layer tools**: opens a dynamic folder with the following actions and adjustments:
  * **Select Current adjustment**
  * **Opacity adjustment**
  * **Isolate**
  * **Move adjustment**
  * **Style**
  * **Global Selection**
  * **Rename**
  * **Duplicate**
  * **Delete**
  * **Lock/Unlock**
  * **Toggle Visible**
  * **Inherit Alpha**
  * **Lock Alpha**
  * **Quick Group**
  * **New Group**
  * **Ungroup**
  * **Quick Clipping Group**
  * **Merge With Below**
  * **Flatten**
  * **Copy**
  * **Cut**
  * **Paste**
  * **Copy Style**
  * **Paste Style**
* <img src="./images/NewSymbol.png" width="20px"> **New layer tools**: opens a dynamic folder with the following actions and adjustments:
  * **New Paint Layer**
  * **New Vector Layer**
  * **New Fill Layer**
  * **New Filter Layer**
  * **New Filter Mask**
  * **New Transparency Mask**
  * **New Transform Mask**
  * **New Clone Layer**
  * **New File Layer**
  * **New Colorize Mask**
  * **New Local Selection**
* <img src="./images/NewSymbol.png" width="20px"> **Groups tools**: opens a dynamic folder with the following actions and adjustments:
  * **Select Current adjustment**
  * **Move adjustment**
  * **Isolate**
  * **Quick Group**
  * **New Group**
  * **Ungroup**
  * **Quick Clipping Group**
  * **Merge With Below**
  * **Flatten**

## Selections

### Adjustments
* **Selection Grow/Shrink**: grows or shrinks the current selection (no push)*

**: This operation is destructive, it's impossible to return back to original selection. Due to bad implementation of the feature in Krita, this can fail in some cases.*

### Commands
* **Bezier selection**: activates the bezier selection tools
* **Contiguous selection**: activates the contiguous color selection tool
* **Delete selection**: removes the current selection
* **Eliptical selection**: activates the eliptical selection tool
* **Freehand selection**: activates the freehand selection tool
* **Invert selection**: inverts the current selection
* **Magnetic selection**: activates the magnetic selection tool
* **Polygonal selection**: activates the polygonal selection tool
* **Rectangular selection**: activate the rectangular selection tool
* **Select All**: selects the full canvas
* **Similar colors selection**: activates the similar colors selection tool
* <img src="./images/NewSymbol.png" width="20px"> **Mode Replace**: replace the existing selection by a new one
* <img src="./images/NewSymbol.png" width="20px"> **Mode Add**: adds the new selection to the existing selection
* <img src="./images/NewSymbol.png" width="20px"> **Mode Substract**: substracts the new selection from the existing selection
* <img src="./images/NewSymbol.png" width="20px"> **Mode Intersect**: intersects the new selection with the existing selection

### <img src="./images/NewSymbol.png" width="20px"> Dynamic folders
* <img src="./images/NewSymbol.png" width="20px"> **Selection tools**: opens a dynamic folder with the following actions and adjustments:
  * **Rectangle**
  * **Elipse**
  * **Polygone**
  * **Freehand**
  * **Select All**
  * **Invert**
  * **Delete**
  * **Contiguous**
  * **Similar Color**
  * **Bezier**
  * **Magnetic**
  * **GrowShrink adjustment**
  * **Mode Replace**
  * **Mode Add**
  * **Mode Substract**
  * **Mode Intersect**
* <img src="./images/NewSymbol.png" width="20px"> **Selection mode tools**: opens a dynamic folder with the following actions and adjustments:
  * **Mode Replace**
  * **Mode Add**
  * **Mode Substract**
  * **Mode Intersect**

## <img src="./images/NewSymbol.png" width="20px"> Animation

### Adjustments
* <img src="./images/NewSymbol.png" width="20px"> **Frame adjustment**: changes current frame to next/previous
* <img src="./images/NewSymbol.png" width="20px"> **Keyframe adjustment**: changes current frame to next/previous keyframe

### Commmands
* <img src="./images/NewSymbol.png" width="20px"> **Play/pause**: starts or pauses the animation playback
* <img src="./images/NewSymbol.png" width="20px"> **Stop**: stops the animation playback and select first frame

### Dynamic folders
* <img src="./images/NewSymbol.png" width="20px"> **Animation tools**: opens a dynamic folder with the following actions and adjustments:
  * **Frame adjustment**
  * **Keyframe adjustment**
  * **Play/pause**
  * **Stop**

## Filters

### Commmands
* **Apply filter again**: Applys again the previous filter
* **Apply filter again...**: Applys again the previous filter with dialog
* **Autocontrast**: applies the Autocontrast filter (Adjust). It has no dialog.
* **Invert command**: applies the invert filter (Adjust). It has no,dialog.
* **Maximize channels command**: applies the Maximize channels filter (Colors). It has no,dialog.
* **Minimize channels command**: applies the Minimize channels filter (Colors). It has no,dialog.
* **Emboss All directions command**: applies the Emboss All directions filter (Emboss). It has no dialog.
* **Emboss Horizontal only command**: applies the Emboss Horizontal only filter (Emboss). It has no dialog.
* **Emboss Laplacian command**: applies the Emboss Laplacian filter (Emboss). It has no dialog.
* **Emboss Vertical & Horizontal command**: applies the Emboss Vertical & Horizontal filter (Emboss). It has no dialog.
* **Emboss Vertical only command**: applies the Emboss Vertical only filter (Emboss). It has no dialog.
* **Mean removal command**: applies the Mean removal filter (Enhance). It has no dialog.
* **Sharpen command**: applies the Sharpen filter (Enhance). It has no dialog.
* **Normalize command**: applies the Normalize filter (Map). It has no dialog.
* **Reset Transparent command**: applies the Reset Transparent filter (Others). It has no dialog.

### Dynamic folders

#### Adjust filters
* **AscCdl**: Opens the AscCdl filter dialog, and allows the following actions in the dialog:
  * *No actions for the moment*
* **Burn**: Opens the Burn filter dialog, and allows the following actions in the dialog:
  * **Shadows command**: selects the shadows radio
  * **Midtones command**: selects the Midtones radio
  * **Highlights command**: selects the Highlights radio
  * **Exposure adjustment**: adjust the Exposure slider
* **Colors balance command**: Opens the Colors balance filter dialog, and allows the following actions in the dialog:
  * **Reset Shadows command**: Resets the shadows adjustments
  * **Reset Midtones command**: Resets the midtones adjustments
  * **Reset Highlights command**: Resets the Highlights adjustments
  * **Preserve Luminosity command**: toggles the preserve luminosity checkbox
  * **Shadows Cyan/Red adjustment**: adjusts the Shadows Cyan/Red slider
  * **Shadows Magenta/Green adjustment**: adjusts the Shadows Magenta/Green slider
  * **Shadows Yellow/Blue adjustment**: adjusts the Shadows Yellow/Blue slider
  * **Midtones Cyan/Red adjustment**: adjusts the Midtones Cyan/Red slider
  * **Midtones Magenta/Green adjustement**: adjusts the Midtones Magenta/Green slider
  * **Midtones Yellow/Blue adjustement**: adjusts the Midtones Yellow/Blue slider
  * **Highlights Cyan/Red adjustment**: adjusts the Highlights Cyan/Red slider
  * **Highlights Magenta/Green adjustment**: adjusts the Highlights Magenta/Green slider
  * **Highlights Yellow/Blue adjustment**: adjusts the Highlights Yellow/Blue slider
* **Cross channel Adjustment**: Opens the Cross channel Adjustment filter dialog, and allows the following actions in the dialog:
  * **Channel RGBA command**: selects the RGBA option in the Channel dropdown
  * **Channel Red command**: selects the Red option in the Channel dropdown
  * **Channel Green command**: selects the Green option in the Channel dropdown
  * **Channel Blue command**: select the Blue option in the Channel dropdown
  * **Channel Alpha command**: select the Alpha option in the Channel dropdown
  * **Channel Hue command**: select the Hue option in the Channel dropdown
  * **Channel Saturation command**: select the Saturation option in the Channel dropdown
  * **Channel Lightness command**: select the Lightness option in the Channel dropdown
  * **Driver Red command**: selects the Red option in the Driver dropdown
  * **Driver Green command**: selects the Green option in the Driver dropdown
  * **Driver Blue command**: select the Blue option in the Driver dropdown
  * **Driver Alpha command**: select the Alpha option in the Driver dropdown
  * **Driver Hue command**: select the Hue option in the Driver dropdown
  * **Driver Saturation command**: select the Saturation option in the Driver dropdown
  * **Driver Lightness command**: select the Lightness option in the Driver dropdown
  * **Logarithmic command**: toggles the Logarithmic checkbox
  * **Reset command**: clicks the Reset button
  * **Input adjustment**: adjusts the value of input (for current node)
  * **Output adjustment**: adjusts the value of output (for current node)
  * *no controls for nodes manipulation*
* **Desaturate**: Opens the Desaturate filter dialog, and allows the following actions in the dialog:
  * **Lightness command**: selects the Lightness radio
  * **Luminosity (BT709) command**: selects the Luminosity (BT709) radio
  * **Luminosity (BT601) command**: selects the Luminosity (BT601) radio
  * **Average command**: selects the Average radio
  * **Minimum command**: selects the Minimum radio
  * **Maximum command**: selects the Maximum radio
* **Dodge**: Opens the Dodge filter dialog, and allows the following actions in the dialog:
  * **Shadows command**: selects the Shadows radio
  * **Midtones command**: selects the Midtones radio
  * **Highlights command**: selects the Highlights radio
  * **Exposure adjustment**: adjusts the value of Exposure slider
* **Hsv/Hsl Adjustment**: Opens the Hsv/Hsl Adjustment filter dialog, and allows the following actions in the dialog:
  * **Mode Hue/Sat/Value command**: activates the Hue/Sat/Value option of Mode dropdown
  * **Mode Hue/Sat/Lightness command**: activates the Hue/Sat/Lightness option of Mode dropdown
  * **Mode Hue/Sat/Intensity command**: activates the Hue/Sat/Intensity option of Mode dropdown
  * **Mode Hue/Sat/Luma command**: activates the Hue/Sat/Luma option of Mode dropdown
  * **Mode Blue Chroma/Red Chroma/Luma command**: activates the Blue Chroma/Red Chroma/Luma option of Mode dropdown
  * **Colorize command**: toggles the Colorize checkbox
  * **Legacy mode command**: toggles the Legacy mode checkbox
  * **Hue adjustment**: adjusts the value of Hue slider
  * **Saturation adjustment**: adjusts the value of Saturation slider
  * **Value adjustment**: adjusts the value of Value slider
* **Levels**: Opens the Levels filter dialog, and allows the following actions in the dialog:
  * **Lightness command**: activates the Lightness only mode
  * **All channels command**: activates the All channels mode
  * **Reset command**: resets all filter settings
  * **Reset input levels command**: resets the input settings
  * **Reset output levels command**: resets the output settings
  * **Linear histogram command**: sets the linear display of histograms
  * **Logarithmic histogram command**: sets the Logarithmic display of histograms
  * **Scale to fit command**: scales histograms to fit
  * **Scale to cut long peaks command**: scales histograms to cut the highest values
  * **Channel RGBA command**: in All channels mode, activates the level filter to RGBA channels
  * **Channel Red command**: in All channels mode, activates the level filter to Red channel
  * **Channel Green command**: in All channels mode, activates the level filter to Green channel
  * **Channel Blue command**: in All channels mode, activates the level filter to Blue channel
  * **Channel Alpha command**: in All channels mode, activates the level filter to Alpha channel
  * **Channel Hue command**: in All channels mode, activates the level filter to Hue channel
  * **Channel Saturation command**: in All channels mode, activates the level filter to Saturation channel
  * **Channel Lightness command**: in All channels mode, activates the level filter to Lightness channel
  * **Auto levels command**: automatically sets levels settings
  * **Reset all channels command**: in All channels mode, resets the settings
  * **Input Black adjustment**: adjusts the Black value of input
  * **Input Gamma adjustment**: adjusts the Gamma value of input
  * **Input White adjustment**: adjusts the White value of input
  * **Output Black adjustment**: adjusts the Black value of output
  * **Output  White adjustment**: adjusts the white value of output
* **Color Adjustment**: Opens the Color Adjustment filter dialog, and allows the following actions in the dialog:
  * **Channel RGBA command**: activates the color adjustment filter to RGBA channels
  * **Channel Red command**: activates the color adjustment filter to Red channel
  * **Channel Green command**: activates the color adjustment filter to Green channel
  * **Channel Blue command**: activates the color adjustment filter to Blue channel
  * **Channel Alpha command**: activates the color adjustment filter to Alpha channel
  * **Channel Hue command**: activates the color adjustment filter to Hue channel
  * **Channel Saturation command**: activates the color adjustment filter to Saturation channel
  * **Channel Lightness command**: activates the color adjustment filter to Lightness channel
  * **Logarithmic command**: toggles the Logarithmic checkbox
  * **Reset command**: resets the color adjustment filter settings
  * **Input adjustment**: adjusts the value of input (for current node)
  * **Output adjustment**: adjusts the value of output (for current node)
  * *no controls for nodes manipulation*
* **Threshold**: Opens the Threshold filter dialog, and allows the following actions in the dialog:
  * **Threshold adjustment**: adjusts the threshold slider

#### Artistic filters
* **Halftone**: Opens the Halftone filter dialog, and allows the following actions in the dialog:
  * *No actions for the moment*
* **Index colors**: Opens the Index colors filter dialog, and allows the following actions in the dialog:
  * *No actions for the moment*
* **Oil Paint**: Opens the Oil Paint filter dialog, and allows the following actions in the dialog:
  * **Brush size adjustment**: adjusts the Brush size slider
  * **Smooth adjustment**: adjusts the Smooth slider
* **Pixelize**: Opens the Pixelize filter dialog, and allows the following actions in the dialog:
  * **Pixel width adjustment**: adjusts the Pixel width slider
  * **Pixel height adjustment**: adjusts the Pixel height slider
* **Posterize**: Opens the Posterize filter dialog, and allows the following actions in the dialog:
  * **Steps adjustment**: adjusts the Steps slider
* **Rain Drops**: Opens the Rain Drops filter dialog, and allows the following actions in the dialog:
  * **Drop size adjustment**: adjusts the Drop size slider
  * **Number adjustment**: adjusts the Number slider
  * **Fish eyes adjustment**: adjusts the Fish eyes slider

#### Blur filters
* **Blur**: Opens the Blur filter dialog, and allows the following actions in the dialog:
  * **Lock Hor./Vert. command**: toggles the Lock Hor./Vert.button
  * **Shape Circle command**: Selects the Circle option of the Shape dropdown
  * **Shape Rectangle command**: Selects the Rectangle option of the Shape dropdown
  * **Horizontal radius adjustment**: adjusts the Horizontal radius slider
  * **Vertical radius adjustment**: adjusts the Vertical radius slider
  * **Strength adjustment**: adjusts the Strength slider
  * **Angle adjustment**: adjusts the Angle angle selector
* **Gaussian Blur**: Opens the Gaussian Blur filter dialog, and allows the following actions in the dialog:
  * **Lock aspect command**: toggles the Lock aspect button
  * **Horizontal radius adjustment**: adjusts the Horizontal radius slider
  * **Vertical radius adjustment**: adjusts the Vertical radius slider
* **Lens Blur**: Opens the Lens Blur filter dialog, and allows the following actions in the dialog:
  * **Shape triangle command**: selects the triangle option of the Shape dropdown
  * **Shape quadrilateral command**: selects the quadrilateral option of the Shape dropdown
  * **Shape pentagon command**: selects the pentagon option of the Shape dropdown
  * **Shape hexagon command**: selects the hexagon option of the Shape dropdown
  * **Shape heptagon command**: selects the heptagon option of the Shape dropdown
  * **Shape octagon command**: selects the octagon option of the Shape dropdown
  * **Radius adjustment**: adjusts the Radius slider
  * **Iris rotation adjustment**: adjusts the Iris rotation angle selector
* **Motion Blur**: Opens the Motion Blur filter dialog, and allows the following actions in the dialog:
  * **Angle adjustment**: adjusts the Angle angle selector
  * **Length adjustment**: adjusts the Length slider

#### Colors filters
* **Color to alpha**: Opens the Color to alpha filter dialog, and allows the following actions in the dialog:
  * **Threshold adjustment**: Adjusts the Threshold slider
  * *no controls for Color selection*
* **Color transfer**: Opens the Color transfer filter dialog, and allows the following actions in the dialog:
  * **Select file... command**: opens the file selection dialog

#### Edge Detection filters
* **Edge detection**: Opens the Edge detection filter dialog, and allows the following actions in the dialog:
  * **Formula Prewitt command**: selects the Prewitt option of the Formula dropdown
  * **Formula Sobel command**: selects the Sobel option of the Formula dropdown
  * **Formula Simple command**: selects the Simple option of the Formula dropdown
  * **Lock aspect command**: toggles the Lock aspect checkbox
  * **Output aLl sides command**: selects the aLl sides option of the Output dropdown
  * **Output Top Edge command**: selects the Output Top Edge option of the Output dropdown
  * **Output Bottom Edge command**: selects the Bottom Edge option of the Output dropdown
  * **Output Right Edge command**: selects the Right Edge option of the Output dropdown
  * **Output Left Edge command**: selects the Left Edge option of the Output dropdown
  * **Output Direction In Radians command**: selects the Direction In Radians option of the Output dropdown
  * **Apply to alpha command**: toggles the Apply to alpha checkbox
  * **Horizontal radius adjustment**: adjusts the Horizontal radius slider
  * **Vertical radius adjustment**: adjusts the Vertical radius slider
* **Gaussian High-Pass**: Opens the Gaussian High-Pass filter dialog, and allows the following actions in the dialog:
  * **Radius adjustment**: adjusts the Radius slider
* **Height To Normal**: Opens the Height To Normal filter dialog, and allows the following actions in the dialog:
  * **Formula Prewitt command**: selects the Prewitt option of the Formula dropdown
  * **Formula Sobel command**: selects the Sobel option of the Formula dropdown
  * **Formula Simple command**: selects the Simple option of the Formula dropdown
  * **Channel Blue command**: selects the Blue option of the Channel dropdown
  * **Channel Green command**: selects the Green option of the Channel dropdown
  * **Channel Red command**: selects the Red option of the Channel dropdown
  * **Channel Alpha command**: selects the Alpha option of the Channel dropdown
  * **Lock Hor./Vert. command**: toggles the Lock Hor./Vert. checkbox
  * **X=X command**: selects the X option of the X dropdown
  * **X=-X command**: selects the -X option of the X dropdown
  * **X=Y command**: selects the Y option of the X dropdown
  * **X=-Y command**: selects the -Y option of the X dropdown
  * **X=Z command**: selects the Z option of the X dropdown
  * **X=-Z command**: selects the -Z option of the X dropdown
  * **Y=X command**: selects the X option of the Y dropdown
  * **Y=-X command**: selects the -X option of the Y dropdown
  * **Y=Y command**: selects the Y option of the Y dropdown
  * **Y=-Y command**: selects the -Y option of the Y dropdown
  * **Y=Z command**: selects the Z option of the Y dropdown
  * **Y=-Z command**: selects the -Z option of the Y dropdown
  * **Z=X command**: selects the X option of the Z dropdown
  * **Z=-X command**: selects the -X option of the Z dropdown
  * **Z=Y command**: selects the Y option of the Z dropdown
  * **Z=-Y command**: selects the -Y option of the Z dropdown
  * **Z=Z command**: selects the Z option of the Z dropdown
  * **Z=-Z command**: selects the -Z option of the Z dropdown
  * **Horizontal radius adjustment**: adjusts the Horizontal radius slider
  * **Vertical radius adjustment**: adjusts the Vertical radius slider

#### Emboss filters
* **Emboss**: Opens the Emboss filter dialog, and allows the following actions in the dialog:
  * **Depth adjustment**: adjusts the Depth slider

#### Enhance filters
* **Gaussian Noise Reducer**: Opens the Gaussian Noise Reducer filter dialog, and allows the following actions in the dialog:
  * **Threshold adjustment**: adjusts the Threshold slider
  * **Window Size adjustment**: adjusts the Window Size slider
* **Unsharp Mask**: Opens the Unsharp Mask filter dialog, and allows the following actions in the dialog:
  * **Lightness only command**: toggles the Lightness only checkbox
  * **Radius adjustment**: adjusts the Radius slider
  * **Amount adjustment**: adjusts the Amount slider
  * **Threshold adjustment**: adjusts the Threshold slider
* **Wavelet Noise Reducer**: Opens the Wavelet Noise Reducer filter dialog, and allows the following actions in the dialog:
  * **Threshold adjustment**: adjusts the Threshold slider

#### Map filters
* **Gradient Map**: Opens the Gradient Map filter dialog, and allows the following actions in the dialog:
  * *No actions for the moment*
* **Palettize**: Opens the Palettize filter dialog, and allows the following actions in the dialog:
  * *No actions for the moment*
* **Phong Bumpmap**: Opens the Phong Bumpmap filter dialog, and allows the following actions in the dialog:
  * *No actions for the moment*
* **Round Corners**: Opens the Round Corners filter dialog, and allows the following actions in the dialog:
  * **Radius adjustment**: adjusts the Radius slider
* **Small Tiles**: Opens the Small Tiles filter dialog, and allows the following actions in the dialog:
  * **Number adjustment**: adjusts the Number slider

#### Others filters
* **Random Noise**: Opens the Random Noise filter dialog, and allows the following actions in the dialog:
  * **Level adjustment**: adjusts the Level slider
  * **Opacity adjustment**: adjusts the Opacity slider
* **Random Pick**: Opens the Random Pick filter dialog, and allows the following actions in the dialog:
  * **Level adjustment**: adjusts the Level slider
  * **Window Size adjustment**: adjusts the Window Size slider
  * **Opacity adjustment**: adjusts the Opacity slider
* **Wave**: Opens the Wave filter dialog, and allows the following actions in the dialog:
  * **Hor. shape Sinus command**: selects the Sinus option of the Hor. shape dropdown
  * **Hor. shape Triangle command**: selects the Triangle option of the Hor. shape dropdown
  * **Vert. shape Sinus command**: selects the Sinus option of the Vert. shape dropdown
  * **Vert. shape Triangle command**: selects the Triangle option of the Vert. shape dropdown
  * **Hor. Wave length adjustment**: adjusts the Wave length slider in Horizontal panel
  * **Hor. Shift adjustment**: adjusts the Shift slider in Horizontal panel
  * **Hor. Amplitude adjustment**: adjusts the Amplitude slider in Horizontal panel
  * **Vert. Wave length adjustment**: adjusts the Wave length slider in Vertical panel
  * **Vert. Shift adjustment**: adjusts the Shift slider in Vertical panel
  * **Vert. Amplitude adjustment**: adjusts the Amplitude slider in Vertical panel

# Default Profile configuration
Disclaimer: the default profile hasn't a real workflow approach, but a feature approach.
Each workspace of the default profile is a set of features organized by features group.
Some of you won't agree and are free to apply their own profile, each of us has his/her own way to use Krita.

