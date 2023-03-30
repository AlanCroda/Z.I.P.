using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlayPressed()
    {
        SceneLoader.LoadScene(SceneName.Level1);
    }
}
