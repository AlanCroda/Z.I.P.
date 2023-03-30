using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySessionManager : MonoBehaviour
{
    public static PlaySessionManager Instance;
    LevelData Tutorial;

    private void Awake()
    {
        //makes it so there is always only one instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoad;
        LevelManager.LevelEnd += HandleLevelEnd;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1Part1")
        {
            //load tutorial
            LevelManager.StartLevel();
        }
    }

    void HandleLevelEnd(bool playerAlive)
    {
        if (playerAlive)
        {
            //load room according to index (next room in current path)
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            //this will be death screen
        }
    }
}
