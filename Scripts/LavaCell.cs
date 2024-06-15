using UnityEngine;

public class LavaCell : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        var player = collision.GetComponent<PlayerDead>();

        if (player != null && Score.instance.buffScore < 3)
        {
            player.Dead();
        }
        else if (player != null && Score.instance.buffScore >= 3)
        {
            Destroy(this.gameObject);
            PlayerBuff.instance.DeactivateBuff();
            Score.instance.ResetBuffScore();
        }
    }
}
