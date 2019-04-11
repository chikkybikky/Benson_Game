using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour 
{
    public Monologue monologue;
    public Monologue_Trigger next;
    public Sprite cutsceneImage;
    public void StartCut()
    {
        FindObjectOfType<CutSceneManager>().triggerCutscene(this);
    }
    public void startMonologue()
    {
        FindObjectOfType<Monologue_Manager>().StartMonologue(monologue);
    }
}
