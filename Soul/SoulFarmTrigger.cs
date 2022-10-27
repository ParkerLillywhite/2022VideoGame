using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFarmTrigger : MonoBehaviour
{
    public bool playerIsInFarm;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            playerIsInFarm = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            playerIsInFarm = false;
        }
    }
}
