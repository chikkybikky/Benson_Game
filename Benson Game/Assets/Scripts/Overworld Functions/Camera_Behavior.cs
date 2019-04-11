using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private void Start()
    {
        offset = player.transform.position;
        offset.z = -10;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
