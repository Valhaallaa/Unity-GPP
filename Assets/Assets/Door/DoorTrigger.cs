using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int RotSpeed = 10; // Speed the Player cube moves at.
    //private float RotSpeedActive, RotSpeedAcceleration = 2.5f;
    [SerializeField]
    private GameObject DoorRotationPoint,Door;
    MeshCollider DoorCollider;
    private bool IsDoorOpen;
    private bool PlayerIn;
    private bool EnemyIn;
    private bool PrisonerIn;



    GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            PlayerIn = true;


        }
        else if (other.gameObject.tag.Contains("Enemy"))
        {
            EnemyIn = true;
        }
        else if (other.gameObject.name.Contains("Prisoner"))
        {
            PrisonerIn = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player")) {
            PlayerIn = false;
        }
        else if (other.gameObject.tag.Contains("Enemy"))
        {
            EnemyIn = false;
        }
        else if (other.gameObject.name.Contains("Prisoner"))
        {
            PrisonerIn = false;

        }
    }

    private void OpenDoor()
    {
        DoorRotationPoint.transform.Rotate(0f, 90f, 0f, Space.Self);
        IsDoorOpen = true;
        DoorCollider.enabled = false;
       // Debug.Log("Door Open");
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

        if (PlayerIn == true || EnemyIn == true || PrisonerIn == true)
        {

            if (IsDoorOpen == false) // open Door
            {
                OpenDoor();
            }
        }

        else if (PlayerIn == false && EnemyIn == false && PrisonerIn == false)
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
        Player = GameObject.Find("Player");
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
