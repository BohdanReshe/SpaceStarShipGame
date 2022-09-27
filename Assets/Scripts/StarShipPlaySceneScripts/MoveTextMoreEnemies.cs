using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTextMoreEnemies : MonoBehaviour
{
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.position = new Vector3(1920, -200, 0);
    }

    void Update()
    {

        if (rectTransform.position.y < 2360)
        {
        rectTransform.Translate(new Vector3(0, 15, 0));
        } else
        {
            Destroy(gameObject);
        }
    }
}
