using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Behavior : MonoBehaviour
{
    public GameObject player;
    bool intact = true;
    Vector3 startpos;
    private LineRenderer chain;
    private void Start()
    {
        startpos = transform.position;
        chain = gameObject.AddComponent<LineRenderer>();
        chain.SetVertexCount(2);
        chain.SetPosition(0, startpos);
    }
    private void Update()
    {
        chain.SetPosition(1, player.transform.position);
    }
}
