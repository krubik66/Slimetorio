

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public GameObject storyBoard;

    private bool isOpened = false;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        Cursor.visible = false;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            // Stop playing the scene
            EditorApplication.isPlaying = false;
        #else
            // Quit the application
            Application.Quit();
        #endif
    }

    public void ToggleStoryBoard()
    {
        isOpened =! isOpened;
        if (isOpened)
        {
            storyBoard.SetActive(true);
        }
        else{
            storyBoard.SetActive(false);
        }
    }
}