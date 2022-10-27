using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //UI class
    public GameObject inventoryUI;
    public GameObject droneMenu;
    public GameObject basicSwordSlot;

    public Button droneMenuExitButton;
    public Button droneMenuButton;

    InventoryItems inventory;

    
    bool uiIsActive = false;

    // buttons in the UI
    Item basicSwordItem;

    void Start(){
        Button button = droneMenuExitButton.GetComponent<Button>();
        button.onClick.AddListener(DeactivateDroidMenu);
        Button buttonTwo = droneMenuButton.GetComponent<Button>();
        buttonTwo.onClick.AddListener(ActivateDroidMenu);

        inventory = InventoryItems.instance;
        inventory.onItemChangedCallback += UpdateUI;

    }

    void Update(){
        ActivateAndDeactivateMenu();

    }

    void UpdateUI(){
    }

    void ActivateDroidMenu(){
        droneMenu.gameObject.SetActive(true);
    }

    void DeactivateDroidMenu(){
        droneMenu.gameObject.SetActive(false);
    }

    void ActivateAndDeactivateMenu(){
        if(!uiIsActive && Input.GetKeyDown("t")){
            inventoryUI.SetActive(true);
            uiIsActive = true;
            Time.timeScale = 0f;
        }
        else if(uiIsActive && Input.GetKeyDown("t")){
            inventoryUI.SetActive(false);
            uiIsActive = false;
            Time.timeScale = 1f;
        }
    }

}
