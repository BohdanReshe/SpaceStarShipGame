using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPaused = false;
    private bool isDarkMode = false;
    private bool isOnInfo = true;
    private bool isVolumeTurnOn = true;
    [SerializeField] GameObject[] canvasInfoObjects;
    private float lightVariable;

    private void Start()
    {
        InvokeRepeating("SwitchLightMode", 10, 5);
    }

    void Update()
    {
        // Volume On/Off
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchVolume();
        }

        // set Pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetPause();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchLightMode();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            TurnOnOffInfo();
        }

    }

    public void SetPause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(sceneName: "GameOver");
    }

    public void SwitchVolume()
    {
        if (!isVolumeTurnOn)
        {
            isVolumeTurnOn = true;
            AudioListener.pause = false;
        }
        else
        {
            isVolumeTurnOn = false;
            AudioListener.pause = true;
        }
    }

    public void TurnOnOffInfo()
    {
        if (!isOnInfo)
        {
            for (int i = 0; i < canvasInfoObjects.Length; i++)
            {
                canvasInfoObjects[i].SetActive(true);
            }
            isOnInfo = true;
        }
        else
        {
            for (int i = 0; i < canvasInfoObjects.Length; i++)
            {
                canvasInfoObjects[i].SetActive(false);
            }
            isOnInfo = false;
        }
    }

    public void SwitchLightMode()
    {
        if (isDarkMode)
        {
            StartCoroutine(SmoothlyTurnOnLightMode());
            isDarkMode = false;
        }
        else
        {
            StartCoroutine(SmoothlyTurnOnDarkMode());
            isDarkMode = true;
        }
    }

    IEnumerator SmoothlyTurnOnLightMode()
    {
        Light light = GameObject.Find("Directional Light").GetComponent<Light>();
        for (float lightVariable = 0; lightVariable <= 1; lightVariable += Time.deltaTime)
        {
            light.intensity = lightVariable;
            yield return null;
        }
    }
    IEnumerator SmoothlyTurnOnDarkMode()
    {
        Light light = GameObject.Find("Directional Light").GetComponent<Light>();
        for (float lightVariable = 1f; lightVariable >= 0; lightVariable -= Time.deltaTime)
        {
            light.intensity = lightVariable;
            yield return null;
        }
    }
}