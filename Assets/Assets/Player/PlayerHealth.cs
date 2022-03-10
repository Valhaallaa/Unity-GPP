//Script made by Reece Taylor
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float susLevel = 0;

    public float time;
    public float changeBy = 10f;

    [SerializeField]
    private Slider _slider; 

    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private Image eye;

    public static bool hasLineOfSight;

    float newVal;
    public static int WinLose = 0;


    PlayerKeys PlayerKeys;
    Schedule Schedule;

    //[SerializeField]
    //private Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //gameOverCanvas.enabled = false;
        PlayerKeys = GameObject.Find("Player").GetComponent<PlayerKeys>();
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();
        
        susLevel = 0;
        hasLineOfSight = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        _slider.value = susLevel; 
        //healthText.text = "Suspicion: " + GetRoundedValue(susLevel) + "%";
        IncreaseHealth();
        DecreaseHealth();
        SetEyeIcon();
        susLevel = Mathf.Clamp(susLevel, 0, 100);
        if (susLevel < 0) susLevel = 0; 
        //Debug.Log("sus level = " + susLevel);
    }

    void IncreaseHealth()
    {
        if (hasLineOfSight == true)
        {
            if(PlayerKeys.InRestricted == true && susLevel < 100)
            {
                susLevel += (changeBy + changeBy) * Time.deltaTime; 

            }
            if (susLevel < 100 && PlayerKeys.ActivlyAttending == false && Schedule.CurrentRoutineTime >=20 )
            {
                susLevel += changeBy * Time.deltaTime;
            }
        }

    }
    

    void DecreaseHealth()
    {
        if (hasLineOfSight == false)
        {
            if (susLevel > 0 && hasLineOfSight == false)
            {
                Debug.Log("Sus level is above 0");
                StartCoroutine(Decrease());
            }
        }
    }

    IEnumerator Decrease()
    {
        yield return new WaitForSeconds(3);

        if(susLevel > 0 && PlayerKeys.ActivlyAttending)
        {
           newVal = susLevel -= changeBy * Time.deltaTime;            

        }                
    }

   float GetRoundedValue(float num)
    {
        return Mathf.Round(num * 10) / 10;
        //return 0;
    }

    void SetEyeIcon()
    {
        if (hasLineOfSight)
        {
            eye.color = Color.white;
        }
        else
        {
            eye.color = Color.black;
        }
    }

    //public void GameOver()
    //{
        
    //    SceneManager.LoadScene(2);
    //}
}
