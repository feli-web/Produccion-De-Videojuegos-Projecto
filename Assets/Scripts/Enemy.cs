using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyTime;
    public float[] timeStages;
    public GameObject bc;
    Slider enemyLifeSlider;
 

    void Start()
    {
        enemyLifeSlider = GameObject.Find("EnemyLifeSlider").GetComponent<Slider>();
        enemyLifeSlider.minValue = 0;
        enemyLifeSlider.maxValue = enemyTime;
        StartCoroutine(Patern());
    }

    void FixedUpdate()
    {
        if (enemyTime > 0)
        {
            enemyLifeSlider.value = enemyTime;
            enemyTime -= Time.deltaTime;
        }
    }

    public IEnumerator Patern()
    {
        var a = Instantiate(bc, this.transform.position, Quaternion.Euler(0, 0, 0));
        var b = Instantiate(bc, this.transform.position, Quaternion.Euler(0, 0, 0));

        while (enemyTime != 0)
        {
            if (enemyTime > timeStages[0])
            {

                a.GetComponent<BulletsController>().spawnerType = BulletsController.SpawnerType.Spin;
                a.GetComponent<BulletsController>()._bulletSpeed = 3;
                a.GetComponent<BulletsController>()._bulletSpinDirection = -1;
                b.GetComponent<BulletsController>().spawnerType = BulletsController.SpawnerType.Spin;
                b.GetComponent<BulletsController>()._bulletSpeed = 3;
                b.GetComponent<BulletsController>()._bulletSpinDirection = 1;
                
                yield return new WaitForSeconds(0.5f);
            }
        } 
    }
}
