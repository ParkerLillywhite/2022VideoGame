using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SoulStore : MonoBehaviour
{
    public GameObject storeUI;
    public Button exitButton;
    public TextMeshProUGUI soulBankText;
    public GameObject player;
    Vector2 playerPosition;

    float distanceToObject;
    bool playerHasEngagedWithObject;
    int moneyInTheBank;

    SoulManager soulManager;
    public GameObject soulManagerGameObject;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start(){
        soulManager = soulManagerGameObject.GetComponent<SoulManager>();

        Button button = exitButton.GetComponent<Button>();
        button.onClick.AddListener(HandleExit);

    }

    void Update(){
        GetDistanceFromPlayer(2);
        if(playerHasEngagedWithObject){
            ShowMenu();

        }


    }
    
    void ShowMenu(){
        storeUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        soulBankText.text = moneyInTheBank.ToString();
        moneyInTheBank = soulManager.soulBank;

    }

    void HandleExit(){
        
        storeUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GetDistanceFromPlayer(float distanceToInteract){
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        var gameObjectPosition = gameObject.transform.position;
        
        distanceToObject = Vector2.Distance(playerPosition, gameObjectPosition);

        if(distanceToObject < distanceToInteract && Input.GetKeyDown("e")){
            playerHasEngagedWithObject = true;
        } else if(distanceToObject >= distanceToInteract || Input.GetKeyUp("e")){
            playerHasEngagedWithObject = false;
        }
    }


}
