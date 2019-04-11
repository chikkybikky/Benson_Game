using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public Player_tile_walk player;
    public GameObject panel;
    public Monologue_Manager monomanager;
    public CutsceneTrigger startCut;
    private void Start()
    {
        panel.SetActive(false);
    }
    void firstCut()
    {
        triggerCutscene(startCut);
    }
    public void triggerCutscene(CutsceneTrigger trigger)
    {
        panel.GetComponent<Image>().sprite = trigger.cutsceneImage;
        panel.SetActive(true);
        player.busy = true;
        monomanager.cutscene = true;
        trigger.startMonologue();
        trigger.GetComponent<BoxCollider2D>();
        Destroy(trigger);
    }
    public void endCut()
    {
        panel.SetActive(false);
        player.busy = false;
        monomanager.cutscene = false;
        //have it lead into the next monologue if it exists
    }
}
