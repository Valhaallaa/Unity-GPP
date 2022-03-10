using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float MoveSpeed; // Speed the Player cube moves at.

    public float ActiveMoveSpeedH, ActiveMoveSpeedV , MoveAcceleration = 2.5f;
 

    private void keyMovement() // Script to keep track of keydowns, if WASD is pressed adds movement in the Rigidbody in that direction
    {
        


        ActiveMoveSpeedV = Mathf.Lerp(ActiveMoveSpeedV, Input.GetAxisRaw("Vertical") * MoveSpeed, MoveAcceleration * Time.deltaTime);
        ActiveMoveSpeedV = Mathf.Lerp(ActiveMoveSpeedV, Input.GetAxisRaw("Vertical") * MoveSpeed, MoveAcceleration * Time.deltaTime);
        ActiveMoveSpeedH = Mathf.Lerp(ActiveMoveSpeedH, Input.GetAxisRaw("Horizontal") * MoveSpeed, MoveAcceleration * Time.deltaTime);
        ActiveMoveSpeedH = Mathf.Lerp(ActiveMoveSpeedH, Input.GetAxisRaw("Horizontal") * MoveSpeed, MoveAcceleration * Time.deltaTime);
        


        _rb.velocity = new Vector3(ActiveMoveSpeedH, 0, ActiveMoveSpeedV);


    }





    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        keyMovement();
      
       

    }
}
