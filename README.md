# 50.033 Game Design Lab 5 Handout

---

<center>
by Li Yuxuan 1003607
<h3>
<a href="https://github.com/xmliszt/mario-final">GitHub Repo</a>
</h3>
<h3>
<a href="https://youtu.be/23gv1VbcH0Y">Gameplay Video</a>
</h3>
</center>

---

[TOC]

## Game Design

- Title: **Mario Final**
- Platformer
- A re-creation of Mario classic with 2 levels with high difficulty. Mario can collect powerup mushrooms and consume them to gain powerup.
- Concept: Player uses keyboard to control Mario's movement to move left or right or jump or use powerup collected. Mario needs to go through 2 difficult level one above the ground and one underground in order to reach the castle in the end to meet the princess, and live happily ever after :D

![](https://i.imgur.com/ZhYbDR2.png)

- Special game objects

| Game Object | Description |
| -------- | -------- |
| ![](https://i.imgur.com/w5EUBn4.png)  | Mario, the main character that the player controls|
| ![](https://i.imgur.com/fmB0Frr.png)  | Inventory slots, collected powerups will be shown here, and a description below about the first item is shown. Player press "E" to use it|
| ![](https://i.imgur.com/0g6U5Ni.png) | Golden Mushroom Booster: give invincibility for 5 seconds |
| ![](https://i.imgur.com/cpexv9I.png) | Jumper Mushroom Booster: give jump boost for 5 seconds |
| ![](https://i.imgur.com/5jfeW3j.png) | Speed Mushroom Booster: give speed boost for 5 seconds | 
| ![](https://i.imgur.com/CTcdlvm.png) | Coin: can be collected to add to score | 
| ![](https://i.imgur.com/GpQjR7v.png)| Gomba: touch it from anywhere other than the top will kill Mario. But can step on top to kill Gomba| 
| ![](https://i.imgur.com/X5QfrlH.png) | Firepipe: shoot up deadly fireball at interval, avoid fireball at all cost, unless Mario is invincible|
| ![](https://i.imgur.com/HDgQvq1.png) | Lava: anything touch it will just vanish, invincible Mario is no exception! |

## Features

### Two Levels

There are two levels in this game. The level is conveniently drawn by using **Tilemap**.

![](https://i.imgur.com/NaBE92I.jpg)

**Level 1: Above the Ground**

![](https://i.imgur.com/hZ3lqJ5.jpg)


**Level 2: Under the Ground**

![](https://i.imgur.com/yNorh64.jpg)


**Ending Level: Meet Princess**

![](https://i.imgur.com/OchFWGI.jpg)


### UI Screens (Start, Win, Gameover)

![](https://i.imgur.com/eG6QW6l.jpg)

![](https://i.imgur.com/Sarggsz.jpg)

![](https://i.imgur.com/ptZJBKO.jpg)

### Script Organization

All scripts are organized in respective folders. There are many custom event listeners and events, and different managers scripts so I organized them properly.

![](https://i.imgur.com/4q6uBfB.png)

### Custom Events

This game is developed based on the Scriptable Object Event Systems Architecture. These are the following events created and used in the game:

![](https://i.imgur.com/IQpakc3.png)

There are many gameobjects that are subscribing to the events above to be able to communicate with each other. Here is an example:

The playerController script raise some events, for example `OnPlayerTurnInvincible`

![](https://i.imgur.com/4DldeZs.png)

Corresponding Gomba script has event listener that gets triggered, and change the bahaviour of Gomba (Gomba will get squashed even when the Mario approaches from any direction). I also modify the script in the lab such that a basic event listener is able to register **multiple different events altogether**, as shown below in the Gomba script where the Gomba listen to both `OnPlyaerTurnInvincible` and `OnPlayerTurnOffInvincible`

![](https://i.imgur.com/l0JeSfU.png)


### Game Constants

I used a scriptable object as game constants and use `Header` to organize the configuration fields properly:

![](https://i.imgur.com/o0vQ8ia.png)


### Custom Variable Scriptable Objects

I created custom `BoolVar`, `FloatVar`, `IntVar` variables as scriptable objects so that some of the variables can be references by other gameobjects without hard references:

![](https://i.imgur.com/SPKBVUe.png)


### Prefabs

A lot of the game elements are turned into prefabs so it is very easy to construct another level. With the current setting, constructing one more level will only take a few minutes!

![](https://i.imgur.com/B1bm3vw.png)

Below are the created scriptable objects variables:

![](https://i.imgur.com/057dR5t.png)

By doing so, it is very easy to change, reset them in the game.

### Scene Transition

![](https://i.imgur.com/3uBBOnV.png)

I added a black-circle screen transition. If you play the game you will see the transition at the start of the game or at any level transition.

### Inventory System

The inventory system uses a scriptable object `Inventory` that keeps track of the boosters that the player collected or used. 

![](https://i.imgur.com/x5UwRbq.png)

**Adding** or **Using** an item in the inventory is done by raising custom event that has a booster as an argument. Three different boosters are created as scriptable objects:

![](https://i.imgur.com/ikQiBCs.png)

Here is a snapshot of an inventory manager script:

![](https://i.imgur.com/QlfCLGA.png)

And here is a snapshot of the inventory UI script that controls the inventory UI displayed

![](https://i.imgur.com/yYxk7nK.png)


