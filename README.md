# Mobile-GamAR

Mobile GamAR is a mobile augmented reality application that allows users to conveniently and intuitively play virtual board and card games. With the aid of a mobile device, users can control a variety game pieces for Poker and Jacks.

### Built With

Mobile GamAR was built with:

* [Unity](https://unity.com)
* [PTC Vuforia Engine](https://library.vuforia.com/articles/Training/getting-started-with-vuforia-in-unity.html)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine.

### Prerequisites

You will need to install the following software to run Mobile GamAR:

* [Unity](https://unity3d.com/get-unity/download/archive) - Version 2019.3.12f1 (Newer versions may work but untested).

You will need the following accounts set up:
* [Vuforia Developer Account](https://developer.vuforia.com/vui/auth/login)
* [Apple ID](https://support.apple.com/en-us/HT204316)

You will need to print a variety of AR targets used in the project. These targets can be found [here](Misc/ImageTargets.pdf). The following image targets are used:

* Stones
* Tarmac
* Vortex

**NOTE:** Image targets work best when kept straight and crease free. It is best if the image targets are glued to a hard surface like cardboard.

### Installation

1. Clone the repository.

```bash
git clone https://github.com/samsilverman/Mobile-GamAR.git
```

2. Create a Vuforia license key. Steps to do so can be found [here](https://library.vuforia.com/articles/Training/Vuforia-License-Manager.html).

3. Add the license key to Unity. Specifically, in `Window > Vuforia Configuration > App License Key` add the license key from Vuforia.

4. Set project build settings. Go to `File > Build Settings...`. From the Build Settings menu, select the `iOS` platform. Ensure that all the scenes are in the `Scenes To Build` window with the following order:

| Scene Name      | Build Index |
| ----------- | ----------- |
| Scenes/MainMenuScene      | 0       |
| Scenes/PlayingCardsScene   | 1        |
| Scenes/JacksScene   | 2        |

5. Build the project. Select `Build And Run` (you can save the build however you like). In XCode, build the project to your iOS device.