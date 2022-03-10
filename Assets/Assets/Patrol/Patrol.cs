using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Patrol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private GameObject[] patrolPoints;
    private float closenessRequired;
    private int currDestination;
    private GameObject player;
    [SerializeField]
    private GameObject Detector;
    private DetectionCone DetectionCone;
    private bool Chasing;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        DetectionCone = Detector.GetComponent<DetectionCone>();
        closenessRequired = 1.5f;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        navMeshAgent.destination = patrolPoints[0].transform.position;
        Chasing = false;
        //navMeshAgent.destination = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealth.susLevel >= 80)
        {
            ChasePlayer();
            navMeshAgent.speed = 3.8f;
        }
        else if (DetectionCone.LookingAtPlayer)
        {
            if (!Chasing) {
                navMeshAgent.isStopped = true;
                  }
        }
        else
        {
            DoPatrol();
            navMeshAgent.speed = 1.5f;
            navMeshAgent.isStopped = false;
        }
    }

    void DoPatrol()
    {
        if (GetClosenessToDestination() < closenessRequired)
        {
            SetNextDestination();
        }
    }

    void ChasePlayer()
    {
        navMeshAgent.destination = player.transform.position;
        navMeshAgent.isStopped = false;
    }
        

    float GetClosenessToDestination()
    {
        return (navMeshAgent.destination - gameObject.transform.position).sqrMagnitude;
    }

    void SetNextDestination()
    {
        currDestination++;
        if (currDestination >= patrolPoints.Length)
        {
            currDestination = 0;
        }
        navMeshAgent.destination = patrolPoints[currDestination].transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerHealth.susLevel >= 60)
        {
            Debug.Log("You were caught!");
            //Time.timeScale = 0;
            PlayerHealth.WinLose = 2;
            SceneManager.LoadScene(2);
            //player.GetComponent<PlayerHealth>().GameOver();
        }
    }
}
