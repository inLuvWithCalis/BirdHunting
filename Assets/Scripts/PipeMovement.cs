using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private float _edgeX;

    private void Start()
    {
        if (Camera.main != null) _edgeX = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        MovePipe();
    }

    private void MovePipe()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (transform.position.x < _edgeX - 1f)
        { 
            Destroy(gameObject);
        }
    }
}
