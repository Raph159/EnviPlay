using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenetest : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
