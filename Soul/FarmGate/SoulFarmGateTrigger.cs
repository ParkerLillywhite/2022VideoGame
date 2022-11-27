using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFarmGateTrigger : MonoBehaviour
{
    GameObject player;

    public bool playerIsInRange;

    void Awake(){
        player = GameObject.FindWithTag("Player");

    }

    public void OnTriggerEnter2D(Collider2D player){
        playerIsInRange = true;
    }

    public void OnTriggerExit2D(Collider2D player){
        playerIsInRange = false;
    }
}
