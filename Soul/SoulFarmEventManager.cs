using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoulFarmEventManager : MonoBehaviour
{
    public static event Action IdleSoulEvent;

    public static void StartIdleSoulEvent(){
        IdleSoulEvent?.Invoke();
    }
}
