using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AnimationBehaviour : MonoBehaviour
{
    NavMeshAgent GuardAgent;
    Animator Animator;
    float CurrentSpeed;
    private Vector3 Lastpos;
    // Start is called before the first frame update
    void Start()
    {
        GuardAgent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //CurrentSpeed = GuardAgent.velocity.magnitude / GuardAgent.speed;
        

        Vector3 curMove = transform.position - Lastpos;
        CurrentSpeed = curMove.magnitude / Time.deltaTime;
        Lastpos = transform.position;
        Animator.SetFloat("Speed", CurrentSpeed, .1f, Time.deltaTime);
        //Debug.Log(CurrentSpeed);
    }


}
