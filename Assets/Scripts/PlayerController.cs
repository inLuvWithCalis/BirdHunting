using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float flappingSpeed = 10f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnClickJumping();
    }

    private void OnClickJumping()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.linearVelocity = Vector2.up * flappingSpeed;
        }
    }
}
