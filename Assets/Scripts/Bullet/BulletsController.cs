using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour
{
    private enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    [SerializeField] private float _bulletSpeed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
        {
            // Use deltaTime to ensure consistent rotation speed
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + (60f * Time.deltaTime));
        }

        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
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
