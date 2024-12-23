using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    private float timeBetweenSpawns = 3f;
    private float _timeBetweenSpawnsCounter;
    private float _rangeYPosition = 3f;
    private float _range;
    


    private void Start()
    {
        SpwanPipe();
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
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
        _range = Random.Range(-_rangeYPosition, _rangeYPosition);
        transform.position = new Vector3(transform.position.x, _range, transform.position.z);
        Instantiate(pipePrefab, transform.position, Quaternion.identity);
    }
}
