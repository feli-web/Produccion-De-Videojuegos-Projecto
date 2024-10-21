using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(gameObject); // Asegura que solo haya una instancia de BulletPool
        }
    }

    void Start()
    {
        GenerateBullets();
    }

    private void GenerateBullets()
    {
        _pooledBullets = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bulletInstance = Instantiate(_bulletPrefab);
            bulletInstance.SetActive(false); // Desactiva la bala inicialmente
            _pooledBullets.Add(bulletInstance);
        }
    }

    public GameObject GetPooledBullet()
    {
        foreach (GameObject bullet in _pooledBullets)
        {
            if (!bullet.activeInHierarchy) // Verifica si la bala está inactiva
            {
                return bullet;
            }
        }

        return null;
    }
}
