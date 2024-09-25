using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _rotationCenter;
    [SerializeField] private float _rotationSpeed = 5f;
    private int _rotationDirection = 1;

    void FixedUpdate()
    {
        _rotationCenter.transform.Rotate(0, 0, _rotationSpeed * _rotationDirection);
    }

    public void ChangeOrientation()
    {
        _rotationDirection *= -1;
    }
}
