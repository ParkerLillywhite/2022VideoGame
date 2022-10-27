
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryItem")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public bool isDefaultItem = false;
    
}
