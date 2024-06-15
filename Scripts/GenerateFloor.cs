using UnityEngine;

public class GenerateFloor: MonoBehaviour
{
    [SerializeField] private GameObject _lavaFloor;
    [SerializeField] private int _maxCountLavaFloor = 3;

    private void Start()
    {
        GenerateCells();
    }

    private void GenerateCells()
    {
        GameObject helixChank = this.gameObject.transform.GetChild(0).gameObject;

        int childCount = helixChank.gameObject.transform.childCount;
        int openFloor = Random.Range(0, childCount);
        int countLavaFloor = Random.Range(0, _maxCountLavaFloor);
        int[] numberLavaFloor = new int[countLavaFloor];

        for (int i = 0; i < countLavaFloor; i++)
        {
            numberLavaFloor[i] = Random.Range(0, childCount);
        }

        for (int i = 0; i < childCount; i++)
        {
            if (openFloor == i)
            {
                Destroy(helixChank.gameObject.transform.GetChild(i).gameObject);
            }
            else
            {
                for (int j = 0; j < countLavaFloor; j++)
                {
                    if (numberLavaFloor[j] == i)
                    {
                        Vector3 floorPos = helixChank.gameObject.transform.GetChild(i).transform.position;
                        Quaternion floorRot = helixChank.gameObject.transform.GetChild(i).transform.rotation;

                        Instantiate(_lavaFloor, floorPos, floorRot).gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").gameObject.transform);
                     
                        Destroy(helixChank.gameObject.transform.GetChild(i).gameObject);
                    }
                }
            }
        }
    }
}
