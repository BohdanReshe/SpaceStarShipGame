using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDestroyer : MonoBehaviour
{
    private PlayerController playerController;
    private UIManager uiManager;

    void Start()
    {
        playerController = GameObject.Find("PlayerShip").GetComponent<PlayerController>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerController.PlaySound();
            playerController.PlayParticle(transform.position);

            uiManager.UpdateScores();
            uiManager.UpdateAccuracy();

            gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}

