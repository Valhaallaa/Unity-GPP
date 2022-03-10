using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeat : MonoBehaviour
{
    Schedule Schedule;
    public int HeatLevel, HeatLevelPercent;

    private void UpHeatLevel()
    {
        HeatLevel++;
        HeatLevelPercent = HeatLevelPercent - 100;
    }


    // Start is called before the first frame update
    void Start()
    {
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
