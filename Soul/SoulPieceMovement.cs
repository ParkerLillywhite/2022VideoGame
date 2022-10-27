using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPieceMovement : MonoBehaviour
{
    public GameObject player;
    Vector2 playerPosition;
    public PlayerMovementManager playerMovementManager;
    Rigidbody2D soulRigidBody;

    public GameObject soulConverterGameObject;

    SoulConverter soulConverter;
    

    public float minimumDistanceToPlayer = 1f;
    private float soulCurrentSpeed = 45f;
    public float distance;

    public bool playerHasCollidedWithSoul = false;
    public bool soulIsFollowingPlayer = false;
    public bool soulHasBeenAddedToList;

    private float soulDistanceToPlayerRadius = 1.7f;
    public float soulSpeed;

    public bool playerIsNotMoving;



    void Awake(){
        player = GameObject.FindWithTag("Player");
        playerMovementManager = player.GetComponent<PlayerMovementManager>();
        soulRigidBody = gameObject.GetComponent<Rigidbody2D>();

        soulConverterGameObject = GameObject.Find("SoulConverter");
        soulConverter = soulConverterGameObject.GetComponent<SoulConverter>();
    }

    void FixedUpdate(){
        if(!soulConverter.soulsAreMovingToTheirDoom){
            SoulFollowsPlayerOnceEngaged();
        }

    }

    public void SoulTarget(Vector3 target, float speed){
        var soulPosition = gameObject.transform.position;

        gameObject.transform.position = Vector3.MoveTowards(soulPosition, target, speed);

        if( speed > 0.07f){
            speed = 0.07f;
        }
    }

    public void SoulFollowsPlayerOnceEngaged(){
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        var soulPosition = gameObject.transform.position;
        distance = Vector2.Distance(playerPosition, soulPosition);
        soulSpeed = Time.deltaTime * distance / minimumDistanceToPlayer * soulCurrentSpeed;
        var recordMovementOfPlayer = !playerMovementManager.isMoving ? playerIsNotMoving = true : playerIsNotMoving = false;

            if (distance <= soulDistanceToPlayerRadius){
                playerHasCollidedWithSoul = true;
                soulIsFollowingPlayer = true;
                AddSoulToPartyList();
            } else if(distance >= 20){
                playerHasCollidedWithSoul = false;
                soulIsFollowingPlayer = false;
                RemoveSoulFromPartyList();
            }

            if(soulSpeed > 0.07f){
                soulSpeed = 0.07f;
            }

            if (playerHasCollidedWithSoul && distance > soulDistanceToPlayerRadius){
                SoulTarget(playerPosition, soulSpeed);
            } else if(!playerHasCollidedWithSoul){
                SoulTarget(soulPosition, 0);
            }
    }

    public void AddSoulToPartyList(){
        SoulManager soulManager = GetComponentInParent<SoulManager>();
        if(!soulHasBeenAddedToList){
            soulManager.soulsInParty.Add(gameObject);
            soulHasBeenAddedToList = true;
        }
    }

    public void RemoveSoulFromPartyList(){
        SoulManager soulManager = GetComponentInParent<SoulManager>();
        if(soulHasBeenAddedToList){
            soulManager.soulsInParty.Remove(gameObject);
            soulHasBeenAddedToList = false;
        }
    }

}
