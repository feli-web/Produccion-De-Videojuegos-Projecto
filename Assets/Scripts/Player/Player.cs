using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 _rotationPoint = Vector2.zero;
    [SerializeField] private float _speed = 5f;
    private int _rotationDirection = 1;

    void FixedUpdate()
    {
        float angle = _speed * _rotationDirection;
        transform.RotateAround(_rotationPoint, Vector3.forward, angle);
    }

    public void ChangeOrientation()
    {
        _rotationDirection *= -1;
    }
}
