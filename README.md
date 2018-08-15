# Bowlmaster
A 3D bowling game made by Unity3D. 

## Rules

* The game consists of 10 frames as shown above. In each frame the player has two opportunities to knock down 10 pins. The score for the frame is the total number of pins knocked down, plus bonuses for strikes and spares.

![ScreenShot1](/https://github.com/Silver92/BowlMaster/blob/master/ScreenShot1.png)

* A spare is when the player knocks down all 10 pins in two tries. The bonus for that frame is the number of pins knocked down by the next roll. So in frame 3 above, the score is 10 (the total number knocked down) plus a bonus of 5 (the pins knocked down on the next roll.)

![ScreenShot2](https://github.com/Silver92/BowlMaster/blob/master/Screen%20Shot2.png)

* A strike is when the player knocks down all 10 pins on his first try. The bonus for that frame is the value of the next two balls rolled.
* In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame. However no more than three balls can be rolled in tenth frame

#### Bowling pin specification:

* Maple wood. Density about 0.6g/cm^-3
* Mass 1.53kg
* 38.0 cm (15 inches) tall.
* 12.1 cm (4.75 inches) at their widest point.

#### Bowling pin layout

* 30.48 cm (12 inches) apart sideways (7-8)
* 52.71 cm (20.75 inches) every 2 rows (9-3)

![Bowling Layout](https://github.com/Silver92/BowlMaster/blob/master/ScreenShot_Bowlinglayout.png)

#### Ball specification

* Mass <= 7.3 kg (16 lbs).
* Density <= 3.80 g/cm^-3
* Diameter: (21.59 to 21.83) cm (call it 21.7cm)

#### Bowling Lane Specifications

* 1829 cm from the foul line to the head pin.
* Make is 2000 cm long in total.
* 105 cm wide.

