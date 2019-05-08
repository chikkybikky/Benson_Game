using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monologue_Trigger : MonoBehaviour
{
    public Monologue monologue;
    public bool cont;
    public Monologue_Manager monoManager;
    public CutsceneTrigger next;
    public void TriggerMonologue()
    {
        monoManager.monoTrig = this;
        monoManager.monologue = monologue;
        monoManager.StartMonologue();
    }
}
