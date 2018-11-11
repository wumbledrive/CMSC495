# Valhalla’s Finest
### CMSC 495 | Team 5
##### Team Members:  
Andres Giraldo, Jesse Nelson Nicholas Troyer, Roger Manga, Samuel Hoffman, & Sean Donovan.


### Table of Contents

##### User Guide

* [Controls](#controls)
* [Player UI](#playerui)
* [Additional Player UI & Settings](#additionalplayeruisettings)
* [Sound FX and Background Music Checklist](#soundeffectsbackgroundmusicchecklist)
* [Animations Checklist](#animationschecklist)
* [Game Mechanics/Weapons](#gamemechanicsweapons)
* [On Launch/Home UI](#launchhomeui)
* [Start New/Load Game UI](#startnewloadgameuserinterface)
* [Opening Tutorial (Alpha)](#openingtutorial)
* [Enter Valhalla](#entervalhalla)
* [Generic Level Breakdown](#genericlevelbreakdown)
* [First Level Draft - Trouble in Niflheim](#troubleinniflheim)
* [Map](#map)

##### Test Plan

* [Introduction](#introduction)
* [Approach](#approach)
* [Responsibilities](#responsibilities)
* [Testing Criteria](#testingcriteria)
* [Testing Environment](#testingenvironment)
* [Test Deliverables](#testdeliverables)
* [Sample Test Cases](#sampletestcases)
  
  ---
  
## User Guide
  
#### Notes
|Key |Description |
|---|---|
|`Gray Text` |Items in blue appear as stretch goals. Images in this document are not part of final product. They are only being used as placeholders to envision our product goal.|
|*Italics Text* | Action items that team will develop further later.|
|Images| All images are screenshots taken from the Roll20.net platform.

### <a name="controls">Controls</a> 
|Key |Description |
|---|---|
|**Movement** | WASD Keys; Basic running/walking animations; sounds for footsteps  
|**Mouse** | Aim player direction, navigate menus  
|**Mouse Left Click** | Attack, Confirm; Animations/SoundFX for attacks with various weapons; Appropriate sound effects for hit, miss, blocked attacks, etc.
|``Mouse Right Click``| ``Block; Blocking animations with different shields; Sound effects for blocked attacks``|
|``Space`` | ``Dodge Roll; Dodging animation; Particle and sound effects for dodges``
|**E** | Interact
|**Escape** | Player Menu; Different designs for each interface; sound effects for menu selections

### <a name="playerui">Player UI</a>
|Key |Description |
|---|---|
| Hearts | Represents health (Player starts with 4 hearts); Sound effects for low health
|``Magic/Energy``| ``Tied to abilities given by weapons``
|``Shields``| ``Represents additional armor``

### <a name="additionalplayeruisettings">Additional Player UI & Settings</a>
##### Inventory Equip Screen
* Weapons/Magic Items (Allow player to select, equip, and delete items)
##### Settings Screen
* Save Game
* Exit Game
* ``Change Screen Size Settings``
* ``Audio Settings``

### <a name="soundeffectsbackgroundmusicchecklist">Sound Effects & Background Music Checklist</a>
##### Menu/Settings/Tutorial Text:
* Button click/Selection
##### Background Music:
* Launch Screens
* Game Zones/Levels/Maps (I.E. Music changing when moving from tutorial Zones to Valhalla Hall)
* Boss/Important NPC (I.E Music changing when encountering a specific Boss/NPC)
* Congratulations Music (when a character has finished a Quest or the Game)
##### Player SoundFX
* Movement
* Weapon(s)/Magic Attacks (Specific sounds when using different attacks)
* Losing Health/Near Death
* Gaining Health
* Picking up an Item
##### NPC (non-player character) FX
* Movement
* Weapon(s)/Magic Attacks (Specific sounds when using different attacks)
* Losing Health/Near Death
* Gaining Health

### <a name="animationschecklist">Animations Checklist</a>
##### Home UI
* ``Menu Background Animations``
##### Game Zones/Levels/Objects
* Doors Opening/Closing
* Chests Opening/Closing
* Glowing Lights
* Game Zones/Level Transitions
##### Player Animations
* Movement
* Interaction
* Weapon(s)/Magic Attacks
* Healing
* Picking up an item
* Losing Health/Near Death
##### Player UI Animations
* Losing/Gaining Health
* Losing/Gaining Magical Power
##### NPC
* Movement
* Interaction
* Weapon(s)/Magic Attacks/Taunts
* Boss fight special animations
* Healing
* Picking up an item

### <a name="gamemechanicsweapons">Game Mechanics/Weapons</a>
* Sword - Slashes in front of character
* Shield - Blocks projectiles
* Crossbow - Shoots projectile
* Fire Wand - Uses magic resource, shoots projectile.
* Lesser Hammer of Thor - Shoots lightning, and attacks in front of character

### <a name="launchhomeui">On Launch/Home UI</a>

1.  Open Launch file.
2.  Game opens in window/full screen.
3.  Game title appears in the center of the screen with labelled Start button below, Background Music plays.
4.  Click Start or press Enter to go to the **Start New**/**Load Game** interface.
5.  ``Settings button appears under Start button. Clicking Settings button or Pressing ESC key will open a prompt which will allow user to change screen size settings.``

### <a name="startnewloadgameuserinterface">Start New/Load Game User Interface</a>

1.  After the Start button is clicked on the main menu, the **Start New**/**Load Game** buttons appear, and the background music plays.
2.  The **Load Game** menu contains a list of saved game file names and buttons labelled New Game and Continue Game.
3.  Clicking New Game starts the **Opening Tutorial**.
4.  Selecting a saved game file, and then clicking Continue Game loads the saved game file.
5.  On selection of files and button click

### <a name="openingtutorial">Opening Tutorial (Alpha)</a>

(*Storyline chosen during Alpha development*)

**Storyline A**: Our player is being attacked by assassins in room/home.
**Storyline B**: Our player is on the field of battle fighting various opponents.

1. After clicking New Game, the Opening Tutorial begins and the Background Music plays.
2. Player character appears in center of screen in a sandbox level with NPC’s around.
3. Tutorial text appears directing player on the following:
	* ``Give your character a name: Enter Player Name.``
	* Movement: WASD keys and switching direction with Mouse.
	* Interact with friendly NPCs (non-player characters): Go to an NPC and click E.
	* Pick up weapons/items: Move to a weapon/item and click E.
	* Open Player Settings: Press ESC and review how to save game, look at inventory, eat/drink food/potions and equip weapons. (Will make sure to equip weapon before player can continue).
4. After the player equips a weapon an enemy NPC appears. Tutorial text appears instructing the player to do the following:
	* Attack the NPC: Move towards the NPC and Left-Click on Mouse. Weapon should reach out towards enemy.
5. After the player defeats an enemy, two more enemies appear out of the shadows and attack the player (This scenario is supposed to eventually kill the player.) Hearts in Player UI begin to lose color. Tutorial text appears explaining player health.
6. Player is shown dead having been defeated by enemies.
7. Screen goes to white but leaving player body in the middle of the screen still visible. Two Valkyrie NPC’s move quickly toward the player and carry the Players Soul off screen. End Tutorial.

### <a name="entervalhalla"> Enter Valhalla</a>

1.  After the end of the Tutorial the Player wakes up in a room with a bed and a door. Tutorial text appears welcoming and directing the player to leave the room by moving through the door.
2.  The door opens to Valhalla Hall. Valhalla Hall is a large room with friendly NPC’s moving, standing, fighting, and eating. Player can interact with NPC’s to acquire some gear/food.
3.  In the upper corner of Valhalla Hall are two Valkyrie NPCs standing in front of a door. Interacting with the Valkyries tells the player why they were brought to Valhalla, and triggers Odin’s entrance.
4.  Odin makes a grand entrance and the Valkyries move accordingly. Odin approaches and talks to the player. Odin states he heard of the players reputation on earth and is glad he is here etc etc.
5.  Odin asks the player if he could do a small quest for him while he is here. Player auto accepts.
6.  Odin gives player quest to go to the Northwest of Asgard and to take a portal to Niflheim, suspecting that the Ice Giants are up to something.
7.  It is also explained that if the player dies they will resurrect in their bed in Valhalla, Odin then kills the player.
8.  When the player returns to Odin, the player is gifted with a Sword and Shield, and allowed to exit Valhalla Hall to make the journey to the portal. (refer to map)

### <a name="genericlevelbreakdown"> Generic Level Breakdown</a>

1.  Odin asks Player to investigate X by entering portal located in the Y part of the map.
2.  Player journeys through open world to Y part of the map and takes portal to X.
3.  Player fights/interacts enemy NPCs towards the Boss Fight.
4.  Boss is found interacting with Mysterious NPC giving clues about plans to overthrow Odin.
5.  Mysterious NPC runs away, Boss engages player in Boss Fight.
6.  Boss fight challenges player to figure out best method to defeat Boss.
7.  Player defeats Boss, gains access to more clues and other items.
8.  Valkyries give portal back to Asgard to player.
9.  Player returns to Odin and reports.

### <a name="troubleinniflheim"> First Level Draft - Trouble in Niflheim</a>
1.  Player exits Valhalla Hall and moves Northwest.
2.  ``Encounters with friendly/enemy NPCs during journey.``
3.  Arrives at Niflheim Portal, Guarded by Valkyrie.
4.  Valkyrie NPCs, stop player and communicate the dangers that exist in Niflheim, may suggest player save game.
5.  Player can then move and enter Niflheim Portal.
6.  Niflheim map is designed so that activity (fighting/interacting NPCs) appears toward the eventual map NPC Boss. So, as long as the player continues to search for activity then will move closer to the Boss fight.
7.  Niflheim’s ice themed NPCs attack the player as the player explores the Niflheim map (some are melee, some are ranged).
8.  Player encounters Niflheim Boss, Jotnar the Ice Giant King, talking with another mysterious NPC.
9.  The Niflheim Boss agrees with the mysterious NPC to, “Rally his Ice Giant Army to destroy Odin”, and then notices the Player listening.
10.  The mysterious figure runs away, and the Ice Giant states, “It matters not that you were listening, for you will be smashed by me, Jotnar the Ice Giant King!”
11.  Boss fight begins. Jotnar’s hearts appear on screen. Jotnar uses timed attacks against the player, I.E spinning in a whirlwind and then taking a rest. The player cannot damage Jotnar while he is spinning, and must wait until he is resting to attack. ``Jotnar can be given an additional ice based attack.``
12.  After Jotnar is slain, he drops a loot bag/items. Amongst these items is a letter between Jotnar and an NPC known as “M”.
13.  Portal Appears with Valkyrie that takes Player back to Valhalla/Asgard.
14.  Player returns to Odin and updates him with the letter and information about the encounter in Niflheim.

### <a name="map"> Mapa</a>

|Map Item | Description|
|---|---|
|Yellow Portal (Fire)| Transport character to each Game Zone/Level
|Red Castle|Valhalla Hall|
|Houses| Residents of Asgard |
|Green Trees | Trees|

---

## Test Plan

### <a name="introduction">Introduction</a>
The purpose of this documentation is to define the perimeters and metrics in which Valhalla’s Finest will be tested. This documentation will clearly define the roles and responsibilities that each team member will acquire as well as the manner in which the test will be conducted. With the publication of this documentation, we will ensure that testing will be conducted in a uniform, efficient, and precise manner. This will ensure that the player will receive the best gaming experience and that no critical fault will occur.

### <a name="approach"> Approach</a>
Testing for Valhalla’s Finest will be conducted in three phases. These phases are subject to change from the Lead Designer or the Project Manager.

* **Phase 1**: Test Cases will be identified by the Test Lead. The Test Lead will document the test cases and assign it to a tester. Once he has assigned all test cases to testers, the Test Lead will proceed his test team to phase 2.

* **Phase 2**: During this phase, all test cases will be tested against with all results being documented. If there are any failures, the Test Lead will have an addition tester test that test case and confirm. Once all testing has concluded the Test Lead will transition his team to phase 3.

* **Phase 3**: During this phase the Test Lead, with the assistance of the testers, will draft a final test report. The final test document will outline all the results from each test case. Additionally, any road block or issues that arose will be annotated in the final test report. Once the report is finalized, it will be passed over to the Lead Designer and Project Manager. This will conclude the testing cycle.

* **Phase 4 (*Optional*)**: If there are any changes to the program, testing will need to be conducted again. In which case phase 1 – 3 will be followed.

### <a name="responsibilities">Responsibilities </a>

Roles and responsibilities are the following:
* Project Manager – Roger Manga
* Lead Designer – Sean Donovan
* Test Lead - Andres Giraldo
* Tester - Jesse Nelson
* Tester - Nicholas Troyer
* Tester - Samuel Hoffman

The Test Lead will identify which tester will be assigned to specific test cases in order to properly manage the test results. 

If desired, the Test Lead can have multiple testers conduct independent tests of the same test case in order to ensure testing outcome. 

Once the testing phase has begun, no modifications will be done to the program until testing has concluded. 

At that time the Test Lead will report to the Lead Designer his finding from the test. 

Additional testing for a specific test case can be identified by the Lead Designer or the Project Manager.

### <a name="testingcriteria">Testing Criteria</a>

For the duration of the testing on our program, each test case will be tested and given one of three grading classifications:

**Pass** – This will be given if the test case meets or exceeds the expected outcome.

**Fail** – This will be given if the test case does not perform desired actions. Results can come from no action being performed or a critical failure to the overall program.

**Warning** – This will be given if the test case performed the desired action but an undesired effect also occurred.

### <a name="testingenvironment">Testing Environment</a>

For the purpose of testing this program, the following environmental perimeters have been configured:
```
Operating System: Windows
Hardware: At least 2 GB RAM, 2.5 GHz processor
Supporting Software: Visual Studio C++
```
If this program is ran in an environment not similar to that of testing, results can not be guaranteed. For the best playing experience, mirroring the testing environment is ideal. If for some reason the testing environment becomes unusable, testing will be paused and the environment will be rebuilt to the prescribed specification. If testing is paused, only the Test Lead can resume testing with the current test case being re-tested.

### <a name="testdeliverables">Test Deliverables

| Deliverable| Description|
| -------------------- |:-------------:|
| Test Plan| This document will ensure that testing is done in a repeatable and efficient manner.|
| Character Test Cases |Cases that will test the functionality and interaction with characters throughout the game.|
| UI Test Cases| Cases that will test the users experience and interaction with the game.|
|Environment Test Cases|Cases that will test environment boundaries and inaction.|
|Gameplay Test Cases|Cases that will test game play and progression throughout the game.|
|Edge Cases|Cases that have been identified as areas of interest.|
|Final Test Report|Report summarizing all testing that has been done to include documented failures.|

### <a name="introduction"> Sample Test Cases
</a>

### Character Test Cases
|**Test Cases**| **Description** | **Pass/Fail**|
|----|----|----|
|Movement | WASD Keys| |
|Mouse| Aim player direction; Navigate menus| |
|Mouse| Left Click| | 
|Attack, Confirmation | Animations/SoundFX for attacks with various weapons for hit, miss, blocked attacks| |
|Mouse | Right Click | |  
| Block| Blocking animations and sound effects for blocked attacks with different shields | |
| Space| Dodge Roll | |  
| Dodging Animation| Particle and sound effects for dodges | |
| E | Interact | |
| Escape | Player Menu | |
| Control Stress Test | (Multiple Control Inputs pressed at the same time, attempt to trigger animations that will have conflict with each other)||

### UI Test Cases

|**Test Cases**| **Description** | **Pass/Fail**|
|----|----|----|
|Home UI| Appears on game start| |
|Home UI| Start button/text| | 
|Home UI| Background animations| |
|Home UI| Sound effects| |
|Start New Button | Starts new game from "State 0"
|Load Game Button| "Select Saved Game File" list appears|
|Select Saved Game File| Continue Game and New Game buttons work as intended.||
|Select Saved Game File|Background Animations/SoundFX.|||
|Player Menu| Settings List||
|Player Menu| Save Game||
|Player Menu| Inventory||
|Player Menu| Exit Game
|Settings Menu| Audio||
|Settings Menu| Screen Size
|Save Game Prompt|Appears when saving game|
| Player Inventory|Shows inventory items with quantity accurately
| Player Inventory| Indicator for Equipped Weapons/Items.
|Tutorial Text/NPC Text Boxes|Interactive text boxes.
|Player Status UI| Current Health (Healths), Magic/Energy, Shields

### Environment Test Cases
|**Test Cases**| **Description** | **Pass/Fail**|
|----|----|----|
|Tutorial Map| All assets appear (NPCs, houses, crates, tables etc)|||
|Tutorial Map| Player can move through environment space (and not through NPCs, houses, crates, tables etc)
|Tutorial Map| Entrances/Exits/Portals that transition from Map to Map work as intended. 
|Tutorial Map| Background Sound
|Valhalla Hall Map|All assets appear (NPCs, houses, crates, tables etc)
|Valhalla Hall Map| Player can move through environment space (and not through NPCs, houses, crates, tables etc)
|Valhalla Hall Map|Entrances/Exits/Portals that transition from Map to Map work as intended. 
|Valhalla Hall |Background Sound.
|Asgard Open World Map| All assets appear (NPCs, houses, crates, tables etc)
|Asgard Open World Map| Player can move through environment space (and not through NPCs, houses, crates, tables etc).
|Asgard Open World Map| Entrances/Exits/Portals that transition from Map to Map work as intended
|Asgard Open World Map| Background Sound
|1st Level| All assets appear (NPCs, houses, crates, tables etc) 
|1st Level|Player can move through environment space (and not through NPCs, houses, crates, tables etc).
|1st Level|Entrances/Exits/Portals that transition from Map to Map work as intended.
|1st Level|Background Sound

### Gameplay Test Cases

|**Test Cases**| **Description** | **Pass/Fail**|
|----|----|----|
|Storyline Speed Run| Check if storyline crashes on a linear play through.
|Tutorial| Interactions with NPCs, enemy NPCs take damage, do story line items out of order. Save Game during active game play.
|Valhalla Hall Intro| Interactions with NPCs, enemy NPCs take damage, do story line items out of order. Save Game during active game play.
|Asgard| Interactions with NPCs, enemy NPCs take damage, do story line items out of order. Save Game during active game play.
|1st Level| Interactions with NPCs, enemy NPCs take damage, do story line items out of order. Save Game during active game play.

### Edge Test Cases
|**Test Cases**| **Description** | **Pass/Fail**|
|----|----|----|
|Saved Game Files| Loading correctly
