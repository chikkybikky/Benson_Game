using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Static : MonoBehaviour
{
    public Vector3 StartPos;
    public Sprite[] looks; //in order of sdwa
    public string[] dialogue;
    public Sprite talkSprite;
    bool busy;
    int nextLine = 0;
    public GameObject talkBox;
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
    public void TalkToMe()
    {
        busy = true;
        talkBox.GetComponent<Dialogue_box>().talk(talkSprite, dialogue[nextLine]);
        nextLine++;
        busy = false;
    }
}
