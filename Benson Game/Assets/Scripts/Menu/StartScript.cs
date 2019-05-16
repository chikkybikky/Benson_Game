using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public AudioSource music;
    public void Begin()
    {
        PlayerPrefs.SetFloat("volume", music.volume);
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
