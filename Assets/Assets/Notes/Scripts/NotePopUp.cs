using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePopUp : MonoBehaviour
{
    [SerializeField]
    GameObject NotePopUpUI;
    [SerializeField]
    private string TextSet;
    [SerializeField]
    GameObject PickupText;
    [SerializeField]
    private RectTransform canvasRect;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            PickupText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                CreatePopUp();
                //Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            PickupText.SetActive(false);
        }
    }

    private void CreatePopUp()
    {
        var Text = Instantiate(NotePopUpUI, transform.position, transform.rotation, transform);
        if (TextSet != null)
        {
            Text.GetComponent<NotesetText>().TextSet = TextSet;
        }
        Text.transform.SetParent(null);
        Destroy(gameObject);
    }
       
    // Start is called before the first frame update
    void Start()
    {
        canvasRect.eulerAngles = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //PickupText.transform.LookAt(Camera.main.transform.position);
    }
}
