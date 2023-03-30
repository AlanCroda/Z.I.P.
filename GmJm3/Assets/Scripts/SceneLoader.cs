using UnityEngine;

public static class SceneLoader
{
    public static void LoadScene(SceneName name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)name);
    }
}

public enum SceneName
{
    MainMenu,
    Tutorial
}
