using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour 
{
    public bool final;
    public bool cont;
    public Monologue monologue;
    public Monologue_Trigger next;
    public Sprite cutsceneImage;
    public void StartCut()
    {
        FindObjectOfType<CutSceneManager>().currentCut = this;
        FindObjectOfType<CutSceneManager>().triggerCutscene();
    }
    public void startMonologue()
    {
        FindObjectOfType<Monologue_Manager>().monologue = monologue;
        FindObjectOfType<Monologue_Manager>().StartMonologue();
    }
}
