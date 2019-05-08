using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
