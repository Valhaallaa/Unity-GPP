//Reece Taylor
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

    [SerializeField]
    private GameObject /*key1, key2, key3, */inventoryObj, timerObj; 

    public static int value;
    public static bool k1Enabled, k2Enabled, k3Enabled /*, k4Enabled, k5Enabled*/;

   


    [SerializeField]
    Image[] _img;

    

    [SerializeField] private Image timerImg; 
 
    // Start is called before the first frame update
    void Start()
    {
        
        k1Enabled = false;
        k2Enabled = false;
        k3Enabled = false;
       
        value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debugging();

        Slot1();
        Slot2();
        Slot3();      
       
        if (TimeLimit.timeAdded == true)
        {
            if (timerImg.fillAmount > 0)
            {

                StartCoroutine(UpdateRadialImage());
                
            }
        }
    }
    IEnumerator UpdateRadialImage()
    {
        for (float i = 1; i  > -1; i -= 0.01f)
        {
            yield return new WaitForSeconds(1f);
            timerImg.fillAmount = i;
        }
        
    }
    
    void Slot1()
    {
        if (k1Enabled == false)
        {
            if (value == 1)
            {
                _img[0].color = Color.red;
                _img[0].enabled = true;
                k1Enabled = true;
                value = 0;
            }
            if (value == 2)
            {
                _img[0].color = Color.blue;
                _img[0].enabled = true;
                k1Enabled = true;

                value = 0;
            }
            if (value == 3)
            {
                _img[0].color = Color.green;
                _img[0].enabled = true;
                k1Enabled = true;
                value = 0;
            }
        }
    }

    void Slot2()
    {
        if (k2Enabled == false)
        {
            if (value == 1)
            {
                _img[1].color = Color.red;
                _img[1].enabled = true;
                k2Enabled = true;
                value = 0;
            }
            if (value == 2)
            {
                _img[1].enabled = true;
                _img[1].color = Color.blue;
                k2Enabled = true;
                value = 0;
            }
            if (value == 3)
            {
                _img[1].color = Color.green;
                _img[1].enabled = true;
                k2Enabled = true;
                value = 0;
            }
        }
    }
    void Slot3()
    {
        if (k3Enabled == false)
        {
            if (value == 1)
            {
                _img[2].enabled = true;
                _img[2].color = Color.red;
                k3Enabled = true;
                value = 0;
            }
            if (value == 2)
            {
                _img[2].enabled = true;
                _img[2].color = Color.blue;
                k3Enabled = true;
                value = 0;
            }
            if (value == 3)
            {
                _img[2].enabled = true;
                _img[2].color = Color.green;
                k3Enabled = true;
                value = 0;
            }         
        }
    }

   
 }

    