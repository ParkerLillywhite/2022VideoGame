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
    [SerializeField] Vector3 targetPosition;

    void Awake(){
        soulPieceMovement = gameObject.GetComponent<SoulPieceMovement>();
        soulFarm = soulFarmGameObject.GetComponent<SoulFarm>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        speedToRandomTarget = 0.07f * Time.deltaTime;
    }

    void Update(){
        if(soulPieceMovement.soulIsFollowingPlayer){
            soulIsIdleInFarm = false;
        }
        if(!soulIsIdleInFarm){
            StopCoroutine(Wander());
        }
        if(soulIsIdleInFarm){
            soulPieceMovement.SoulTarget(targetPosition, speedToRandomTarget);
        }
    }

    public void BeginWander(){
        StartCoroutine(Wander());
    }

    public void StopWander(){
        StopCoroutine(Wander());
    }

    public IEnumerator Wander(){  
        
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
}
