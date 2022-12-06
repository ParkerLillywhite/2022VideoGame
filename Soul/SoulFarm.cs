using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFarm : MonoBehaviour
{
    public GameObject soulManagerGameObject;
    public GameObject farmTriggerObject;
    public GameObject player;

    SoulFarmTrigger farmTrigger;
    SoulPieceMovement soulPieceMovement;
    SoulManager soulManager;
    IdleSoul idleSoul;

    List<GameObject> souls = new List<GameObject>();

    public void Start(){
        farmTrigger = GetComponentInChildren<SoulFarmTrigger>();
        soulManager = soulManagerGameObject.GetComponent<SoulManager>();
        
    }

    public void Update(){
        if(farmTrigger.playerIsInFarm && Input.GetKeyDown("x")){
            StopSoulInFarm();
        }
    }

    public void StopSoulInFarm(){
        //this list is not removing soul from the party. throws exception when you call RemoveSoulFromPartyList() from exeecutng within the foreach loop accessing the same List.
        var componentsHaveBeenRetrieved = false;
        if(!componentsHaveBeenRetrieved){
            foreach(GameObject soul in soulManager.soulsInParty){
                soulPieceMovement = soul.GetComponent<SoulPieceMovement>();
                idleSoul = soul.GetComponent<IdleSoul>();
                soulPieceMovement.playerHasCollidedWithSoul = false;
                soulPieceMovement.soulIsFollowingPlayer = false;
                
                soulPieceMovement.gracePeriodIsActive = true;
                soulPieceMovement.InvokeGracePeriod();
        
                idleSoul.soulIsIdleInFarm = true;
                idleSoul.BeginWander();
                componentsHaveBeenRetrieved = true;
            }
        }
    }
}
