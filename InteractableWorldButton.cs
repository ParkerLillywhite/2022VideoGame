using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWorldButton : MonoBehaviour
{
    GameObject player;
    Vector2 playerPosition;
    public float distanceToObject;
    public bool playerHasEngagedWithObject;


    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GetDistanceFromPlayer(float distanceToInteract){
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        var gameObjectPosition = gameObject.transform.position;
        
        distanceToObject = Vector2.Distance(playerPosition, gameObjectPosition);

        if(distanceToObject < distanceToInteract && Input.GetKeyDown("e")){
            playerHasEngagedWithObject = true;
        } else if(distanceToObject >= distanceToInteract || Input.GetKeyUp("e")){
            playerHasEngagedWithObject = false;
        }else if(Input.GetKey("e")){
            playerHasEngagedWithObject = false;
        }
    }
}
