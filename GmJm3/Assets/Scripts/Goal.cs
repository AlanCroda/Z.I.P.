using UnityEngine;

public class Goal : MonoBehaviour
{
    public delegate void GoalReachedHandler();
    public static event GoalReachedHandler OnSessionEnd;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player collides with goal then the players session will end
        if (OnSessionEnd != null)
        {
            OnSessionEnd();
        }
    }
}
