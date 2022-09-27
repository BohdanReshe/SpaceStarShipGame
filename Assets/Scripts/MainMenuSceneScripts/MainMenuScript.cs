using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [Header("Full text of information in the main menu")]
    [SerializeField] GameObject infoFullText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip playModeUISound;
    [SerializeField] AudioClip infoUISound;

    public Button playButton;
    public Button infoButton;

    public void OnPlayButtonPress()
    {
        audioSource.PlayOneShot(playModeUISound);

        Invoke("LoadPlayModeScene", 3);
    }

    public void OnInfoButtonPress()
    {
        audioSource.PlayOneShot(infoUISound);
    }

    void LoadPlayModeScene()
    {
        SceneManager.LoadScene(sceneName: "StarShipPlay");
    }
}
