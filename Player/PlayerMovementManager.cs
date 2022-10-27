using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementManager : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public Camera mainCamera;

    private float playerMovementSpeed = 20f;
    private float playerSprintSpeed = 1.5f;
    private int cameraZOffset = -1;
    private float angledMovementBrake = 0.8f;
    public bool sprintTimerIsActive = false;
    public float counter = 0;

    public bool isSprinting = false;
    public bool isMoving = false;

    

    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void FixedUpdate(){
        MovePlayer();
    }

    void Update(){
        PlayerSprintHandler();
    }

    public void LateUpdate(){
        SnapCameraToPlayer();
    }

    public void MovePlayer(){
        var horizontalInputIsActive = false;
        var verticalInputIsActive = true;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
            if(horizontal > 0 || horizontal < 0){
                horizontalInputIsActive = true; 
            } else {horizontalInputIsActive = false;} 
        float vertical = Input.GetAxisRaw("Vertical");
            if(vertical > 0 || vertical < 0){
                verticalInputIsActive = true;
            } else {verticalInputIsActive = false;}

        Vector2 direction = new Vector2(horizontal, vertical);
        

        
        if (horizontalInputIsActive && verticalInputIsActive){
            rigidbody.AddForce(direction * (playerMovementSpeed * angledMovementBrake * playerSprintSpeed));
            isMoving = true;    
        }
        else if (!horizontalInputIsActive && verticalInputIsActive) {
            rigidbody.AddForce(direction * (playerMovementSpeed * playerSprintSpeed));
            isMoving = true;
        }
        else if (horizontalInputIsActive && !verticalInputIsActive) {
            rigidbody.AddForce(direction * (playerMovementSpeed * playerSprintSpeed));
            isMoving = true;
        }
        else if (!horizontalInputIsActive && !verticalInputIsActive) {
            rigidbody.AddForce(direction * (playerMovementSpeed * playerSprintSpeed));
            isMoving = false;
        }
    }

    public void PlayerSprintHandler(){
        if(Input.GetKeyDown("right shift") || Input.GetKeyDown("left shift")){
            playerSprintSpeed = 1.5f;
            isSprinting = true;
        } else if(Input.GetKeyUp("right shift") || Input.GetKeyUp("left shift")){
            playerSprintSpeed = 1f;
            isSprinting = false;
        }
    }

    public void SnapCameraToPlayer(){
        Vector3 cameraPosition = new Vector3(rigidbody.transform.position.x, rigidbody.transform.position.y, cameraZOffset);
        mainCamera.transform.position = cameraPosition;
    }
}
