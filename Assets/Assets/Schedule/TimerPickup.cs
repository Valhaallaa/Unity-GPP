using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimerPickup : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] public static float staticExtraTime;
    [SerializeField] private float extraTime;
    private void Awake()
    {
        staticExtraTime = extraTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            TimeLimit.staticTimeLimit += extraTime;
            TimeLimit.slider.maxValue += extraTime;
            TimeLimit.timeAdded = true;
            //TimeLimit.slider.value
            Destroy(gameObject);
            
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }


}
