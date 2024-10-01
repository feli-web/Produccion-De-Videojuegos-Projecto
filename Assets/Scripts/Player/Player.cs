using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 _rotationPoint = Vector2.zero;
    [SerializeField] private float _initialSpeed = 5f; 
    [SerializeField] private float _maxSpeed = 15f;    
    [SerializeField] private float _speedIncrement = 0.1f; 
    private float _currentSpeed;
    private int _rotationDirection = 1;

    void Start()
    {
        _currentSpeed = _initialSpeed;
    }

    void FixedUpdate()
    {
        float angle = _currentSpeed * _rotationDirection;
        transform.RotateAround(_rotationPoint, Vector3.forward, angle);

        if (_currentSpeed < _maxSpeed)
        {
            _currentSpeed += _speedIncrement * Time.fixedDeltaTime;
        }
    }

    public void ChangeOrientation()
    {
        _rotationDirection *= -1;
        _currentSpeed = _initialSpeed; 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
