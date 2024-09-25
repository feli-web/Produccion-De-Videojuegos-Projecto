using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour
{
    private enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    [SerializeField] private float _bulletSpeed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType _spawnerType;
    [SerializeField] private float _fireRate = 1f;

    private float _fireTimer = 0f;

    void Update()
    {
        _fireTimer += Time.deltaTime;

        if (_spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        }

        if (_fireTimer >= _fireRate)
        {
            Fire();
            _fireTimer = 0;
        }
    }

    private void Fire()
    {
        GameObject bullet = BulletPool.SharedInstance.GetPooledBullet();

        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            
            bullet.GetComponent<BulletEnemy>().MovementSpeed = _bulletSpeed;
        }
    }
}
