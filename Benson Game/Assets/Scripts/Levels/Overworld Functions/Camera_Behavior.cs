using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    void LateUpdate()
    {
        Vector3 position = player.transform.position;
        position.z = -10;
        transform.position = position;
    }
}
