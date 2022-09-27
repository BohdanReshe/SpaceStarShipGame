using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHeart : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(1, 0, 0, Space.World);  
    }
}
