using System;
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    private float timeBetweenSpawns = 2f;
    private float _timeBetweenSpawnsCounter;
    private float _rangeYPosition = 2f;
    private float _startX;
    private float _startY;


    private void Start()
    {
        SpwanPipe();
    }

    private void Update()
    {
        TimeToSpawnPipe();
    }

    private void TimeToSpawnPipe()
    {
        if (_timeBetweenSpawnsCounter <= timeBetweenSpawns)
        {
            _timeBetweenSpawnsCounter += Time.deltaTime;
        }
        else
        {
            SpwanPipe();
            _timeBetweenSpawnsCounter = 0f;
        }
    }

    private void SpwanPipe()
    {
        var range = UnityEngine.Random.Range(-_rangeYPosition, _rangeYPosition);
        transform.position = new Vector3(transform.position.x, range, transform.position.z);
        Instantiate(pipePrefab, transform.position, Quaternion.identity);
    }
}
