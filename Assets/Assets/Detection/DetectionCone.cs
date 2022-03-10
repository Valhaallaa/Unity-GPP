using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCone : MonoBehaviour
{
    private GameObject cone;
    [SerializeField]
    private GameObject GuardObject;
    private MeshRenderer coneMesh;
    [SerializeField]
    private float coneLength;
    [SerializeField]
    private float coneHorizontalScale;
    [SerializeField]
    private float coneVerticalScale;
    [SerializeField]
    private bool showCone;
    private Vector3 tempDir;
    private Vector3 raycastDir;
    private RaycastHit hit;
    [SerializeField]
    private Patrol patrol;
    GameObject Player;
    PlayerKeys PlayerKeys;
    public bool LookingAtPlayer;
    public GameObject hitObject;
    Schedule Schedule;
     

    private const float increaseSusBy = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cone = gameObject.transform.GetChild(0).gameObject;
        coneMesh = cone.GetComponent<MeshRenderer>();
        //playerKeys = FindObjectOfType<PlayerKeys>();
        transform.localScale = new Vector3(coneHorizontalScale, coneLength, coneVerticalScale);
        if (showCone)
        {
            coneMesh.enabled = true;
        }
        else
        {
            coneMesh.enabled = false;
        }


        Player = GameObject.Find("Player");
        PlayerKeys = Player.GetComponent<PlayerKeys>();
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player in field of view.");
            TryRaycast(other);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.hasLineOfSight = false;
            LookingAtPlayer = false;
        }
    }

    void TryRaycast(Collider other)
    {

        tempDir = transform.localEulerAngles;
        //gameObject.transform.LookAt(other.gameObject.transform);
        //gameObject.transform.localEulerAngles += new Vector3(-90, 0, 0);
        //raycastDir = transform.localEulerAngles + new Vector3(-90, 0, 0);
        Ray ray = new Ray(gameObject.transform.position, -gameObject.transform.up);
        Physics.Raycast(ray, out hit);
        //Debug.Log(hit.collider.gameObject);
        hitObject = hit.collider.gameObject;
        transform.localEulerAngles = tempDir;

        if (hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            PlayerHealth.hasLineOfSight = true;
            if (!PlayerKeys.ActivlyAttending)
            {
                
                if (PlayerKeys.InRestricted)
                {
                    LookingAtPlayer = true;
                    GuardObject.transform.LookAt(other.transform.position);
                }
                else if(Schedule.CurrentRoutineTime >=20)
                {
                    LookingAtPlayer = true;
                    GuardObject.transform.LookAt(other.transform.position);
                }
                else
                {
                    LookingAtPlayer = false;
                }

            }
        }
        else if (hit.collider != null)
        {
            PlayerHealth.hasLineOfSight = false;
            LookingAtPlayer = false;
        }
        else
        {
            PlayerHealth.hasLineOfSight = false;
            LookingAtPlayer = false;
        }
    }
}
