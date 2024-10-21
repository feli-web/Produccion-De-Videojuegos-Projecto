using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour
{
    public enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public float _bulletSpeed = 1f;
    public int _bulletSpinDirection = 1;

    [Header("Spawner Attributes")]
    public SpawnerType spawnerType;
    public float firingRate = 1f;

    private float _timer = 0f;

    void Update()
    {
        UpdateTimer();
        HandleBulletRotation();
        HandleBulletFiring();
    }

    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
    }

    private void HandleBulletRotation()
    {
        if (spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles += new Vector3(0f, 0f, _bulletSpinDirection * 60f * Time.deltaTime);
        }
    }

    private void HandleBulletFiring()
    {
        if (_timer >= firingRate)
        {
            Fire();
            _timer = 0;
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
