using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDoor : MonoBehaviour
{
    public int RotSpeed = 10; // Speed the Player cube moves at.
    //private float RotSpeedActive, RotSpeedAcceleration = 2.5f;
    [SerializeField]
    private GameObject DoorRotationPoint, Door;
    MeshCollider DoorCollider;
    private bool IsDoorOpen;
    private bool PlayerIn;
    private bool PrisonerIn;




    Schedule Schedule;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            if (Schedule.isNight == true)
            {
                PlayerIn = false;
            }
            else
            {
                PlayerIn = true;
            }

        }
        if (other.gameObject.name.Contains("Prisoner"))
        {
            if (Schedule.isNight == true)
            {
                PrisonerIn = false;
            }
            else
            {
                PrisonerIn = true;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player")) { PlayerIn = false; }
        if (other.gameObject.name.Contains("Prisoner")) { PrisonerIn = false; }
    }

    private void OpenDoor()
    {
        DoorRotationPoint.transform.Rotate(0f, 90f, 0f, Space.Self);
        IsDoorOpen = true;
        DoorCollider.enabled = false;
        //Debug.Log("Door Open");
    }
    private void CloseDoor()
    {
        DoorRotationPoint.transform.Rotate(0f, -90f, 0f, Space.Self);
        IsDoorOpen = false;
        DoorCollider.enabled = true;
        //Debug.Log("Door Close");
    }

    private void DoorCheck()
    {

        if (PlayerIn == true || PrisonerIn == true)
        {

            if (IsDoorOpen == false) // open Door
            {
                OpenDoor();
            }
        }

        if (PlayerIn == false && PrisonerIn == false)
        {
            if (IsDoorOpen == true) // close door
            {
                CloseDoor();
            }
        }
    }


    
    // Start is called before the first frame update
    void Start()
    {
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();
        IsDoorOpen = false;
        PlayerIn = false;
        DoorCollider = Door.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        DoorCheck();
       
    }
}
