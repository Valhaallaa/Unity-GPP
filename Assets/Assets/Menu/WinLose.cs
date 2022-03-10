//Reece
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField]
    private GameObject WinCanvas;
    [SerializeField]
    private GameObject LoseCanvas, DoorWin, DoorLose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Win();
        Lose();
    }

    void Win()
    {
        if(PlayerHealth.WinLose == 1)
        {
            WinCanvas.SetActive(true);
            DoorWin.SetActive(true);
            DoorLose.SetActive(false);
        }
    }

    void Lose()
    {
        if (PlayerHealth.WinLose == 2)
        {
            LoseCanvas.SetActive(true);
            DoorLose.SetActive(true);
            DoorWin.SetActive(false);
        }
    }
}
