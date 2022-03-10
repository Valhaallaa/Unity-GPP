using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PrisonerMovement : MonoBehaviour
{
    private Schedule Schedule;
    private NavMeshAgent PrisonerAgent;
    private string CurrentRoutine;
    [SerializeField]
    private GameObject LockupPos, RollCallPos, YardPos, DiningTimePos,CurrentTarget;

    private void GetRoutine()
    {
        CurrentRoutine = Schedule.RoutineName;
        if (CurrentRoutine == "Lockup")
        {
            CurrentTarget.transform.position = LockupPos.transform.position;
        }
        else if (CurrentRoutine == "Yard")
        {
            CurrentTarget.transform.position = YardPos.transform.position;
        }
        else if (CurrentRoutine == "DiningTime")
        {
            CurrentTarget.transform.position = DiningTimePos.transform.position;
        }
        else
        {
            CurrentTarget.transform.position = RollCallPos.transform.position;
        }
    }
    private void Pathfinding()
    {
        PrisonerAgent.SetDestination(CurrentTarget.transform.position);

        float distanceToTarget = Vector3.Distance(CurrentTarget.transform.position, transform.position);
        if (distanceToTarget < 0.2f)
        {
            PrisonerAgent.isStopped = true;

        }

        if (distanceToTarget >= 0.2f)
        {
            PrisonerAgent.isStopped = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();
        PrisonerAgent = GetComponent<NavMeshAgent>();
        LockupPos.transform.SetParent(null);
        RollCallPos.transform.SetParent(null);
        YardPos.transform.SetParent(null);
        DiningTimePos.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        GetRoutine();
        Pathfinding();
    }
}
