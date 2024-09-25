using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BulletsController _bulletsController;
    public float _rotateBulletsController;

    void Start()
    {
        _bulletsController = GameObject.Find("BulletController").GetComponent<BulletsController>();
    }

    void FixedUpdate()
    {
        _bulletsController.gameObject.transform.Rotate(0, 0, _rotateBulletsController);
    }
}
