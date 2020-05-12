1. Team Name:

Mobile GamAR

2. Names & UNIs:

- Irene Chen (ic2409)
- Sam Silverman (sss2287)
- Bingtang Wang (bw2631)
- Jianjin Xu (jx2386)

3. Date of Submission:

5/12/2020

4. Development Platform:

Macbook Pro, MacOS Catalina 10.15.4, Unity 2019.3.10f1

5. Mobile platforms, OS versions, and device names (and server platform, if any): 

iPhone 7, iOS 13.4.1

6. Project title:

Mobile GamAR

7. Project directory overview:

A high level overview of each scene within Unity and the important game objects are listed below (with descriptions added):

MainMenuScene
- Canvas
  - Background Image: Provides the green background for the UI
  - GamesUI: Contains buttons for users to select specific game UIs (cards, jacks)
  - AboutUI: Contains information about the app
  - CreditsUI: Contains credits about the app
  - CardsUI: Contains info on the cards game, calls on SceneManager to load game
  - JacksUI: Contains info on the jacks game, calls on SceneManager to load game
- SceneManager: Loads the PlayingCardsScene and JacksScene

PlayingCardScene
- ARCamera
- Directional Light
- Canvas
  - Wayfinding UI: Contains UI elements for wayfinding (minimap, arrows, etc.)
  - Deck UI: Displays actions (buttons) when deck selected
  - Card UI: Displays actions (buttons) when card selected
  - Chip Case UI: Displays actions (buttons) when chip case selected
  - Chip UI: Displays actions (buttons) when chip selected
  - Home Button: Returns to MainMenuScene
- Managers
  - ManipulationManager: Controls manipulations for all game objects
  - UIManager: Controls which Canvas/UI componenets are showing
  - MinimapManager: Controls appearance of minimap and wayfinding componenets
  - SceneManager: Loads MainMenuScene for Home Button
- CardTable ImageTarget
  - CardTable Scale: Scale of world to fit on Image Target
    - Game Table
    - Deck: Deck for game
    - CPU Bot 1: Bot 1
    - CPU Bot 2: Bot 2
    - Game Table (Minimap): Game Table copy for minimap
- ChipCase ImageTarget
  - CardTable Scale: Scale of chip case to fit on Image Target
    - Chip Case
- Hand ImageTarget
  - Hand Toolbar: Physical toolbar wand
    - Toolbar Tip: Location for which interactions reference

JacksScene
- ARCamera
- Directional Light
- Canvas
  - Jacks Count Text: Displays # of jacks collected in turn
  - Left Button: Button to move player left
  - Right Button: Button to move player right
  - Ball UI: Displays actions (buttons) when ball selected
  - Jacks UI: Displays actions (buttons) when jacks selected
  - Home Button: Returns to MainMenuScene
- Managers
  - MotionManager: Controls player movement around world
  - JacksManager: Controls jacks actions and movement
  - UIManager: Controls which Canvas/UI componenets are showing
  - BallManager: Controls ball actions and movement
  - SceneManager: Loads MainMenuScene for Home Button
- Jacks ImageTarget
  - Jacks Scale: Scale of world to fit on Image Target
    - Game Table
    - Ball: Ball for game
    - Jacks: Jacks for game
    - Default Ball Position
    - Default Jacks Position
    - Respawn Zone
- Hand ImageTarget
  - Hand Toolbar: Physical toolbar wand
    - Toolbar Tip: Location for which interactions reference

Toolkit to Augment Card Games
- QRCode: Code to generate QRCode
  - make_qrcode.py: Generate a default QRCode dataset
  - cread.sh & upload.py: Upload the generated dataset to Vuforia as dataset.
  - QRCode.unitypackage: the resulting Vuforia dataset as a result of scripts above.

- MakeConfig: Script to automatically create a configuration list
  - make_poker.py: Extract individual poker card images from poker_source.jpg
  - make_printables.py: Synthesize enhanced poker card images.
  - make_list.py: Make the configuration list.

8. Special Instructions, if any, for deploying your app: 

Make sure all scenes are added to build with the Main Menu Scene loading first.

9. Special instructions, if any, for preparing your targets: 

We used the following provided image targets:
- stones
- tarmac
- vortex

10. Video URL: 

https://youtu.be/0zFvWrOs-L8

11. Missing features:

- Playing Cards: We were unable to support peeking at cards. Ideally, we wanted to allow users to look at cards without revealing them to other players.
- Playing Cards: We were unable to support group moving of chips and cards. Ideally, we wanted to support easier moving capabilities to allow users to move many cards and chips at once rather than one at a time.

12. Bugs in your code and in any system you used:

- Jacks: when collecting the ball in a jacks turn, the collected jacks in your hand may push the ball rather than collecting it. This may be because the ball must make contact with the hand toolbar and is instead contacting the jack pieces causing it to be pushed away.
- The toolkit for augmenting card game is not integrated with main system.

13. Asset sources: 

- Free Little Games Asset Pack by Ferocious Industries: Used for game peices
- Space Robot Kyle by Unity Technologies: Used for wayfinding in Cards game
