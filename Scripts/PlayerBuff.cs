using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    public static PlayerBuff instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Score.instance.buffScore >= 3)
        {
            ActivateBuff();
        }
    }

    private void ActivateBuff()
    {
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void DeactivateBuff()
    {
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
