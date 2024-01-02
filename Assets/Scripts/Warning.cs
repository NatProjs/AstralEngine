using UnityEngine;
using UnityEngine.SceneManagement;

public class Warning : MonoBehaviour
{
    // This method is called when the Enter key is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            LoadNextScene();
        }
    }

    // Load the next scene
    private void LoadNextScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index (loop back to the first scene if it's the last one)
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }
}
