using UnityEngine;

public class CylinderDead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Destroy(other.gameObject);
        }
    }
}
