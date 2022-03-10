using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSystem : MonoBehaviour
{
    [SerializeField]
    GameObject EntryPoint, ExitPoint;
    
    GameObject Player;
    Vector3 PlayerPos;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.name.Contains("Player"))
        {
           
        }
    }

    void Teleport()
    {
        PlayerPos.x = ExitPoint.transform.position.x;
        PlayerPos.z = ExitPoint.transform.position.z;
        Player.transform.position = PlayerPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Player = GameObject.Find("Player");
        PlayerPos.y = Player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
