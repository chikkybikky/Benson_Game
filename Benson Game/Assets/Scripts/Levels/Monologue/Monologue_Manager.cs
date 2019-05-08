using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue_Manager : MonoBehaviour
{
    public CutSceneManager cutMan;

    public GameObject TalkPanel;
    public GameObject DialogueButton;
    public Text nameText;
    public Text monologueText;
    public GameObject profileImage;
    public CutsceneTrigger whatCut;
    public Monologue_Trigger firstCut;
    public Monologue monologue;
    public Monologue_Trigger monoTrig;

    public QuestionManager qManager;

    public Player_tile_walk player;

    public Queue<string> sentences;
    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartMonologue()
    {
        player.busy = true;
        TalkPanel.SetActive(true);
        DialogueButton.SetActive(false);
        profileImage.SetActive(false);
        nameText.text = "";
        sentences.Clear();
        foreach (string sentence in monologue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (monologue.question)
            {
                qManager.mTrig = monoTrig;
                monologue.qTrig.AskQuestion();
            }
            EndMonologue();
            return;
        }
        string sentence = sentences.Dequeue();
        monologueText.text = sentence;
    }

    public void EndMonologue()
    {
        bool temp = cutMan.cut;
        DialogueButton.SetActive(true);
        profileImage.SetActive(true);
        TalkPanel.SetActive(false);
        if (!monologue.question)
        {
            player.busy = false;
            if (cutMan.cut)
            {
                FindObjectOfType<CutSceneManager>().endCut(true);
            }
        }
        if (!temp)
        {
            if (monoTrig.cont)
            {
                monoTrig.next.StartCut();
            }
        }
        temp = false;
    }
}