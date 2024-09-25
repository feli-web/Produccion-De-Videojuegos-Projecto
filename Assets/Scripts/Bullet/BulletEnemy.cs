using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0f;
    public float MovementSpeed = 1f;
    
    private Vector2 _spawnPosition;
    private float _lifeTimer = 0f;

    void Start()
    {
        _spawnPosition = transform.position;
    }

    void Update()
    {
        _lifeTimer += Time.deltaTime;

        if (_lifeTimer > 3f) 
        { 
            gameObject.SetActive(false); 
            return; 
        }

        transform.position = Movement(_lifeTimer);
    }

    private Vector2 Movement(float timer)
    {
        // Mueve la bala de acuerdo a su rotación
        float x = timer * MovementSpeed * transform.right.x;
        float y = timer * MovementSpeed * transform.right.y;
        return new Vector2(x + _spawnPosition.x, y + _spawnPosition.y);
    }
}
