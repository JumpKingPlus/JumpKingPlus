---
title: Documentation
layout: page
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

## Installation
Custom levels are available only using __JumpKingPlus on [v1.2.0](https://github.com/Phoenixx19/JumpKingPlus/releases/tag/v1.2.0) or above__.

## Requirements for custom levels
- A simple pixel art editor (Aseprite or GraphicsGale)
- A good image editor for editing and exporting hitboxes (GIMP or Adobe Photoshop)
- [XNBCLI](https://github.com/LeonBlade/xnbcli/releases/latest) for converting images into XNB
- Visual Studio 2019 (or above) using MonoGame for converting audio and music, project file [**here**]().

### Convert images into XNB and viceversa
0. Install prerequisites of XNBCLI available [here](https://github.com/LeonBlade/xnbcli/blob/master/README.md).
1. Download the latest release for XNBCLI in the links above.
2. Export the `xnbcli-windows-x64.zip` file

#### Unpack images
If you want to unpack an image from the game, put the file inside the `packed` folder and open the `unpack.bat`. If succeeded, you will find your files inside the `unpacked` folder.

#### Pack images
If you want to pack an image to put on the mod, make sure you have the .json file of your file ready to get packed with your image.

If you never unpacked an image you can use this simple .json and modify for your own use!

<span style="color: grey; font-size: small; font-weight:600;">YOURFILENAMEHERE.json</span>
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

### Convert music into XNB and viceversa
Not yet.

---

## Modding
After installing and downloading all the files needed; you can start working on your first custom level. In order to make the custom level working you will need to create two files inside your `JumpKing/Contents/mods` folder. JumpKingPlus loads the custom mode when both the `level.xnb` and the `mod.xml` files are in the folder above.

### `mod.xml` file
[__Blank mod.xml file__]()

In this file, you will set up the basics information of your level such as:

|name|about|optional|
|---|---|---|
|`<About>`|Contains the fundamentals of the mod|✖|
|`<title>`|Title of the custom level (will show up in the Stats Display window)|✖|
|`<ending_screen>`|Screen where the babe will spawn|✖|
|`<Fonts>`|Array of available fonts (MenuFont, MenuFontSmall, StyleFont, OptimusUnderline, Tangerine, LocationFont, GargoyleFont)|✔|
|`<Ending>`|Contains the babe ending images, only one story is available for now|✖|
|`<MainBabe>`|Screen for beating the custom game|✖|
|`<MainShoes>`|Screen for beating the custom game with the Giant Boots|✖|
|`<EndingLines>`|Credit[] (or array of credit)|✔|
|`<Credit>`|Contains the header and the strings for the ending lines|✔|
|`<header>`|Header for ending lines|✔|
|`<People>`|Array of strings for ending lines|✔|
|`<string>`|Ending lines (from 1 to 5 work fine)|✔|

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
      <td>Wind, water and low gravity affects it</td>
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
      <td>Velocity and gravity is between water and normal, distance is slightly higher</td>
      <td></td>
      <td><div class="rectangle" style="background:rgb(128,255,255);"></div></td>
    </tr>
  </tbody>
</table>
The yellowish color defines a custom hitbox added with JumpKingPlus.


---

## Testing
