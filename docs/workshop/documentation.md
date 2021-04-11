---
title: Documentation
layout: wspage
date: 2020-11-24
Author: Phoenixx19
comments: false
toc: true
pinned: false
---

<style>
    .rectangle {
        width:20px;
        height:20px;
        border: solid 1px grey;
        border-radius: 5px;
        display: inline-block;
    }
    .rectangle-gradient {
        width:40px;
        height:20px;
        border: solid 1px grey;
        border-radius: 5px;
        display: inline-block;
    }
</style>

Welcome to the documentation for custom levels on Jump King using JumpKingPlus! On your left you can find the table of contents with everything you should need to make a custom level.

<a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/documentation.pdf" title="Saves as a .pdf file"><ion-icon name="cloud-download"></ion-icon> Save documentation</a>

## Warning
When this document referres on a folder, this is obviously meant to be inside `Jump King/Content/mods`, JumpKingPlus does **not** take any responsibility of your actions as you agreed downloading JumpKingPlus with a MIT License.

I reccomend you to use the **working sample level** to start with, and edit it for your new custom level!

## Requirements for building custom levels
> Custom levels are available only using __JumpKingPlus on [v1.2.0](https://github.com/Phoenixx19/JumpKingPlus/releases/tag/v1.2.0) or above__.

- The [__sample custom level__](https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/SampleCustomLevel.zip) by Phoenixx19
- A simple pixel art editor (Aseprite or GraphicsGale)
- A good image editor for editing and exporting hitboxes (GIMP or Adobe Photoshop)
- [JumpKingManager](https://github.com/ShootMe/LiveSplit.JumpKing/releases/latest) to access one area quickly
- Programs to convert images, music and fonts:
  - [XNBCLI](https://github.com/LeonBlade/xnbcli/releases/latest) for converting **images** into XNB and viceversa

  - [Fast XNB Builder](https://github.com/Phoenixx19/Fast-XNB-Builder/releases/tag/r3) for converting **images and music** into XNB

  - Visual Studio 2019 (or above) using MonoGame for converting all files; check out more [**here**](#convert-all-vs2019monogame), this is pretty long and time consuming I suggest you to not use it unless you have to.
- *(optional)* [JKPlusModManager](https://github.com/Phoenixx19/JumpKingPlus/releases/download/v1.2.0/JKPlusModManager-v0.1.0.exe) to unload and load custom levels

## Common rules
Level design in Jump King is a delicate balance between fairness and hardness. These rules are not only made to prevent unfair and impossible levels but to respect Nexile's original ideas on level design. Also in order to get your map approved on the site, these rules **need** to be followed.

1. __Screen transitions must be full jumps__; it would be unfair for a player not knowing how to jump over a new screen

2. __Transition platforms should always work__ (with a full jump) and they __must not be related to a specific position__ in the platform before the transition to the new screen

3. __Platforms must be bordered with a line__ (with at least 1px)

4. Do not exaggerate with the Lost Frontier jumps (8px platform equals to 1px in the hitboxes file), that area sucks

Testing is the most important phase of your level that should take you a lot of time, a good level has every single fall calculated, nothing is left to be random. Check out some more tips [**here**](https://phoenixx19.github.io/JumpKingPlus/workshop/commonrules/).

---

## Testing
As said before, testing is a very important part of creating a custom level. In order to get your files working in-game; here's a section dedicated for that.

### Getting started
0. Download the sample level from the requirements.
1. Drag the `mods` folder from the zip file to `Jump King/Content` folder.
2. You now have a custom map ready to work on!

### Convert images and music (Fast XNB Builder)
Fast XNB Builder can only pack images.

1. Download the release for Fast XNB Builder in the links above.
2. Create a folder with all the items you want to pack.
3. Open `Fast XNB Builder.exe` and select the folder you previously created.
4. If succeded, you will find your files inside `/Final` folder.

### Convert images (XNBCLI)
0. Install prerequisites of XNBCLI available [here](https://github.com/LeonBlade/xnbcli/blob/master/README.md).
1. Download the latest release for XNBCLI in the links above.
2. Export the `xnbcli-windows-x64.zip` file.

#### Unpack images
If you want to unpack an image from the game, put the file inside the `packed` folder and open the `unpack.bat`. If succeeded, you will find your files inside the `unpacked` folder.

#### Pack images
If you want to pack an image to put on the mod, make sure you have the .json file of your file ready to get packed with your image. If you never unpacked an image you can use this simple .json and modify for your own use! 

<span style="color: grey; font-size: small; font-weight:600;">YOURFILENAMEHERE.json&nbsp;&nbsp;<a class="ws-button code-show" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/YOURFILENAMEHERE.json"><ion-icon name="code-download"></ion-icon> Download</a></span>
```json
{
    "header": {
        "target": "w",
        "formatVersion": 5,
        "hidef": false,
        "compressed": false
    },
    "readers": [
        {
            "type": "Microsoft.Xna.Framework.Content.Texture2DReader",
            "version": 0
        }
    ],
    "content": {
        "format": 0,
        "export": "YOURFILENAMEHERE.png"
    }
}
```

Once put your image inside the `unpacked` folder with the .json file, you can open the `pack.bat`. And if succeeded, you managed to create your very own custom texture! The packed file can be found inside the `packed` folder.

### Convert all (VS2019+MonoGame)
Last warning. This takes a lot in both space on your drive and time. Choose only if this is your last hope.
1. Install Visual Studio Community 2019.

2. Download *.NET desktop development*.

3. Install MonoGame from the official website.

4. [**Follow these instructions**](https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_windows.html#install-monogame-extension-for-visual-studio-2019) (from __Install MonoGame extension for Visual Studio 2019__ to __Install MGCB Editor__ included!).

5. Reopen and create a new project in Visual Studio with the template: ![Project](https://docs.monogame.net/images/getting_started/vswin-mg-new-2.png) (the project name does not matter)

6. On the right side of the screen (Solution Explorer), open the folder Content and open the file `Content.mgcb`. If you have installed MGCB Editor this will show up: ![MGCBE](https://docs.monogame.net/images/MGCB-editor.png)

7. To add convert images, audio files and fonts you need to add files using the rectangle with a yellow asterisk with tool tip saying Add Item.

8. Select all the items you have to convert. To convert fonts, [__follow these instructions__](https://stackoverflow.com/questions/55045066/how-do-i-convert-a-ttf-or-other-font-to-a-xnb-xna-game-studio-font).

9. Save the Content file and build it.

10. You will find all your packed file in: `project directory/bin/x86/Debug/Content/`.

---

## Modding
After installing and downloading all the files needed; you can start working on your first custom level. In order to make the custom level working you will need to create two files inside your `JumpKing/Contents/mods` folder. JumpKingPlus loads the custom mode when both the `level.xnb` and the `mod.xml` files are in the folder above.

### Mod config file
<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/mod.xml"><ion-icon name="code"></ion-icon> Blank mod.xml</a><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/example_mod.xml"><ion-icon name="code-slash"></ion-icon> Example mod.xml</a></div>

In this file, you will set up the basics information of your level such as:

|name|about|optional|
|---|---|---|
|`<About>`|Contains the fundamentals of the mod|✖|
|`<title>`|Title of the custom level (will show up in the Stats Display window)|✖|
|`<ending_screen>`|Screen where the babe spawns|✖|
|`<Fonts>`|Array of available fonts (MenuFont, MenuFontSmall, StyleFont, OptimusUnderline, Tangerine, LocationFont, GargoyleFont)|✔|
|`<Ending>`|Contains the babe ending images, only one story is available for now|✖|
|`<MainBabe>`|Screen for beating the custom game|✖|
|`<MainShoes>`|Screen for beating the custom game with the Giant Boots|✖|
|`<EndingLines>`|Credit[] (or array of credit)|✔|
|`<Credit>`|Contains the header and the strings for the ending lines|✔|
|`<header>`|Header for ending lines|✔|
|`<People>`|Array of strings for ending lines|✔|
|`<string>`|Ending lines (from 1 to 5 works fine)|✔|

The title and the ending screen are necessary to make the custom level playable. The title will show up only when the game started is Main Babe / Normal Game.

Custom fonts are optional as specified, if left to blank, JumpKingPlus will automatically pick the default ones.

Both MainBabe and MainShoes are supposed to be called as the .xnb files located into `/mods/ending`. **Do not** include the extensions in the name, the game is automatically set to find the .xnb files.

>Inside the Ending Lines, it's possible to use the default library for translations included in the game. LanguageJK includes all the possible text in Jump King based by your localization language. Check out all the possible combinations [**here**](./files/LanguageJK.xml).

### Hitbox file
The hitbox file is a **Texture2D** (.png image with alpha channel or transparent) with the size of 780x585 pixels. Every screen is ordered by column starting from top to bottom which means every screen has 60x45 pixels. Jump King uses a specific color to define what a block is inside of this file.

<table>
  <thead>
    <tr>
      <th>block</th>
      <th>description</th>
      <th>usage</th>
      <th>color</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Solid</td>
      <td>A normal block you can stand on</td>
      <td></td>
      <td><div class="rectangle" style="background:black;"></div></td>
    </tr>
    <tr>
      <td>Slope</td>
      <td>The player will slide standing on it</td>
      <td>Needs two adjacent blocks</td>
      <td><div class="rectangle" style="background:red;"></div></td>
    </tr>
    <tr>
      <td>Fake</td>
      <td>The player will fall through it</td>
      <td>Wind, water and low gravity affects it; used also for slopes</td>
      <td><div class="rectangle" style="background:rgb(128,128,128);"></div></td>
    </tr>
    <tr>
      <td>Ice</td>
      <td>The player will slide on it but can still stand on it</td>
      <td></td>
      <td><div class="rectangle" style="background:rgb(0,255,255);"></div></td>
    </tr>
    <tr>
      <td>Snow</td>
      <td>The player will remain at their position unless trying with another jump</td>
      <td>Snake Ring bypasses it</td>
      <td><div class="rectangle" style="background:rgb(255,255,0);"></div></td>
    </tr>
    <tr>
      <td>Wind</td>
      <td>If placed on a screen, it will slide the player slowly to a direction</td>
      <td>The wind polarity reverses every 5 seconds</td>
      <td><div class="rectangle" style="background:rgb(0,255,0);"></div></td>
    </tr>
    <tr>
      <td>Sand</td>
      <td>The player will slowly fall through the block, while jumping and walking is still possible</td>
      <td></td>
      <td><div class="rectangle" style="background:rgb(255,106,0);"></div></td>
    </tr>
    <tr>
      <td>No Wind</td>
      <td>The player will fall through it</td>
      <td>Wind, water and low gravity does not affect it</td>
      <td><div class="rectangle" style="background:white;"></div></td>
    </tr>
    <tr>
      <td>Water</td>
      <td>Velocity and gravity is halved</td>
      <td></td>
      <td><div class="rectangle" style="background:rgb(0,170,170);"></div></td>
    </tr>
    <tr>
      <td>Quark</td>
      <td>Rounds the player's Y position to make falls less different; reference <b><a href="https://media.discordapp.net/attachments/623779998494490624/782275174916685864/unknown.png">here</a></b></td>
      <td>Used when player is in full velocity</td>
      <td><div class="rectangle" style="background:rgb(182,255,0);"></div></td>
    </tr>
    <tr>
      <td>Teleport</td>
      <td>If placed on a screen, it teleports the player to a specific screen using the <b>RED</b> of the RGB as the screen number</td>
      <td>Works both left and right side of the screen</td>
      <td><div class="rectangle-gradient" style="background-image: linear-gradient(to right, rgb(1,0,255), rgb(255,0,255));"></div></td>
    </tr>
    <tr style="background-color: #fff3b2;">
      <td>Low gravity</td>
      <td>Velocity and gravity is between water and normal, distance is slightly higher (fixed all problems related with solid platforms in v1.3.1)</td>
      <td></td>
      <td><div class="rectangle" style="background:rgb(128,255,255);"></div></td>
    </tr>
    <tr style="background-color: #fff3b2;">
      <td>Wind gradients</td>
      <td>16 values that determinates the intensity of the wind</td>
      <td>From 12.5% (Red: 192) to 200% (Red: 207) of the original wind strength</td>
      <td><div class="rectangle-gradient" style="background-image: linear-gradient(to right, rgb(192,255,0), rgb(207,255,0));"></div></td>
    </tr>
    <tr style="background-color: #fff3b2;">
      <td>One-way wind gradients (LEFT)</td>
      <td>16 values that determinates the intensity of the wind, the wind will never change direction.</td>
      <td>From 12.5% (Red: 208) to 200% (Red: 223) of the original wind strength</td>
      <td><div class="rectangle-gradient" style="background-image: linear-gradient(to right, rgb(208,255,0), rgb(223,255,0));"></div></td>
    </tr>
    <tr style="background-color: #fff3b2;">
      <td>One-way wind gradients (RIGHT)</td>
      <td>16 values that determinates the intensity of the wind, the wind will never change direction.</td>
      <td>From 12.5% (Red: 224) to 200% (Red: 239) of the original wind strength</td>
      <td><div class="rectangle-gradient" style="background-image: linear-gradient(to right, rgb(224,255,0), rgb(239,255,0));"></div></td>
    </tr>
  </tbody>
</table>

#### Compatibility table
<table>
  <thead>
    <tr>
      <th>block</th>
      <th>JK+ v1.1.0 or older</th>
      <th>JK+ v1.2.0 to v1.3.1</th>
      <th>JK+ v1.3.1</th>
      <th>JK+ v1.4.0 or newer</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Solid</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Slope</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Fake</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Ice</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Snow</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Wind</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Sand</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Wind</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>No Wind</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Water</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Quark</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Teleport</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Low gravity</td>
      <td>&cross;</td>
      <td>?</td>
      <td>&check;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>Wind gradients</td>
      <td>&cross;</td>
      <td>&cross;</td>
      <td>&cross;</td>
      <td>&check;</td>
    </tr>
    <tr>
      <td>One-way wind gradients</td>
      <td>&cross;</td>
      <td>&cross;</td>
      <td>&cross;</td>
      <td>&check;</td>
    </tr>
  </tbody>
</table>

### Screens folder
The screen folder contains textures such as background, foreground, midground, scrolling images and masks.

#### Background
The background is usually used for skies or gradients to put back on a certain or multiple screens.
The name of the file should be `bg(SCREEN NUMBER).xnb`, or as an example, `bg1.xnb`.

![BG](https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/background.png)

#### Foreground
The foreground is used for details that are in front of the player, such as vines or grass.
The name of the file should be `fg(SCREEN NUMBER).xnb`, or as an example, `fg1.xnb`.

![FG](https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/foreground.png)

#### Masks
The masks are animated backgrounds that are stored inside the default `particles` folder. Masks can be used to give more depth to the level, some examples of masks are ash, rain and snow. 
The name of the file should be `(MASK NAME)mask(SCREEN NUMBER).xnb`, or as an example `light_snow_bgmask1.xnb`.

![Mask](https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/mask.png)

#### Midground
The midground is usually used for platforms and detail that want to be behind the player (the player can go over them).
The name of the file should be `(SCREEN NUMBER).xnb`, or as an example, `1.xnb`.

![MG](https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/midground.png)

#### Scrolling images

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/scroll.xml"><ion-icon name="code-slash"></ion-icon> Example scroll.xml</a></div>

The scrolling images are managed by an .xml file, that determines their texture, position, velocity and layer mode (see example scroll.xml above). The scrolling texture is usually used for clouds or birds flying in the distance. The texture name should be the same of the namefile. Which means if you created a new scrolling texture called `clouds.xnb` the name of the texture inside the scroll setting file should be `<texture>clouds</texture>`.

![Scrolling](https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/scroll.png)

All of the layers together make this (not counting the hidden wall because that's a prop):

![Example Image](https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/final.jpg)

### Props folder
The props folder contains textures and settings of props used in-game; their categories are: worlditems, textures, messages, hidden walls and hidden walls props. Avoid using props in the final screen to prevent slight visual bugs from the game itself.

#### World items

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/worlditems.xml"><ion-icon name="code-slash"></ion-icon> Example worlditems.xml</a></div>

The world items are items that the player can pick up by walking on them. These have their own texture from the wearable items and they are stored in `props/worlditems`.

The game to position and read their texture reads a configuration file called `worlditems.xml`. The file is self explainatory so there's no need of a table.

#### NPCs
Everything related to NPCs can be found inside `textures/old_man`. NPCs can be of two types: which are `old man` (normal NPC that speaks only) and `merchant` which is an entity that includes the `old man` type but can also sell items. The textures for both needs to be inside `textures/old_man` while the quotes work differently.

old_man_quotes.xml file (located in `textures/old_man/lines`)

|tag|description|
|---|---|
|`<name>`|Name of NPC (LEAVE AS DEFAULT)|
|`<sheet_cells>`|Size of the spritesheet|
|`<X>`|Columns|
|`<Y>`|Rows|
|`<random_count>`|(LEAVE AS DEFAULT)|
|`<position>`|Position inside the screen|
|`<X>`|Position on X axis|
|`<Y>`|Position on Y axis|
|`<home_screen>`|Screen number|
|`<talk_animation>`|Contains frames, triggered when talking|
|`<frames>`|AnimationFrame[]|
|`<AnimationFrame>`|Contains sprite index and duration|
|`<sprite_index>`|Index of sprite from sheet cells|
|`<duration>`|Duration in seconds|
|`<busy_animation>`|Contains frames, triggered when idle|
|`<bubble_format>`|Format regarding text|
|`<direction>`|Left or right|
|`<anchor>`|Contains X and Y|
|`<X>`|Left or right|
|`<Y>`|Up or down|
|`<width>`|Width in pixels|
|`<trigger_box>`|Box where NPC starts speaking if player is inside|
|`<center_x>`|Leave as defualt unless you know what you are doing|
|`<center_y>`|Leave as defualt unless you know what you are doing|
|`<width>`|Width in pixels|
|`<height>`|Height in pixels|
|`<talk_delay>`|Delay of before starting to talk|
|`<talking_speed>`|Speed until new letter reveal (in seconds)|
|`<intro_quote>`|Contains intro quotes or lines|
|`<lines>`|string[]|
|`<string>`|A single quote|
|`<achievements>` and inside tags|Leave as default|
|`<screens>`|OldManScreen[]|
|`<OldManScreen>`|Contains all the information to unlock a new quote|
|`<screen>`|Screen number|
|`<quotes>`|OldManQuote[]|
|`<OldManQuote>`|Contains intro quotes or lines|

> To make this table have more sense, look inside your gamefiles and look for an example (`Jump King/Content/props/textures/old_man/lines/hermit_quotes.xml`), this will clear out more than watching a table.

merchant_quotes.xml file (located in `textures/old_man/merchant`)

|tag|description|
|---|---|
|`<sale_item>`|Item being sold|
|`<currency_type>`|Item that serves for payment|
|`<price_increase>`|Price|
|`<easteregg_amount>`|Easter egg amount (JumpKingPlus Exclusive)|
|`<sale_achievement>`|Leave as default|
|`<sale_lines>`, `<easteregg_lines>`, `<sold_lines>`, `<no_gold_lines>`|OldManQuote[]|
|`<sell_quote>`|Contains lines|
|`<lines>`|string[]|
|`<settings>`|Old Man settings (the table above)|


#### Raven
The raven is the entity related to the bird. It is located inside the `textures/raven` folder. The folder should contain the raver texture and the `(raven name).ravset` (which is a xml file).

|tag|description|
|---|---|
|`<fly_sfx>`|Sound effect that needs to be played when the flight is triggered|
|`<texture>`|Name of the raven (which should be the same name of the file)|
|`<item>`|Items carrying|
|`<positions>`|RavenPosition[]|
|`<RavenPosition>`|Contains the positions of the raven|
|`<screen>`|Screen number|
|`<position>`|Contains X and Y|
|`<X>`|Pretty self-explainatory|
|`<Y>`|Pretty self-explainatory|
|`<treasure>`|Boolean value. If true, the raven is carrying the item|
|`<look_direction>`|Left or right|
|`<fly_direction>`|Left or right|

#### Props

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/prop_settings.xml"><ion-icon name="code-slash"></ion-icon> Example prop_settings.xml</a><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/prop1.xml"><ion-icon name="code-slash"></ion-icon> Example prop.xml</a></div>

The props in-game (such as the bonfire in the first screen) are stored in the `props/textures` and they have one setting file named `prop_settings.xml` which contains:

|name|description|
|---|---|
|`<settings>`|PropSetting[]|
|`<PropSetting>`|Contains settings of a single prop|
|`<name>`|Name of the file|
|`<fps>`|Frames per second|
|`<frames>`|float[]|
|`<float>`|Time per frame|
|`<sheet_cells>`|Size of the spritesheet|
|`<X>`|Columns|
|`<Y>`|Rows|
|`<random_offset>`|Optional tag to get random offsets|

To add a prop on a screen, you will need to create a configuration file called `prop(SCREEN NUMBER).xml` and add each prop with their type (name of the prop), position on X and Y axis (__0,0 is top-left!__) and optional if the prop should be flipped.

#### Hidden walls

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/hidden_wall.xml"><ion-icon name="code-slash"></ion-icon> Example hidden_wall.xml</a><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/prop.xml"><ion-icon name="code-slash"></ion-icon> Example prop.xml</a></div>

Hidden walls are used in-game to hide areas or make the screen more realistic, the hidden wall works as foreground until the player gets into its position where it gets transparent.

The hidden walls are located in `props/hidden_walls/textures` and they are managed by a configuration file called `hidden_wall(SCREEN NUMBER).xml`.

Hidden walls can have props too; these can be added creating a different prop configuration file inside `props/hidden walls props` called `prop(SCREEN NUMBER).xml`.

### King folder
The king folder contains the textures of the wearable items by the player, by changing these you will have a different texture for the item only when the custom mode is triggered. Keep the same item name in order to get it working.

### Gui folder

#### Locations

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/location_settings.xml"><ion-icon name="code-slash"></ion-icon> Example location_settings.xml</a></div>

The locations in-game can be changed using the `gui/location_settings.xml` file.

|tag|description|
|---|---|
|`<locations>`|Location[] or array of locations|
|`<Location>`|Location information|
|`<start>`|Screen number where location starts|
|`<end>`|Screen number where location ends|
|`<unlock>`|Screen number where location name pops up|
|`<name>`|Location name|

#### Earthquake effect

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/earthquake_settings.xml"><ion-icon name="code-slash"></ion-icon> Example earthquake_settings.xml</a></div>

Implemented from <span class="badge-pill">v1.4.0</span>, this permits to disable/enable the earthquake effect used by Jump King in correspondence of the towers. This is effect consists into moving the screen left and right by one pixel.

The earthquake effect can be changed using the `gui/earthquake_settings.xml` file.

By default there's only one screen set to 0, so it will never trigger. In case you want to use it, you will need to name every screen number with:
```xml
<int>SCREEN_NUMBER</int>
```

### Font folder
The font folder should include the custom fonts included for the custom level. Sadly MonoGame, and so Jump King, does not support TrueType fonts (.TTF) so to make them compatible in-game, you should check out how to convert the font to make it compatibile below [**here**](#convert-all-vs2019monogame). 

### Audio folder
The audio folder should contain all the possible sound related content such as: background (ambiental music or music of a specific zone), music (ending songs) and event effects sounds.

#### Ambient as background
The ambient music should be placed inside `audio/background` as an .xnb file. To add this to a specific zone, simply edit the `audio/background/data/values.xml` and add on the AmbienceSave section like so:
```xml 
<sections>
  <AmbienceSave>
    <ambience>
      <Ambience>
        <name>Water</name>
        <volume>0.7</volume>
      </Ambience>
      <!-- more Ambience -->
    </ambience>
  </AmbienceSave>
  <!-- more AmbienceSaves -->

  <screens>5</screens>
</sections>
```


#### values.xml file

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/values.xml"><ion-icon name="code-slash"></ion-icon> Example values.xml</a></div>

|tag|description|
|---|---|
|`<special_info>`|AmbienceInfo[]|
|`<AmbienceInfo>`|Contains all the information about a music piece|
|`<name>`|Name of the music file|
|`<type>`|Should be always `Music`|
|`<restart>`|Boolean value. If true, the song will be looped|
|`<fade_out_length>`|Fade out length in seconds|
|`<fade_in_length>`|Fade in length in seconds|
|`<sections>`|AmbienceSave[]|
|`<AmbienceSave>`|Contains a section with sounds|
|`<ambience>`|Ambience[]|
|`<Ambience>`|Contains name and volume of a sounds|
|`<name>`|Name of the file|
|`<volume>`|Volume from 0 to 1 (basically 0-100%)|
|`<screens>`|Amount of screens for sections|

__WARNING:__ The `<screens>` tag doesnt work with the name logic of the screen number. This is precisely made to avoid mixmatches.
From the first `<AmbienceSave>` it keeps the `<screens>` number counting. <br>So if you have two AmbienceSaves where the first one has 5 screens and the second has 2, you would have done already 7 screens of music.

#### Music as background
Following the name concept of the above, this shares same folder but has to be configurated differently. In the `values.xml` file mentioned above, this needs to be configured as an AmbienceInfo as well.

```xml 
<special_info>
  <AmbienceInfo>
    <name>TheBogTwo</name>
    <type>Music</type>
    <restart>true</restart>
  </AmbienceInfo>
  <!-- more AmbienceInfos -->
</special_info>

<sections>
  <AmbienceSave>
    <ambience>
      <Ambience>
        <name>TheBogTwo</name>
        <volume>0.85</volume>
      </Ambience>
      <!-- more Ambience -->
    </ambience>
  </AmbienceSave>
  <!-- more AmbienceSaves -->

  <screens>5</screens>
</sections>
```

#### Music
The music contains many other files that can be changed such as:
- Main babe ending song (optional)
- Menu intro (optional)

And event music which is a subfolder which contains music that can be triggered, such as the sound on the last babe screen or the gargoyles. There is a very easy configuration file (`audio/music/event_music/events.xml`) that does not need any explaination.

**Post Scriptum:** This folder has been cut to contain custom levels' size, since the audio folder takes up 80% of the size.


### Particles folder

<div class="ws-buttons"><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/weather.xml"><ion-icon name="code-slash"></ion-icon> Example weather.xml</a><a class="ws-button" href="https://raw.githubusercontent.com/Phoenixx19/JumpKingPlus/master/docs/workshop/files/snow_settings.xml"><ion-icon name="code-slash"></ion-icon> Example snow_settings.xml</a></div>

The particles folder should include two .xml configuration file which are:
- snow_settings.xml (which sets the snow)
- weather.xml (which sets the weather)

#### Weather 

|tag|description|
|---|---|
|`<weathers>`|Weather[]|
|`<Weather>`|Contains name of the weather, fps and screens it is in|
|`<name>`|Name of the weather (leave as default)|
|`<fps>`|Frames per second|
|`<screens>`|int[]|
|`<int>`|Screen number|

By setting the weather to a specific screen number, that screen also can use masks to crop the particles at will.

#### Snow settings
This needs to be configured, if the snow particle is used.

---

## Publishing
To get it published on the site, post your map in the [#modding](http://discord.gg/QhnERYV) channel on Discord where it will get verified by one the level publisher moderators.

The .zip file should contain your mods folder and only the files needed for the level custom. Please host the level yourself, GitHub does not work as a cloud!

<br>
Special thanks to MERNY!<br>
~Phoenixx19, 2020