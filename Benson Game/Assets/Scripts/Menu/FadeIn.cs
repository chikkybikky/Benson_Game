using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject video;
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(45);
        Destroy(video);
        panel.SetActive(true);
    }
}
