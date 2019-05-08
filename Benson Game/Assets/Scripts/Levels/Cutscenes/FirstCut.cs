using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCut : MonoBehaviour
{
    void Start()
    {
        GetComponent<Monologue_Trigger>().TriggerMonologue();
        Destroy(this);
    }
}
