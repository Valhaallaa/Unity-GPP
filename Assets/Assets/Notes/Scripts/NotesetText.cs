using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NotesetText : MonoBehaviour
{
    [SerializeField]
    GameObject Textobj;

    public string TextSet;
    public void CloseNote()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Textobj.GetComponent<Text>().text = TextSet;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
