using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayAndNightCycle : MonoBehaviour
{
    [SerializeField] private Gradient lightColor;
    [SerializeField] private GameObject light;

    private int days;

    public int Days => days;

    private float time = 50;

    private bool canChangeDay = true;

    public delegate void OnDayChanged();

    public OnDayChanged DayChanged;

    private void Update(){

        time += Time.deltaTime;
        light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = lightColor.Evaluate(time * 0.002f);

        if (time > 500){
            time = 0;
        }

        if ((int)time == 250 && canChangeDay){
            canChangeDay = false;
            DayChanged();
            days++;
        }

        if((int)time == 255){
            canChangeDay = true;
            time += Time.deltaTime;
            light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = lightColor.Evaluate(time * 0.002f);
        }
    }
}
