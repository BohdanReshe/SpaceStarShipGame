using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceBackground : MonoBehaviour
{
    [SerializeField] float backgroundSpeed;
    [SerializeField] float startPosBackground = -8;

    void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * backgroundSpeed);
    }
    private void Update()
    {
        if (transform.position.z < -122)
        {
            transform.position = new Vector3 (0, 0, startPosBackground);
        }
    }
}
