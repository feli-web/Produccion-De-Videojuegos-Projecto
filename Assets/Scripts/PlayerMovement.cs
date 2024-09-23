using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject center;
    public float speed;
    int o = 1;

    void FixedUpdate()
    {
        center.transform.Rotate(0, 0, speed * o);
    }
    public void ChangeOrientation()
    {
        o *= -1;
    }
}
