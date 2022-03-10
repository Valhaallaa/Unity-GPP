using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
    Schedule Schedule;
    PlayerKeys PlayerKeys;
    [SerializeField]
    GameObject Pointer;
    [SerializeField]
    GameObject RollCallZone, DiningZone, YardZone, LockUpZone;
    GameObject CurrentZone;
    Vector3 CurrentZonePos;
    void SetZone()
    {
        if(Schedule.RoutineName == "Yard")
        {
            CurrentZone = YardZone;
        }
        else if (Schedule.RoutineName == "DiningTime")
        {
            CurrentZone = DiningZone;
        }
        else if (Schedule.RoutineName == "RollCall")
        {
            CurrentZone = RollCallZone;
        }
        else if (Schedule.RoutineName == "Lockup")
        {
            CurrentZone = LockUpZone;
        }
        else
        {
            //CurrentZone = CurrentZone;
        }
    }

    void MakeInvisibile()
    {
        if (PlayerKeys.ActivlyAttending)
        {
            Pointer.SetActive(false);
        }
        else
        {
            Pointer.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();
        PlayerKeys = GameObject.Find("Player").GetComponent<PlayerKeys>();

    }

    // Update is called once per frame
    void Update()
    {
        SetZone();
        MakeInvisibile();
        if (CurrentZone != null)
        {
            CurrentZonePos = CurrentZone.transform.position;
        }
        Pointer.transform.LookAt(CurrentZonePos);
    }
}
