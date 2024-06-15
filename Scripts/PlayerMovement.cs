using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int _speedRotation = 550;

    private bool _isSwiping = false;
    private float _startXPos = 0f;
    private bool _isMobile;

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
        if (_isMobile)
        {
            _speedRotation = 200;
        }
    }

    private void Update()
    {
        if (!_isMobile) 
        {
            if (Input.GetMouseButton(0))
            {
               transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * -1, 0) * _speedRotation * Time.deltaTime);
            }
        }
        else
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    _startXPos = Input.GetAxis("Mouse X");
                    _isSwiping = true;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    _isSwiping = false;
                }

                if (_isSwiping)
                {
                    transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X") - _startXPos) * -1, 0) * _speedRotation * Time.deltaTime);
                }
            }
        }

    }
}
