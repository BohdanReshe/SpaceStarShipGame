using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speedObject;

    void Update()
    {
            transform.Translate(Vector3.up * Time.deltaTime * speedObject);
    }
}
