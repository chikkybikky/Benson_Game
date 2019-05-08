using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public Player_tile_walk player;
    public GameObject panel;
    public Monologue_Manager monomanager;
    public CutsceneTrigger currentCut;
    public bool cut;
    private void Start()
    {
        panel.SetActive(false);
        currentCut = null;
    }
    public void triggerCutscene()
    {
        cut = true;
        panel.GetComponent<Image>().sprite = currentCut.cutsceneImage;
        panel.SetActive(true);
        player.busy = true;
        monomanager.whatCut = currentCut;
        currentCut.startMonologue();
        currentCut.GetComponent<BoxCollider2D>();
        if (currentCut.monologue.question == true)
        {
            FindObjectOfType<QuestionManager>().cutscene = true;
        }
    }
    public void endCut(bool terminate)
    {
        panel.SetActive(false);
        cut = false;
        player.busy = false;
        if(currentCut.cont)
        {
            currentCut.next.TriggerMonologue();
        }
        if (terminate)
        {
            while (currentCut.GetComponent<BoxCollider2D>() != null)
            {
                DestroyImmediate(currentCut.GetComponent<BoxCollider2D>());
            }
        }
        currentCut = null;
        return;
    }
}
