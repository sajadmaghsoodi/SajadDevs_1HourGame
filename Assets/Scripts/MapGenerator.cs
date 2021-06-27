using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private GameObject[] _obstacles;

    private List<GameObject> _grounds;
    private float _groundDefaultZ;
    private int _moveCounter = 0;

    private void Awake()
    {
        _grounds = new List<GameObject>();
        _groundDefaultZ = _groundPrefab.GetComponent<MeshRenderer>().bounds.size.z;
        GenerateGround();
    }

    private void Update()
    {
        HandleGrounds();
    }

    public void GenerateGround()
    {
        for (int i = 0; i < 20; i++)
        {
            Debug.Log("hello");
            _grounds.Add(Instantiate(_groundPrefab, new Vector3(0, 0, _groundDefaultZ * i), Quaternion.identity));
            if (i > 3)
            {
                if (i % 2 == 0)
                {
                    Vector3 location = new Vector3(0, 0, Random.Range((_groundDefaultZ * i) - 3, (_groundDefaultZ * i) + 3));
                    Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], location, Quaternion.identity);
                }
            }
        }
    }

    public void MoveGrounds()
    {
        _moveCounter++;

        var tmp = _grounds[0];
        for (int i = 1; i < _grounds.Count; i++)
        {
            _grounds[i - 1] = _grounds[i];
        }
        tmp.transform.position = _grounds[19].transform.position + new Vector3(0, 0, _groundDefaultZ);

        if (_moveCounter % 2 == 0)
        {
            Vector3 location = new Vector3(0, 0, Random.Range((tmp.transform.position.z) - 3, (tmp.transform.position.z) + 3));
            Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], location, Quaternion.identity);
        }
        _grounds[19] = tmp;

    }

    public void HandleGrounds()
    {
        if (_player.position.z > _grounds[3].transform.position.z)
        {
            MoveGrounds();
        }
    }
}
