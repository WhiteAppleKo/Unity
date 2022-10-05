using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [Header("회전속도 조절")]
    [SerializeField] [Range(1f, 100f)] float rotateSpeed = 50f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);

    }
}
