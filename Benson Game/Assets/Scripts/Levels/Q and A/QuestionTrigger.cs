using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public string question;
    public string answer;

    public Monologue_Trigger correct;
    public Monologue_Trigger incorrect;

    public int final;


    public void AskQuestion()
    {
        FindObjectOfType<QuestionManager>().qTrig = this;
        FindObjectOfType<QuestionManager>().QuestionAsk();
    }
}
