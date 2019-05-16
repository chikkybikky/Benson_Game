using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public Player_tile_walk player;
    public GameObject panel;
    public Monologue_Manager monomanager;
    public CutsceneTrigger currentCut;
    public bool cut;

    public GameObject border;

    public CutsceneTrigger falling;
    public AudioSource fall;

    private void Start()
    {
        panel.SetActive(false);
        border.SetActive(false);
        currentCut = null;
    }
    public void triggerCutscene()
    {
        cut = true;
        panel.GetComponent<Image>().sprite = currentCut.cutsceneImage;
        panel.SetActive(true);
        border.SetActive(true);
        player.busy = true;
        monomanager.whatCut = currentCut;
        currentCut.startMonologue();
        currentCut.GetComponent<BoxCollider2D>();
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(currentCut == falling)
            {
                fall.volume = 1.0f;
                fall.Play();
            }
        }
        if (currentCut.monologue.question == true)
        {
            FindObjectOfType<QuestionManager>().cutscene = true;
        }
    }
    public void endCut(bool terminate)
    {
        panel.SetActive(false);
        border.SetActive(false);
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
        if (currentCut.final == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            currentCut = null;
        }
    }
}
