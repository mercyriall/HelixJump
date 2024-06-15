using UnityEngine;

public class CylinderGeneration : MonoBehaviour
{
    [SerializeField] private float _cylinderRange = 2.65f;
    [SerializeField] private GameObject _cylinder;
    [SerializeField] private GameObject _cylinderDown;
    [SerializeField] private GameObject _cylinderScore;

    private float _lastPositionY;

    private GameObject _generatePoint;
    private GameObject _deadPoint;

    private void Start()
    {
        _generatePoint = GameObject.FindGameObjectWithTag("Finish");
        _lastPositionY = _generatePoint.transform.position.y;

        _deadPoint = GameObject.FindGameObjectWithTag("Respawn");

        Instantiate(_cylinder, new Vector3(0, _deadPoint.transform.position.y - _cylinderRange, 0), Quaternion.identity)
            .gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").gameObject.transform);

        Instantiate(_cylinderDown, new Vector3(0, _deadPoint.transform.position.y - _cylinderRange * 2, 0), Quaternion.identity);
        _cylinderDown.transform.position = new Vector3(0, _deadPoint.transform.position.y - _cylinderRange * 2, 0);

        while (Mathf.Abs(_cylinderDown.transform.position.y) <= Mathf.Abs(_generatePoint.transform.position.y))
        {
            Instantiate(_cylinder, new Vector3(0, _cylinderDown.transform.position.y - _cylinderRange, 0), Quaternion.identity)
                .gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").gameObject.transform);

            _cylinderDown.transform.position = new Vector3(0, _cylinderDown.transform.position.y - _cylinderRange * 2, 0);
        }
    }

    private void Update()
    {
        GenerateCylinder();
    }

    private void GenerateCylinder()
    {
        var nowPosition = _generatePoint.gameObject.transform.position.y;
        if (Mathf.Abs(_cylinderDown.transform.position.y) <= Mathf.Abs(_generatePoint.transform.position.y))
        {
            Instantiate(_cylinder, new Vector3(0, _cylinderDown.transform.position.y - _cylinderRange, 0), Quaternion.identity)
                .gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").gameObject.transform);

            _cylinderDown.transform.position = new Vector3(0, _cylinderDown.transform.position.y - _cylinderRange * 2, 0);

            _lastPositionY = nowPosition;
        }
    }
}
