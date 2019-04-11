using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue_Manager : MonoBehaviour
{
    public GameObject TalkPanel;
    public GameObject DialogueButton;
    public Text nameText;
    public Text monologueText;
    public GameObject profileImage;
    public bool cutscene;
    public Monologue_Trigger firstCut; //won't play the first cutscene

    public Player_tile_walk player;

    public Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
        StartCoroutine("giveItASecond");
    }

    public void StartMonologue(Monologue monologue)
    {
        TalkPanel.SetActive(true);
        DialogueButton.SetActive(false);
        profileImage.SetActive(false);
        nameText.text = "Benson";
        sentences.Clear();

        foreach (string sentence in monologue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
        {
            EndMonologue();
            return;
        }
        string sentence = sentences.Dequeue();
        monologueText.text = sentence;
    }

    public void EndMonologue()
    {
        DialogueButton.SetActive(true);
        profileImage.SetActive(true);
        TalkPanel.SetActive(false);
        player.busy = false;
        if (cutscene)
        {
            FindObjectOfType<CutSceneManager>().endCut();
        }
        //have it lead into next cutscene if it exists
    }
    IEnumerable giveItASecond()
    {
        yield return new WaitForSeconds(.004f);
        StartMonologue(firstCut.monologue);
    }
}