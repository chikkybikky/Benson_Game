﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool delete;

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(this);
    }
}
