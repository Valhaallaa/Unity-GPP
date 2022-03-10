using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{
    public int RotSpeed = 10; // Speed the Player cube moves at.
    //private float RotSpeedActive, RotSpeedAcceleration = 2.5f;
    [SerializeField]
    private GameObject DoorRotationPoint,Door;
    MeshCollider DoorCollider;
    private bool IsDoorOpen;
    public bool PlayerIn;
    public bool EnemyIn;
    [SerializeField]
    private bool YellowKey, BlueKey, RedKey, GreenKey, PurpleKey;
    private bool HasKey;



    GameObject Player;
    PlayerKeys PlayerKeys;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            CheckKeys();
            if (HasKey)
            {
                PlayerIn = true;
            }
        }

        else if(other.gameObject.tag.Contains("Enemy"))
        {
            
                EnemyIn = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player")) { PlayerIn = false; }
        else if (other.gameObject.tag.Contains("Enemy"))   { EnemyIn = false; }
    }

    private void OpenDoor()
    {
        DoorRotationPoint.transform.Rotate(0f, 90f, 0f, Space.Self);
        DoorCollider.enabled = false;
        IsDoorOpen = true;
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

        if (PlayerIn == true || EnemyIn == true)
        {
            
            if (IsDoorOpen == false) // open Door
            {
                OpenDoor();
            }
        }
        
        else if (PlayerIn == false && EnemyIn == false)
        {
            if (IsDoorOpen == true) // close door
            {
                CloseDoor();
            }
        }
        /*
        else if (EnemyIn == true)
        {
            if (IsDoorOpen == false)
            {
                OpenDoor();
            }
        }
        else if (EnemyIn == false)
        {
            if (IsDoorOpen)
            {
                CloseDoor();
            }
        }*/
    }

    private void CheckKeys()
    {
        Debug.Log("CheckingKeys");
        
        if (YellowKey)
        {
            if(PlayerKeys.HasKeyYellow == true)
            {
                HasKey = true;
                //Debug.Log("HasYellowKey");
            }
            else
            {
                HasKey = false;
            }
        }
        if (BlueKey)
        {
            if (PlayerKeys.HasKeyBlue == true)
            {
                HasKey = true;
                //Debug.Log("HasBlueKey");
            }
            else
            {
                HasKey = false;
            }
        }
        if (RedKey)
        {
            if (PlayerKeys.HasKeyRed == true)
            {
                HasKey = true;
               // Debug.Log("HasRedKey");
            }
            else
            {
                HasKey = false;
            }
        }
        if (GreenKey)
        {
            if (PlayerKeys.HasKeyGreen == true)
            {
                HasKey = true;
                //Debug.Log("HasGreenKey");
            }
            else
            {
                HasKey = false;
            }
        }
        if (PurpleKey)
        {
            if (PlayerKeys.HasKeyPurple == true)
            {
                HasKey = true;
               // Debug.Log("HasPurpleKey");
            }
            else
            {
                HasKey = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerKeys = Player.GetComponent<PlayerKeys>();
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