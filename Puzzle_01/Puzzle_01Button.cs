using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_01Button : InteractableWorldButton
{
    public bool buttonIsActive;
    Renderer cubeRenderer;

    void Awake(){
        cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
    }
    public void Update(){
        base.GetDistanceFromPlayer(2);

        if (buttonIsActive){
            cubeRenderer.material.SetColor("_Color", Color.green);
        } else if(!buttonIsActive){
            cubeRenderer.material.SetColor("_Color", Color.red);
        }
    }
}
