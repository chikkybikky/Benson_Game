using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue_box : MonoBehaviour
{
    public Text textBox;
    public Image talkImage;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void talk(Sprite talkSprite, string dialogue)
    {
        talkImage.sprite = talkSprite;
        textBox.text = dialogue;
        gameObject.SetActive(true);
        WaitToCont();
    }
    IEnumerator WaitToCont()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
