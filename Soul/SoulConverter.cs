using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulConverter : InteractableWorldButton
{
    public GameObject soulBlender;
    public GameObject soulManagerGameObject;
    Vector2 soulBlenderPosition;

    SoulManager soulManager;
    SoulPieceMovement soulPieceMovement;
    SoulValue soulValueScript;

    public bool soulsAreMovingToTheirDoom;
    float soulSpeedToTheirDoom;


    public List<GameObject> souls = new List<GameObject>();
    public List <GameObject> deathRowSouls = new List<GameObject>();
    void Awake(){
        soulManager = soulManagerGameObject.GetComponent<SoulManager>();
    }

    void Update(){
        souls = soulManager.soulsInParty;
        GetDistanceFromPlayer(2);

        if(playerHasEngagedWithObject){
            soulsAreMovingToTheirDoom = true;
            
        }
        if(soulsAreMovingToTheirDoom){
            MoveSoulToSoulBlender();
        }

    }


    void MoveSoulToSoulBlender(){
        var blenderSize = 1;
        var soulSpeedToTheirDoomMultiplier = 2;

        Vector2 soulBlenderPosition = new Vector2(soulBlender.transform.position.x, soulBlender.transform.position.y);
        soulSpeedToTheirDoom = Time.deltaTime * soulSpeedToTheirDoomMultiplier;

        foreach(GameObject soul in souls){

            soulPieceMovement = soul.GetComponent<SoulPieceMovement>();
            soulValueScript = soul.GetComponent<SoulValue>();

            soulPieceMovement.SoulTarget(soulBlenderPosition, soulSpeedToTheirDoom);

            Vector2 soulPosition = new Vector2(soul.transform.position.x, soul.transform.position.y);

            var distanceToBlender = Vector3.Distance(soulPosition, soulBlenderPosition);

            var valueHasBeenAddedToSoulBank = false;

            if(distanceToBlender < blenderSize){
                if(valueHasBeenAddedToSoulBank == false){
                    soulManager.soulBank += soulValueScript.soulValue;
                    valueHasBeenAddedToSoulBank = true;
                }
                Destroy(soul);
            }
        }
        

        if(souls.Count == 0){
            soulsAreMovingToTheirDoom = false;
        }
    }




}
