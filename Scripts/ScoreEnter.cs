using UnityEngine;

public class ScoreEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        var player = collision.gameObject.GetComponent<PlayerDead>();

        if (player != null)
        {
            Score.instance.UpdateScore();
            Score.instance.BuffUpdateScore();
        }
    }
}
