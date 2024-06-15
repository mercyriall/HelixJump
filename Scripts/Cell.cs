using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 7;

    private void OnTriggerEnter(Collider collision)
    {
        var playerRb = collision.GetComponent<Rigidbody>();

        if (playerRb != null && Score.instance.buffScore < 3)
        {
            playerRb.velocity = new Vector3(0, _jumpForce, 0);
            Score.instance.ResetBuffScore();
        }
        else if (playerRb != null && Score.instance.buffScore >= 3)
        {
            Destroy(this.gameObject);
            PlayerBuff.instance.DeactivateBuff();
            Score.instance.ResetBuffScore();
        }
    }
}
