using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFarm : MonoBehaviour
{
    public GameObject farmTriggerObject;
    public GameObject player;

    SoulFarmTrigger farmTrigger;
    SoulPieceMovement soulPieceMovement;
    SoulManager _soulManager;


    public void Start(){
        farmTrigger = GetComponentInChildren<SoulFarmTrigger>();

    }

    public void Update(){

        

        Vector3 targetPosition;

        var x = Random.Range(-10, 10);
        var y = Random.Range(-10, 10);
        var z = 0;
        targetPosition = new Vector3(x, y, z);

        if(farmTrigger.playerIsInFarm && Input.GetKeyDown("e")){
            foreach(GameObject soul in _soulManager.soulsInParty){
                soulPieceMovement.SoulTarget(targetPosition, 0.03f);
            }
        }
    }

    void GetSoulsInParty(){
        var componentsHaveBeenRetrieved = false;
        if(!componentsHaveBeenRetrieved){
            foreach(GameObject soul in _soulManager.soulsInParty){
            soulPieceMovement = soul.GetComponent<SoulPieceMovement>();
            componentsHaveBeenRetrieved = true;
            }
        }
    }
}
