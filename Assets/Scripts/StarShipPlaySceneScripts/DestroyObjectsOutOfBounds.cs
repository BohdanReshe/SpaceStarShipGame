using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsOutOfBounds : MonoBehaviour
{
    [SerializeField] float topBound = 30;
    [SerializeField] float lowerBound = 0;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        if (transform.position.z > topBound)
        {
            gameObject.SetActive(false);
        }


        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Enemy"))
            {
                uiManager.UpdateAmountOfLives(-1);
            }
        }
    }
}
