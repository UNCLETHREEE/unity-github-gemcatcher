using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1"); // Your actual game scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit(); // Quits in build, not in editor
    }
}
