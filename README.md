# Building System - By Georgi Aleksandrov

Building System is a project that is meant to showcase my ability to work on games. This Project in particular focuses on creating a system that builds 
constructions with the use of resources and place them on pre-defined slots.

## How to test the project

This is a Unity URP project.

The project was made using Unity 2023.2.10f1. 
This is the preferred version to run this project in, however it should work with any newer versions as well. 
However this cannot be guaranteed.

Open up the project using the Unity specified above and the scene is located in: Assets\Scenes\Game.unity

To test the project as it is setup just press "Play".

### Controls

Hold Right mouse button -> Enables camera movement
Release Right mouse button -> Disables camera movement

Hold Right mouse button + Mouse movement -> Look around

Hold Right mouse button + WASD -> Fly camera
Hold Right mouse button + Left Shift -> Sprint (Fly faster)

To Add Resources Add resource from the chosen type by pressing the corresponding button on the top left of the screen.
To change amount added by navigating to -> Player/ PlayerResources component / Resource Stats / Corresponding Resource / Amount To Add Per Button Click

Hover over Brown building slot + Left Click -> Focus Building Slot
Left side panel allows the selection of slots by clicking on the relevant button

When Focused on a Building slot:

On the right a panel will slide in view that will show the available building/upgrade options
The panel shows branching path if there is more than one upgrade option

On the bottom of the right panel there are downgrade and destroy buttons:
Downgrade brings the house to last house (Does not refund resources)
Destroy clears the slot (Does not refund resources)

## How to setup a Scene

To setup a new scene Add the following prefabs:

Assets / Prefabs / Controller / Player.prefab

Assets / Prefabs / UI / Canvas.prefab

Assets / Building Slot / Building Slot Manager.prefab

Assets / Building Slot / Building Slot.prefab

### ATTENTION!

When adding the Building Slot Manager prefab (Assets / Building Slot / Building Slot Manager.prefab) make sure that it is at 
location X = 0, Y = 0, Z = 0 and rotation X = 0, Y = 0, Z = 0 and scale X = 1, Y = 1, Z = 1.

When adding the Building Slot prefab (Assets / Building Slot / Building Slot.prefab) make sure that it is under the Building slot manager

## How to edit HouseUpgradeInfo

Navigate to Assets / ScriptableObjects / HouseUpgradeInfo / <"Desired Scriptable Object You want to change">

The Scriptable Objects Contain:

Building Name -> The building name
House Prefab -> The building prefab to spawn
Wood Cost -> The Wood required for building
Stone Cost -> The Stone required for building
Metal Cost -> The Metal required for building

NextHouses (List) -> Any "HouseUpgradeInfo" placed here will be shown as upgrades to this house

### ATTENTION!
The Default HouseUpgradeInfo does not require anything else other than HouseUpgradeInfos inside of NextHouses

## Extra Features

Branding upgrade paths for buildings

Downgrade functionality to reverse the upgrade

Automatic Scrollable Panels UI (Left and Right) that is filled depending the requirements of the system

## Planned Features

Making HouseUpgradeInfo.cs to inherit a parent script. This will allot the Default HouseUpgradeInfo to only contain the NextHouses List.
This will remove the not essential fields from inside the Default HouseUpgradeInfo SO.

Buildings will generate resources (Depending on the building).

## Known Issues

When you press right click and Maximize the Game window inside Unity the mouse does not hide when you try to press Right Click and fly around with the camera.

If Building Slot prefab is not under a Building Slot Manager the Left Focusing Menu will to get a button corresponding to the Building Slot. (Made this way for performance reasons)

## Used Packages

PBR medieval houses pack : https://assetstore.unity.com/packages/3d/environments/fantasy/pbr-medieval-houses-pack-71546

SimplePoly City - Low Poly Assets : https://assetstore.unity.com/packages/3d/environments/simplepoly-city-low-poly-assets-58899

