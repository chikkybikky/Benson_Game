﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
