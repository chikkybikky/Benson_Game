using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monologue_Trigger : MonoBehaviour
{
    public Monologue monologue;
    public CutsceneTrigger next;
    public void TriggerMonologue()
    {
        FindObjectOfType<Monologue_Manager>().StartMonologue(monologue);
    }
}
