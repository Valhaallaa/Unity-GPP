using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    private Rigidbody Rigidbody;
    public float CurrentSpeed;
    Animator Animator;
    private Vector3 RotAngleGoal, RotAngleCurrent;
    private PlayerMovement PlayerMovement;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = transform.parent.GetComponent<Rigidbody>();
        PlayerMovement = transform.parent.GetComponent<PlayerMovement>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = new Vector3(PlayerMovement.ActiveMoveSpeedH, 0, PlayerMovement.ActiveMoveSpeedV).normalized;
        RotAngleCurrent = Vector3.Lerp(RotAngleCurrent, RotAngleGoal, 0.1f);
        CurrentSpeed = Rigidbody.velocity.magnitude;
        Animator.SetFloat("Speed", CurrentSpeed, .1f, Time.deltaTime);
    }
}
