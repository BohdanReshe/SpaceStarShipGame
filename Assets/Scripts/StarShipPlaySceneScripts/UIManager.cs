using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoresText;
    [SerializeField] TextMeshProUGUI missilesText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI accuracyText;
    [SerializeField] GameObject live1;
    [SerializeField] GameObject live2;
    [SerializeField] GameObject live3;
    [SerializeField] GameObject loserPhoto;
    
    
    public static int currentKills;
    public static int currentAmountOfMissiles;
    public static int currentTime;
    public static float currentAccuracy;
    private int currentAmountOfLives;

    private GameManager gameManager;

    private void Start()
    {
        RestartStats();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("TimeCount", 0, 1);
    }

    public void UpdateScores()
    {
            currentKills++;
            scoresText.text = "Kills: " + currentKills;
    }

    public void UpdateAmountOfMissiles()
    {
        if (!gameManager.isPaused)
        {
            currentAmountOfMissiles++;
            missilesText.text = "Missiles: " + currentAmountOfMissiles;
        }
    }

    public void UpdateAccuracy()
    {
        if (!gameManager.isPaused)
        {
            currentAccuracy = ((float)currentKills / (float)currentAmountOfMissiles) * 100;
            accuracyText.text = "Accuracy: " + currentAccuracy.ToString("F2") + " %";
        }
    }

    private void TimeCount()
    {
        timeText.text = "Timer: " + currentTime++;
    }

    public void UpdateAmountOfLives(int updateNumber)
    {
        currentAmountOfLives += updateNumber;
        if (currentAmountOfLives == 4)
        {
            currentAmountOfLives--;
        }
        if (currentAmountOfLives == 3)
        {
            live1.SetActive(true);
            live2.SetActive(true);
            live3.SetActive(true);
        }
        if (currentAmountOfLives == 2)
        {
            live1.SetActive(false);
            live2.SetActive(true);
            live3.SetActive(true);
        }
        if (currentAmountOfLives == 1)
        {
            live1.SetActive(false);
            live2.SetActive(false);
            live3.SetActive(true);
        }
        if (currentAmountOfLives == 0)
        {
            live1.SetActive(false);
            live2.SetActive(false);
            live3.SetActive(false);
            gameManager.GameOver();
        }
    }
    void RestartStats()
    {
        currentKills = 0;
        currentAmountOfMissiles = 0;
        currentTime = 0;
        currentAccuracy = 0;
        currentAmountOfLives = 3;
    }
}
