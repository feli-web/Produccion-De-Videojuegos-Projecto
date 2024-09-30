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
        StartCoroutine(Pattern());
    }

    void Update()
    {
        if (enemyTime > 0)
        {
            enemyLifeSlider.value = enemyTime;
            enemyTime -= Time.deltaTime;
        }
    }

    public IEnumerator Pattern()
    {
        var a = Instantiate(bc, this.transform.position, Quaternion.Euler(0, 0, 0));
        var b = Instantiate(bc, this.transform.position, Quaternion.Euler(0, 0, 0));

        BulletsController aController = a.GetComponent<BulletsController>();
        BulletsController bController = b.GetComponent<BulletsController>();

        a.transform.SetParent(this.transform);
        b.transform.SetParent(this.transform);

        while (enemyTime > 0)
        {
            if (enemyTime > timeStages[0])
            {
                // First stage logic
                aController.spawnerType = BulletsController.SpawnerType.Spin;
                aController._bulletSpeed = 3;
                aController._bulletSpinDirection = -1;
                aController.firingRate = 0.2f;

                bController.spawnerType = BulletsController.SpawnerType.Spin;
                bController._bulletSpeed = 6;
                bController._bulletSpinDirection = -1;
                bController.firingRate = 0.2f;

                yield return null;
            }
            else if (enemyTime > timeStages[1] && enemyTime < timeStages[0])
            {
                aController._bulletSpinDirection = 1;
                bController._bulletSpinDirection = 1;

                yield return null;
            }
        }

  
        EndPattern();
    }

    void EndPattern()
    {
     
        Debug.Log("Enemy defeated or pattern completed.");
        Destroy(gameObject); 
    }

}
