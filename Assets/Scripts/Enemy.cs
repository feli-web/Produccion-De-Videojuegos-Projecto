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

    void Update()
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

        BulletsController aController = a.GetComponent<BulletsController>();
        BulletsController bController = b.GetComponent<BulletsController>();

        a.transform.SetParent(this.transform);
        b.transform.SetParent(this.transform);

        if (timeStages.Length < 2)
        {
            Debug.LogError("timeStages array does not have enough values!");
            yield break;
        }

        while (enemyTime > 0)
        {
            if (enemyTime > timeStages[0])  // Stage 1
            {
                aController.spawnerType = BulletsController.SpawnerType.Spin;
                aController._bulletSpeed = 3;
                aController._bulletSpinDirection = -1;
                aController.firingRate = 0.5f;

                bController.spawnerType = BulletsController.SpawnerType.Spin;
                bController._bulletSpeed = 6;
                bController._bulletSpinDirection = -1;
                bController.firingRate = 0.5f;
            }
            else if (enemyTime > timeStages[1] && enemyTime <= timeStages[0])  // Stage 2
            {
                aController._bulletSpinDirection = 1;
                bController._bulletSpinDirection = 1;
                aController._bulletSpeed = 5;  // Modify the bullet behavior for this stage
                bController._bulletSpeed = 7;
            }
            else if (enemyTime > timeStages[2] && enemyTime <= timeStages[1])  // Stage 3
            {
                aController.spawnerType = BulletsController.SpawnerType.Straight;  // Change to a different pattern
                bController.spawnerType = BulletsController.SpawnerType.Spin;
                aController._bulletSpeed = 4;
                bController._bulletSpeed = 6;
                aController.firingRate = 0.3f;  // Faster firing rate
                bController.firingRate = 0.3f;
            }

            yield return null;
        }
        EndPattern();
    }


    void EndPattern()
    {
        Destroy(gameObject); 
    }

}
