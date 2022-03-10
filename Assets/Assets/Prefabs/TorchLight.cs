using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    private Light Light;
    private float TimeV;

    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponent<Light>();
        TimeV = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeV += Time.deltaTime;
        if (TimeV > Random.Range(0.5f, 3f))
        {
            Light.intensity = Random.Range(0.25f, 0.75f);
            TimeV = 0;
        }
    }
}
