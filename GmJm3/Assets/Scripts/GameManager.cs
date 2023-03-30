using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelData levelData;

    private void Start()
    {
        //before game begins we want a level end to include the game session end
        LevelManager.LevelEnd += GameSessionEnd;
        //we want to start the level
        LevelManager.StartLevel();
    }

    //when the level end is at the game session end
    void GameSessionEnd(bool alive)
    {
        //we check if the boolean passed is true meaning player is alive
        if(alive)
        {
            Debug.Log("Player is alive");
        }
        //else the player is dead so game over
        else
        {
            Debug.Log("Game Over");
        }
    }
}
