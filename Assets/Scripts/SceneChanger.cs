using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    // Array to hold the names of the scenes you want to switch to
    public string[] sceneNames = {"SE", "NE", "Main Menu" };

    // Index to keep track of the current scene in the array
    private int currentSceneIndex = 0;

    void Start()
    {
        // Ensure at least one scene name is provided
        if (sceneNames.Length == 0)
        {
            Debug.LogError("Please add at least one scene name to the array in the inspector.");
        }
    }

    // Method to handle the button click event for Button1
    public void OnButton1Click()
    {
        LoadScene(0);
    }

    // Method to handle the button click event for Button2
    public void OnButton2Click()
    {
        LoadScene(1);
    }

    // Method to handle the button click event for Button3
    public void OnButton3Click()
    {
        LoadScene(2);
    }

    // General method to load a specific scene by index
    public void LoadScene(int sceneIndex)
    {
        // Check if the index is within the array bounds
        if (sceneIndex >= 0 && sceneIndex < sceneNames.Length)
        {
            // Load the scene with the specified index
            SceneManager.LoadScene(sceneNames[sceneIndex]);
        }
        else
        {
            Debug.LogError("Invalid scene index.");
        }
    }
}
