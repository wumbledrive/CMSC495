# Valhalla’s Finest
### CMSC 495 --- Team 5 --- Week 2


## Test Plan

##### Team Members:  
Andres Giraldo, Jesse Nelson Nicholas Troyer, Roger Manga, Samuel Hoffman, & Sean Donovan.

### Table of Contents
* [Introduction](#introduction)
* [Approach](#approach)
* [Responsibilities](#responsibilities)
* [Testing Criteria](#testingcriteria)
* [Testing Environment](#testingenvironment)
* [Test Deliverables](#testdeliverables)
* [Sample Test Cases](#sampletestcases)

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
