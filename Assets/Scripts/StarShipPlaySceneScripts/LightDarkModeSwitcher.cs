using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDarkModeSwitcher : MonoBehaviour
{
    private LightDarkModeSwitcher lightDarkModeSwitcher;
    private Light light;
    private float lightVar;
    
    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        
    }
}
