using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class TimeLimit : MonoBehaviour
{
    public static Slider slider;

    [SerializeField] private float timeLimit;
    private Schedule schedule;
    //public float totalTime;    
    public static float staticTimeLimit;
    public static float timerUIValue;

    public static bool timeAdded;    

    [SerializeField] private TextMeshProUGUI popupText;
    private Coroutine PopupTextCoroutine;
    private bool CoroutineRun;

    

    

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = timeLimit;
        slider.value = timeLimit;
        schedule = GameObject.Find("Schedule").GetComponent<Schedule>();        
    }

   
    private void Update()
    {
        timeLimit -= Time.deltaTime;
        slider.value = timeLimit;

        ////totalTime = (schedule.hour * 60) + schedule.minute;
        ////slider.value = totalTime;

        ////timeLimit = staticTimeLimit;
      
        //if(currTime != timeLimit)
        //{
        //    currTime++;

        //}
        if (slider.value == 0)
        {
            PlayerHealth.WinLose = 2;
            SceneManager.LoadScene(2);
        }

        
        if (timeAdded == true)
        {
            Popup("+ " + TimerPickup.staticExtraTime + " Mins", 0.5f, 0f);
            for(float i = 1; i > 0; i -= 0.001f)
            {
                timerUIValue = i; 
            }
        }

        
    }
    public void Popup(string textString, float time, float delay) // Text, fade in/out, delay
    {
        if (CoroutineRun)
        {
            StopCoroutine(PopupTextCoroutine);
            popupText.text = "";
            timeAdded = false;

        }
        PopupTextCoroutine = StartCoroutine(FadeInOut(textString, time, delay));
    }

    public IEnumerator FadeInOut(string textString, float time, float delay) // Text, fade in/out, delay
    {
        CoroutineRun = true;

        popupText.text = textString;
        popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 0);
        while (popupText.color.a < 1.0f)
        {
            popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, popupText.color.a + (Time.deltaTime / time));
            yield return null;
        }
        yield return new WaitForSeconds(delay);

        popupText.text = textString;
        popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 1);
        while (popupText.color.a > 0.0f)
        {
            popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, popupText.color.a - (Time.deltaTime / time));
            yield return null;
        }

        CoroutineRun = false;
    }







}
