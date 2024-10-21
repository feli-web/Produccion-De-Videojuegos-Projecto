using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float MovementSpeed = 1f;
    
    private Vector2 _spawnPosition;
    private float timer = 0f;

    void Start()
    {
        _spawnPosition = transform.position;
    }
    void OnEnable()
    {
        timer = 0f;
        _spawnPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Movement(timer);

        // Disable the bullet after 10 seconds (for example) or check if it is off-screen
        if (timer > 10f)
        {
            gameObject.SetActive(false);
        }
    }


    private Vector2 Movement(float timer)
    {
        // Mueve la bala de acuerdo a su rotación
        float x = timer * MovementSpeed * transform.right.x;
        float y = timer * MovementSpeed * transform.right.y;
        return new Vector2(x + _spawnPosition.x, y + _spawnPosition.y);
    }
}
