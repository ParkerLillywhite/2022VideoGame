using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPool : ObjectPooler
{
    public GameObject Soul;
    public int soulPoolAmount = 0;
    
    void Start(){
        CreateObjectPool(soulPoolAmount, Soul);
    }
}
