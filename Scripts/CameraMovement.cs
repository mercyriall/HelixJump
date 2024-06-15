using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _distance = 3.5f;
    [SerializeField] private Transform _target;


    private void Update()
    {
        if (Mathf.Abs(transform.position.y - _target.position.y) > _distance)
        {
            transform.position = new Vector3(transform.position.x, _target.position.y + _distance, transform.position.z);
        }
    }
}

