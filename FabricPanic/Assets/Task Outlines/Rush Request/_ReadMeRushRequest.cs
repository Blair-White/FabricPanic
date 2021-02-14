using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ReadMeRushRequest : MonoBehaviour
{
/*
 Rush Request

    Notes:
*I would prefer most of the logic is done in the rush request controller script however:
*the fabrics you pick up will require a seperate script. and anything else you see as necessary. 
*Once completed use a button with the text "Start MiniGame" or something that activates the game by activating the parent object.
*The whole minigame should be umbrella'd under one object, this object can be empty or contain the manager script. 
   
    Task breakdown:
1) Make the canvas, set it to camera overlay, set the pixels to scale with screen size, and set the  "Match" slider to 0.5
2) Make the rush request controller (See Script in the Above folder marked "General Examples" minigame manager)
3) Make all the elements:
    - Background and text elements:
        - Title and subtitle: no logic needed. 
        - Timer: countdown logic needed with changeable starting time amount.
        - Scores for each basket: each fabric dropped correctly in basket ++ score
        - You Win! and Better Luck Next Time! win/lose condition and text elements.
        - Panel the game is run on 
        - Panel for the title/subtitle
        - box/panel for the timer and scores
        
    - Baskets
    - Fabric to be sorted, these should be random materials

    Flow of the game: 
    -Entry: for now we push a button to start the game.
    -Game Starts: activate the elements.
    -Timer begins
    -Player drags fabrics into basket matching the fabrics material. 
    -Player wins by dragging all fabrics into the basket.
    -Player fails by time running out.
    -Fabrics dropped into wrong basket returns to its starting position. 
 
 
 */
}
