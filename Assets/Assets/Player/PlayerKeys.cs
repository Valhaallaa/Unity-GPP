using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public static bool InRestricted;
    public bool HasKeyYellow, HasKeyBlue, HasKeyRed, HasKeyGreen, HasKeyPurple, HasSpoon, ActivlyAttending;
    // Start is called before the first frame update
    void Start()
    {
        HasKeyYellow = false;
        HasKeyRed = false;
        HasKeyGreen = false;
        HasKeyBlue = false;
        HasKeyPurple = false;
        HasSpoon = false;
        InRestricted = false;
        ActivlyAttending = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
