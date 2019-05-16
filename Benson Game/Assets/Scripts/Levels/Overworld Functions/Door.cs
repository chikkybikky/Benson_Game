using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject border;
    public AudioSource doorwalk;
    public CutsceneTrigger finalCut;
    void Start()
    {
        gameObject.transform.tag = "Interactable Object";
    }
    public void Open()
    {
        doorwalk.Play();
        if ((SceneManager.GetActiveScene().buildIndex + 1) < 4)
        {
            border.SetActive(true);
            Invoke("NextLevel", 2f);
        }
        else
        {
            finalCut.StartCut();
        }
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
