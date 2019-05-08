using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public GameObject TalkPanel;
    public GameObject MonologueButton;
    public Text nameText;
    public Text dialogueText;
    public Image profileImage;

    public Player_tile_walk player;
    public NPC_Static NPC;

    private Queue<string> sentences;
    void Awake()
    {
        NPC = null;
        TalkPanel.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        player.busy = true;
        TalkPanel.SetActive(true);
        MonologueButton.SetActive(false);
        profileImage.sprite = dialogue.profile;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        player.busy = false;
        MonologueButton.SetActive(true);
        TalkPanel.SetActive(false);
        player.busy = false;
        NPC.busy = false;
        NPC = null;
    }
}
