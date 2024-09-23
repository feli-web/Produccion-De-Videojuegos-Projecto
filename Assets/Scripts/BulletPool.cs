using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<GameObject> pooledBullets;
    public GameObject bulletsToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        GenerateBullets();
    }
    void GenerateBullets()
    {
        pooledBullets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(bulletsToPool);
            tmp.SetActive(false);
            pooledBullets.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }
}
