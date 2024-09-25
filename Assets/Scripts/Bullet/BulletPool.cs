using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;

    [Header("Pool Settings")]
    [SerializeField] private List<GameObject> _pooledBullets;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _poolSize;

    void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GenerateBullets();
    }

    void GenerateBullets()
    {
        _pooledBullets = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bulletInstance = Instantiate(_bulletPrefab);
            bulletInstance.SetActive(false);
            _pooledBullets.Add(bulletInstance);
        }
    }

    public GameObject GetPooledBullet()
    {
        foreach (GameObject bullet in _pooledBullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
