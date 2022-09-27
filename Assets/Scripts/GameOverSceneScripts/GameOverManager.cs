using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killsText;
    [SerializeField] TextMeshProUGUI missilesText;
    [SerializeField] TextMeshProUGUI accuracyText;
    [SerializeField] TextMeshProUGUI timeText;

    void Awake()
    {
        killsText.text = "Kills: " + UIManager.currentKills + " ships";
        missilesText.text = "Missiles: " + UIManager.currentAmountOfMissiles;
        UIManager.currentAccuracy /= 100;
        accuracyText.text = "Accuracy: " + UIManager.currentAccuracy.ToString("0.0 %");
        timeText.text = "Time: " + UIManager.currentTime + " s";
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene(sceneName: "MenuScene");
    }
}
