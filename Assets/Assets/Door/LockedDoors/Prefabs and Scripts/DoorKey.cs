using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [SerializeField]
    private bool YellowKey, BlueKey, RedKey, GreenKey, PurpleKey;


    GameObject Player;
    PlayerKeys PlayerKeys;
    void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Getting Key");
        if (other.gameObject.name.Contains("Player")) {
                if (YellowKey)
                {
                    PlayerKeys.HasKeyYellow = true;
                    Destroy(gameObject);
                    Inventory.value = 4;
                }
                if (BlueKey)
                {

                    PlayerKeys.HasKeyBlue = true;
                    Destroy(gameObject);
                    Inventory.value = 2;

                }
                if (RedKey)
                {

                    PlayerKeys.HasKeyRed = true;
                    Destroy(gameObject);
                    Inventory.value = 1;

                }
                if (GreenKey)
                {

                    PlayerKeys.HasKeyGreen = true;
                    Destroy(gameObject);
                    Inventory.value = 3;

                }
                if (PurpleKey)
                {
                    PlayerKeys.HasKeyPurple = true;
                    //Debug.Log("Purple key collected, but it won't display in inventory yet.");
                    Destroy(gameObject);
                    Inventory.value = 5;
                }
           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerKeys = Player.GetComponent<PlayerKeys>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
