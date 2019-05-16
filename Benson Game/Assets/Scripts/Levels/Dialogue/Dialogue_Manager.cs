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
    Dialogue_Trigger currentDia;
    int index;

    public Player_tile_walk player;
    public NPC_Static NPC;

    private Queue<string> sentences;
    void Awake()
    {
        NPC = null;
        TalkPanel.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue_Trigger dialogueT)
    {
        index = 0;
        currentDia = dialogueT;
        player.busy = true;
        TalkPanel.SetActive(true);
        MonologueButton.SetActive(false);
        profileImage.sprite = dialogueT.dialogue.profile;

        sentences.Clear();

        foreach(string sentence in dialogueT.dialogue.sentences)
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
        if (currentDia.dialogue.name[index].Length > 0)
        {
            dialogueText.color = new Color(0.1490196f, 0.454902f, 0.7529413f);
        }
        else
        {
            dialogueText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f);
        }
        nameText.text = currentDia.dialogue.name[index];
        index++;
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        if (currentDia.delete)
        {
            Destroy(currentDia);
        }
        dialogueText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f);
        player.busy = false;
        MonologueButton.SetActive(true);
        TalkPanel.SetActive(false);
        player.busy = false;
        NPC.busy = false;
        NPC = null;
    }
}
