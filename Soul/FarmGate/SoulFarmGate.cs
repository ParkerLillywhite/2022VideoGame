using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFarmGate : MonoBehaviour
{
    public GameObject gateTrigger;
    public GameObject gate;
    SoulFarmGateTrigger soulFarmGateTrigger;

    void Awake(){
        soulFarmGateTrigger = gateTrigger.GetComponent<SoulFarmGateTrigger>();
    }

    void Update(){
        if (soulFarmGateTrigger.playerIsInRange && Input.GetKeyDown("e")){
            ChangeActiveState();
        }  
    }

    void ChangeActiveState(){
        if (gate.activeInHierarchy){
            gate.SetActive(false);
        } else {
            gate.SetActive(true);
        }
    }
}
