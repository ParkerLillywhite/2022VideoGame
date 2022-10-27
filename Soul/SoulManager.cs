using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    //it is more performant to get the playerHasCollidedWithSoul var in awake or start...
    //load variable then check to see if it is active? or all in update?

//=========================================================================================================

    public SoulPieceMovement soulPieceMovement;
    public PlayerMovementManager playerMovementManager;

    public GameObject player;
    

    public int souls = 0;
    public List<GameObject> soulsInParty = new List <GameObject>();
    GameObject[] soulsInScene; 
    public int soulBank = 0;


    void Awake(){
        soulsInScene = GameObject.FindGameObjectsWithTag("soul");
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementManager = player.GetComponent<PlayerMovementManager>();
    }
    
    void Update(){
        GetCountOfSoulsInParty(soulsInParty);
        soulsInParty.RemoveAll(soul => !soul);
    }

    void GetCountOfSoulsInParty(List<GameObject> list){
        souls = list.Count;
    }
}
