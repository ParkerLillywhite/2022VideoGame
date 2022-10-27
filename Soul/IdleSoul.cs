using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSoul : MonoBehaviour
{
    Rigidbody2D rigidBody;

    public GameObject soulFarmGameObject;

    SoulPieceMovement soulPieceMovement;
    SoulFarm soulFarm;

    public bool soulIsIdleInFarm;

    void Awake(){
        soulPieceMovement = gameObject.GetComponent<SoulPieceMovement>();
        soulFarm = soulFarmGameObject.GetComponent<SoulFarm>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(soulPieceMovement.soulIsFollowingPlayer){
            soulIsIdleInFarm = false;
        }
    }

    void Wander(){
        Vector3 targetPosition;
        
        var x = Random.Range(-10, 10);
        var y = Random.Range(-10, 10);
        var z = 0;
        targetPosition = new Vector3(x, y, z);
    }
}
