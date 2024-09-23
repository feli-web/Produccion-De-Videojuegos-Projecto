using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BulletsController bc;
    public float rotateBC;

    void Start()
    {
        bc = GameObject.Find("BulletController").GetComponent<BulletsController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bc.gameObject.transform.Rotate(0, 0, rotateBC);
    }
}
