using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_01 : MonoBehaviour
{
    public GameObject door;
    public GameObject doorTarget;

    public GameObject button;
    public GameObject button_1;
    public GameObject button_2;

    public GameObject button_3;
    public GameObject button_4;
    public GameObject button_5;

    Puzzle_01Button buttonScript;
    Puzzle_01Button buttonScript_1;
    Puzzle_01Button buttonScript_2;

    Puzzle_01Button buttonScript_3;
    Puzzle_01Button buttonScript_4;
    Puzzle_01Button buttonScript_5;

    [SerializeField] int activeButtons;


    public void Start(){
        buttonScript = button.GetComponent<Puzzle_01Button>();
        buttonScript_1 = button_1.GetComponent<Puzzle_01Button>();
        buttonScript_2 = button_2.GetComponent<Puzzle_01Button>();
        buttonScript_3 = button_3.GetComponent<Puzzle_01Button>();
        buttonScript_4 = button_4.GetComponent<Puzzle_01Button>();
        buttonScript_5 = button_5.GetComponent<Puzzle_01Button>();

        buttonScript_1.buttonIsActive = true;
        buttonScript_5.buttonIsActive = true;

        activeButtons += 2;
    }

    public void Update(){
        if(buttonScript.playerHasEngagedWithObject){
            ChangeButtonState(buttonScript_3);
            ChangeButtonState(buttonScript_2);
        }
        if(buttonScript_1.playerHasEngagedWithObject){
            ChangeButtonState(buttonScript_4);
            ChangeButtonState(buttonScript);
        }
        if(buttonScript_2.playerHasEngagedWithObject){
            ChangeButtonState(buttonScript_5);
            ChangeButtonState(buttonScript_1);
        }
        if(buttonScript_3.playerHasEngagedWithObject){
            ChangeButtonState(buttonScript_5);
        }
        if(buttonScript_4.playerHasEngagedWithObject){
            ChangeButtonState(buttonScript_3);
        }
        if(buttonScript_5.playerHasEngagedWithObject){
            ChangeButtonState(buttonScript_4);
        }

        if(activeButtons == 6){
            OpenDoor();
        }  
      
    }

    public void ChangeButtonState(Puzzle_01Button button){
        if(button.buttonIsActive){
            button.buttonIsActive = false;
            activeButtons -=1;
            return;
        } else if(!button.buttonIsActive){
            button.buttonIsActive = true;
            activeButtons += 1;
            return;
        }
        
    }

    public void OpenDoor(){
        var target = doorTarget.transform.position;
        var speed = 0.001f;
        door.transform.position = Vector3.MoveTowards(door.transform.position, target, Time.deltaTime);
    }

}
