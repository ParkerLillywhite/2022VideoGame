using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFarmTrigger : MonoBehaviour
{
    public bool playerIsInFarm;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            playerIsInFarm = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            playerIsInFarm = false;
        }
    }
}
