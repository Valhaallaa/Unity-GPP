using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScheduleUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Routine, Hour, Minute, TextSchedule, Restricted;
    Schedule Schedule;

    GameObject Player;
    private Image image;
    PlayerKeys PlayerKeys;

    private bool RestrictedPoppedUp;

    CanvasGroup CanvasGroup;
   void RestrictedPopup()
   {
        CanvasGroup.alpha = 1;
   }
    void RestrictedPopout()
    {
        CanvasGroup.alpha = 0;
    }


    void RestrictedCheck()
    {
        if (PlayerKeys.InRestricted && RestrictedPoppedUp == false)
        {
            RestrictedPopup();
            RestrictedPoppedUp = true;
            var colour = image.color;
            colour.a = 0.25f;
            image.color = colour;
           
        }
        else if (PlayerKeys.InRestricted == false)
        {
            RestrictedPopout();
            RestrictedPoppedUp = false;
            var colour = image.color;
            colour.a = 0f;
            image.color = colour;

        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Schedule = GameObject.Find("Schedule").GetComponent<Schedule>();
        image = GameObject.Find("Vignette").GetComponent<Image>();
        CanvasGroup = Restricted.GetComponent<CanvasGroup>();
        Player = GameObject.Find("Player");
        PlayerKeys = Player.GetComponent<PlayerKeys>();
    }

    // Update is called once per frame
    void Update()
    {
        Hour.text = Schedule.hour.ToString("00") + ":" + Schedule.minute.ToString("00");
        //Minute.text = Schedule.minute.ToString("00");
        Routine.text = Schedule.Routine.ToString();
        if (PlayerKeys.ActivlyAttending == true)
        {
            TextSchedule.text = "Attending";
        }
        else
        {
            TextSchedule.text = "Not Attending";
        }
        RestrictedCheck();
    }
    
}
