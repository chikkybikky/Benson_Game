using UnityEngine.SceneManagement;
using UnityEngine;

public class Door : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.tag = "Interactable Object";
    }
    public void Open()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
