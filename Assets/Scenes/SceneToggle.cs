using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneToggle : MonoBehaviour
{
    private bool Switch;
    [SerializeField]
    private GameObject Scene1, Scene2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            if (Switch){
                Switch = false;

            }
            else
            {
                Switch = true;
            }
        }
    }

    private void SwapScenes()
    {
        if (Switch)
        {
            Scene2.SetActive(true);
            Scene1.SetActive(false);

        }
        else if (!Switch)
        {
            Scene2.SetActive(false);
            Scene1.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Switch = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwapScenes();
    }
}
