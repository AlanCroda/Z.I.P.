using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Objects
    public Player player;
    public Goal goal;
    public Transform harmfulFolder;
    public Transform spikePrefab;
    public Transform enemyFolder;
    public Transform enemyPrefab;

    //Events
    public delegate void LevelStartHandler();
    public static event LevelStartHandler LevelStart;

    public delegate void LevelEndHandler(bool levelPassed);
    public static event LevelEndHandler LevelEnd;


    public LevelData levelData;

    //once scene is loaded we load level
    private void Awake()
    {
        LevelStart += SetUpLevel;
        Goal.OnSessionEnd += EndLevel;
    }

    //if the event is triggered do said event
    public static void StartLevel()
    {
        if(LevelStart != null)
        {
            LevelStart();
        }
    }

    //setting up positions of level data
    void SetUpLevel()
    {
        if(levelData == null)
        {
            return;
        }
        //clearing level incase old data is kept
        clearlevel();
        //setting players position
        player.transform.position = levelData.playerPos;
        //setting goals position
        goal.transform.position = levelData.goalPos;
        //checking amount of enemies and placing in positions given
        for (int i = 0; i < levelData.enemyPos.Length; i++)
        {
            Transform newEnemy = Instantiate(enemyPrefab) as Transform;
            newEnemy.position = levelData.enemyPos[i];
            newEnemy.parent = enemyFolder;
        }
        //checking amount of harmful and placing in positions given
        for (int i = 0; i < levelData.harmfulPos.Length; i++)
        {
            Transform newHarmful = Instantiate(spikePrefab) as Transform;
            newHarmful.position = levelData.harmfulPos[i];
            newHarmful.parent = harmfulFolder;
        }
    }

    void clearlevel()
    {
        //destroys all enemies
        foreach(Transform child in enemyFolder)
        {
            Destroy(child.gameObject);
        }
        //destroys all harmful
        foreach(Transform child in harmfulFolder)
        {
            Destroy(child.gameObject);
        }
    }

    //if the level end is triggered then end level with said value (equal to players alive status to allow fail or pass)
    void EndLevel()
    {
        if(LevelEnd != null)
        {
            //unsubscribing for replayability without problems
            LevelStart -= SetUpLevel;
            Goal.OnSessionEnd -= EndLevel;

            //we will do a check to check if player is alive or dead, if alive then check which scene should be loaded
            //if dead then end game to menu for now
            LevelEnd(false);
        }
    }
}
