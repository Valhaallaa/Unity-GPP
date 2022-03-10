using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Schedule : MonoBehaviour
{

    public bool Attended;
    public int hour = 0;
    public int minute = 0;
    public float CurrentRoutineTime = 0;
    public string Routine;
    public string RoutineName;
    private float time; 
    private string CurrentRoutine;
    public bool isNight;
    private ElapsedTime eTime;
    private GameObject DirectLight;
    private Image bell;
    private AudioSource bellSound;
    private PlayerKeys PlayerKeys;
    [SerializeField] private float bellTime;
    private Color bellColour; 

    void RollCallTime()
    {
        
        Routine = "RollCall";
        RoutineName = "RollCall";
    }

    void DiningTime()
    {
        
        if (hour < 11)
        {
            Routine = "Breakfast";
        }
        else
        {
            Routine = "Dinner Time";
        }
        RoutineName = "DiningTime";
    }

    void FreeTime()
    {
        
        Routine = "FreeTime";
        RoutineName = "FreeTime";
        Attended = true;
    }

    void YardTime()
    {
       
        Routine = "Yard";
        RoutineName = "Yard";
    }

    void LockupTime()
    {
       
        if(hour < 7 && hour > 10)
        {
            Routine = "Night Lockup";
            if(minute >= 30 && Attended)
            {
                hour = 7;
                minute = 0;
                DirectLight.transform.rotation = new Quaternion(7.6f, DirectLight.transform.rotation.y, DirectLight.transform.rotation.z, DirectLight.transform.rotation.w);
            }
        }
        else
        {
            Routine = "Lockup";
        }
        RoutineName = "Lockup";
    }


    void RoutineSchedule()
    {
        switch (hour)
        {
            case 7:
                {
                    RollCallTime();
                    isNight = false;
                    break;
                }
            case 8:
                {
                    DiningTime();
                    break;
                }
            case 9:
                {
                    YardTime();
                    break;
                }
            case 11:
            {
                    LockupTime();
                    break;
                }
            case 12:
                {
                    DiningTime();
                    break;
                }
            case 13:
                {
                    YardTime();
                    break;
                }
            case 14:
                {
                    LockupTime();
                    break;
                }
            case 16:
                {
                    RollCallTime();
                    break;
                }
            case 17:
                {
                    DiningTime();
                    break;
                }
            case 18:
                {
                    YardTime();
                    break;
                }
            case 21:
                {
                    LockupTime();
                    isNight = true;
                    break;
                }
        }
    }

    IEnumerator RoutineChange(float time)
    {
        bellColour.a = 1;
        bellSound.Play();
        yield return new WaitForSeconds(time);
        for (float i = bellColour.a; i > -1; i -= Time.deltaTime)
        {
            
            bellColour.a = i;
            
            yield return null;
        }
        

    }

    void Attendance()
    {
        if(CurrentRoutine != RoutineName)
        {
           
            //StartCoroutine(RoutineChange(bellTime));
            


            CurrentRoutine = RoutineName;
            CurrentRoutineTime = 0; 
            Attended = false;
            PlayerKeys.ActivlyAttending = false;
        }
        
    }


    private void Timer()
    {
                
        if(time >= 1)
        {
            minute++;
            time = 0;
            if(minute >= 60)
            {
               
                hour++;
                
                minute = 0;
                //if(hour )
                StartCoroutine(RoutineChange(bellTime));

                if (hour >= 24)
                {
                    hour = 0;
                }
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //eTime = FindObjectOfType<ElapsedTime>();
        DirectLight = GameObject.Find("Directional Light");
        bell = GameObject.Find("Bell").GetComponent<Image>();
        bellSound = GetComponent<AudioSource>();
        bellColour = bell.color;
        PlayerKeys = GameObject.Find("Player").GetComponent<PlayerKeys>();
        StartCoroutine(RoutineChange(bellTime));
    }

    // Update is called once per frame
    void Update()
    {
        
        CurrentRoutineTime = CurrentRoutineTime + Time.deltaTime;
        DirectLight.transform.Rotate(0.2f * Time.deltaTime, 0, 0, Space.World);
        bell.color = bellColour;
        time = time + Time.deltaTime;
        //Debug.Log(CurrentRoutineTime);
        RoutineSchedule();
        Attendance();
        Timer();
        //Debug.Log("Hour:"+ hour + " Minute: " + minute + " Second: " + time);
    }

    
}
