using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleZone : MonoBehaviour
{
       
    GameObject Player;
    PlayerKeys PlayerKeys;
    Schedule Schedule;

    public bool RollCall, DiningTime, YardTime, LockupTime, Restricted; // only Select one of these
    private string ZoneName;



    void OnTriggerStay(Collider other) // Marks player as attended if the Schedule name is the same as the Zone name
    {
        //Debug.Log("Collision");
        if (other.gameObject.name.Contains("Player"))
        {
            if (Restricted)
            {
                PlayerKeys.InRestricted = true;
            }
            else
            {
                
                if (Schedule.RoutineName == ZoneName)
                {
                    Schedule.Attended = true;
                    PlayerKeys.ActivlyAttending = true;
                    Debug.Log("Player Attending " + ZoneName);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            if (Restricted)
            {
                PlayerKeys.InRestricted = false;
            }
            else if(Schedule.RoutineName == ZoneName)
            {
                PlayerKeys.ActivlyAttending = false;
            }
        }
    }

    void AssignZone() // Assigns the Zone its name based on the bool selected
    {
        if (RollCall)
        {
            ZoneName = "RollCall";
        }
        else if (DiningTime)
        {
            ZoneName = "DiningTime";
        }
        else if (YardTime)
        {
            ZoneName = "Yard";
        }
        else if (LockupTime)
        {
            ZoneName = "Lockup";
        }
        //Debug.Log("Zone " + ZoneName + " Assigned");
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerKeys = Player.GetComponent<PlayerKeys>();
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();

        AssignZone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
