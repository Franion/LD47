using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform PlayerPos;
    Vector3 camPos;

    void Update()
    {
        camPos = new Vector3(PlayerPos.transform.position.x, PlayerPos.transform.position.y, PlayerPos.transform.position.z - 1.0f);
        transform.position = camPos;
    }
}
