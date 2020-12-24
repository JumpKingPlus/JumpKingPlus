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
        display:block;
        width:20px;
        height:20px;
    }
</style>

Welcome to the documentation for custom levels on Jump King using JumpKingPlus! On your left you can find the table of contents with everything you should need to make a custom level.

## Installation
Custom levels are available only using __JumpKingPlus on [v1.2.0](https://github.com/Phoenixx19/JumpKingPlus/releases/tag/v1.2.0) or above__.

### Requirements for custom levels
- A simple pixel art editor (Aseprite or GraphicsGale)
- A good image editor for editing and exporting hitboxes (GIMP or Adobe Photoshop)
- [XNBCLI]() for converting images into XNB
- Visual Studio 2019 (or above) using MonoGame for converting audio and music, project file [**here**]().

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

|block|description|usage|color|rgb|
|---|---|---|---|---|
|Solid|A normal block you can stand on|| <div class="rectangle" style="background:black;"></div> |(0,0,0)|
|Slope|You will slide standing on it|needs two adjacent blocks|<div class="rectangle" style="background:red;"></div>|(255,0,0)|
|Fake|You will fall through it|wind affect it|<div class="rectangle" style="background:rgb(128,128,128);"></div>|(128,128,128)|
||||||
||||||
||||||
||||||
||||||
||||||
||||||
||||||
||||||


---

## Testing
