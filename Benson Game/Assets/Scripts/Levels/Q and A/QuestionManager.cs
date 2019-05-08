using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public CutSceneManager cutMan;
    public GameObject QuestionBox;
    public Text QuestionText;
    public InputField Answer;

    public Monologue_Trigger mTrig;
    public QuestionTrigger qTrig;

    public Monologue_Manager MonoManager;

    public Player_tile_walk player;

    public GameObject door;

    public bool cutscene;

    void Start()
    {
        QuestionBox.SetActive(false);
    }

    public void QuestionAsk()
    {
        player.busy = true;
        QuestionText.text = qTrig.question;
        QuestionBox.SetActive(true);
        Answer.text = "";
    }

    public void AnswerSent()
    {
        if(Answer.text == qTrig.answer)
        {
            Response(true);
            if (qTrig.final != 0)
            {
                LevelComplete();
            }
        }
        else
        {
            Response(false);
        }
    }

    void Response(bool t)
    {
        QuestionBox.SetActive(false);
        if (t)
        {
            qTrig.correct.TriggerMonologue();
            if (!cutscene)
            {
                mTrig.transform.tag = "Untagged";
            }
            else
            {
                if (cutMan.cut)
                {
                    cutMan.endCut(true);
                }
            }
        }
        else
        {
            qTrig.incorrect.TriggerMonologue();
            if (cutMan.cut)
            {
                cutMan.endCut(false);
            }
        }
        player.busy = false;
    }
    void LevelComplete()
    {
        door.transform.tag = "door";
    }
}