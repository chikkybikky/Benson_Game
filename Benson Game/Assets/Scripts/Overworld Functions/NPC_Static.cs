using System.Collections;
using UnityEngine;

public class NPC_Static : MonoBehaviour
{
    public Vector3 StartPos;
    public Sprite[] looks; //in order of sdwa
    public bool busy;

    public Dialogue_Manager DialogueManager;

    void Start()
    {
        float y = StartPos.y;
        int sortLayer = (int)y * -1;
        GetComponent<SpriteRenderer>().sortingOrder = sortLayer;
        busy = false;
        transform.position = StartPos;
        GetComponent<SpriteRenderer>().sprite = looks[0];
    }
    private void Update()
    {
        if (!busy)
        {
            StartCoroutine("lookAway");
        }
    }
    IEnumerator lookAway()
    {
        busy = true;
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        int next = Mathf.RoundToInt(Random.Range(0f, 3f));
        while(!GetComponent<SpriteRenderer>().sprite == looks[next])
        {
            next = Mathf.RoundToInt(Random.Range(0f, 3f));
        }
        GetComponent<SpriteRenderer>().sprite = looks[next];
        busy = false;
    }
    public void TalkToMe(int d)
    {
        busy = true;
        StopCoroutine("lookAway");
        int next = d + 2;
        if(next >= 4)
        {
            next -= 4;
        }
        GetComponent<SpriteRenderer>().sprite = looks[next];
        DialogueManager.NPC = gameObject.GetComponent<NPC_Static>();
        GetComponent<Dialogue_Trigger>().TriggerDialogue();
    }
    void endConvo()
    {
        busy = false;
    }
}