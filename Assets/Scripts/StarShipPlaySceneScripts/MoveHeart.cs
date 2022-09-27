using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeart : MonoBehaviour
{
    [SerializeField] float speedObject;

    void Update()
    {
            transform.Translate(Vector3.back * Time.deltaTime * speedObject);
    }
}
