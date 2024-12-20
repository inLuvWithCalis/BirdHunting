using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _isAlive;
    private AudioSource _audio;
    private float _edgeY;
    [SerializeField] private float flappingSpeed = 10f;
    [SerializeField] private AudioClip flappingSound;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _edgeY = Camera.main.ScreenToWorldPoint(new Vector3(0.5f, 0f, 0f)).y;
    }

    private void Update()
    {
        OnClickJumping();
        ScreenBoundary();
    }

    private void OnClickJumping()
    {
        if (Input.GetMouseButtonDown(0) && !_isAlive)
        {
            // play sound
            _audio.PlayOneShot(flappingSound);
            _rb.linearVelocity = Vector2.up * flappingSpeed;
        }
    }

    private void ScreenBoundary()
    {
        if (transform.position.y < _edgeY) GameManager.Instance.ActiveGameOver();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _isAlive = true;
            GameManager.Instance.ActiveGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scoring"))
        {
            GameManager.Instance.AddScore(1);
        }
    }
}
