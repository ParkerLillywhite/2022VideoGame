using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSoul : MonoBehaviour
{
    Rigidbody2D rigidBody;

    public GameObject soulFarmGameObject;

    SoulPieceMovement soulPieceMovement;
    SoulFarm soulFarm;

    public float speedToRandomTarget;
    public bool soulIsIdleInFarm;
    public bool soulIsCollidingWithTrigger;

    [SerializeField] Vector3 targetPosition;
    [SerializeField] bool inPlayerRadius;
    int soulPieceMaxDistance = 20;
    

    void Start(){
        soulPieceMovement = gameObject.GetComponent<SoulPieceMovement>();
        soulFarm = soulFarmGameObject.GetComponent<SoulFarm>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        speedToRandomTarget = 0.07f * Time.deltaTime;

        SoulFarmEventManager.IdleSoulEvent += BeginWander;
    }

    void Update(){
        if(soulPieceMovement.soulIsFollowingPlayer){
            soulIsIdleInFarm = false;
        }
        if(!soulIsIdleInFarm || !soulIsCollidingWithTrigger){
            StopCoroutine(Wander());
        }
        if(soulIsIdleInFarm){
            soulPieceMovement.SoulTarget(targetPosition, speedToRandomTarget);
        }
        if(!soulPieceMovement.soulIsFollowingPlayer && soulIsCollidingWithTrigger){
            soulIsIdleInFarm = true;
        }
    }

    public void BeginWander(){
        StartCoroutine(Wander());
    }

    public void StopWander(){
        StopCoroutine(Wander());
    }

    private IEnumerator Wander(){  
        while(soulIsIdleInFarm){
            Vector3 target = getTargetPosition();  
            int number = Random.Range(1,20);
            yield return new WaitForSeconds(number);
        }
    }

    private Vector3 getTargetPosition(){
        bool executed = false;
        targetPosition = new Vector3(0, 0, 0);
        if(executed == false){
            Vector3 currentPosition = getCurrentPosition();
            Vector3 randomPosition = getRandomPosition();
            targetPosition =  (currentPosition + randomPosition);
            
            executed = true;

            return targetPosition;

        } else {
            return targetPosition;
        }
        
    }

    private Vector3 getCurrentPosition(){
        return gameObject.transform.position;
    }

    private Vector3 getRandomPosition(){
        float x = Random.Range(-2, 2);
        float y = Random.Range(-2, 2);
        int z = 0;
        Vector3 randomPos = new Vector3(x, y, z);
        return randomPos;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "SoulTrigger"){
            soulIsCollidingWithTrigger = true;
        }
        if(other.tag == "PlayerMaxDistanceTrigger"){
            inPlayerRadius = true;
        }

    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "SoulTrigger"){
            soulIsCollidingWithTrigger = false;
        }
        if(other.tag == "PlayerMaxDistanceTrigger" && soulIsCollidingWithTrigger){
            BeginWander();
            inPlayerRadius = false;
        }
    }

    private void OnDisable(){
        SoulFarmEventManager.IdleSoulEvent -= BeginWander;
    }
}
