using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float enemyTime;
    [SerializeField] private float[] timeStages;
    [SerializeField] private GameObject bulletPrefab;
    private Slider enemyLifeSlider;

    void Start()
    {
        InitializeLifeSlider();
        StartCoroutine(SpawnBulletsPattern());
    }

    void Update()
    {
        UpdateLifeSlider();
    }

    private void InitializeLifeSlider()
    {
        enemyLifeSlider = GameObject.Find("EnemyLifeSlider").GetComponent<Slider>();
        enemyLifeSlider.minValue = 0;
        enemyLifeSlider.maxValue = enemyTime;
    }

    private void UpdateLifeSlider()
    {
        if (enemyTime > 0)
        {
            enemyLifeSlider.value = enemyTime;
            enemyTime -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnBulletsPattern()
    {
        GameObject bulletA = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        GameObject bulletB = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        BulletsController aController = bulletA.GetComponent<BulletsController>();
        BulletsController bController = bulletB.GetComponent<BulletsController>();

        bulletA.transform.SetParent(transform);
        bulletB.transform.SetParent(transform);

        if (timeStages.Length < 3)
        {
            Debug.LogError("timeStages array does not have enough values!");
            yield break;
        }

        while (enemyTime > 0)
        {
            UpdateBulletBehavior(aController, bController);
            yield return null; // Espera hasta el siguiente frame
        }

        EndPattern();
    }

    private void UpdateBulletBehavior(BulletsController aController, BulletsController bController)
    {
        if (enemyTime > timeStages[0]) // Etapa 1
        {
            ConfigureBullet(aController, 3, -1, 0.5f);
            ConfigureBullet(bController, 6, -1, 0.5f);
        }
        else if (enemyTime > timeStages[1]) // Etapa 2
        {
            ConfigureBullet(aController, 5, 1, 0.5f);
            ConfigureBullet(bController, 7, 1, 0.5f);
        }
        else if (enemyTime > timeStages[2]) // Etapa 3
        {
            aController.spawnerType = BulletsController.SpawnerType.Straight; // Cambia a un patrón diferente
            ConfigureBullet(aController, 4, 1, 0.3f); // Velocidad de balas y dirección
            ConfigureBullet(bController, 6, -1, 0.3f);
        }
    }

    private void ConfigureBullet(BulletsController controller, float speed, int spinDirection, float rate)
    {
        controller._bulletSpeed = speed;
        controller._bulletSpinDirection = spinDirection;
        controller.firingRate = rate;
        controller.spawnerType = BulletsController.SpawnerType.Spin; // Define el tipo de spawner por defecto
    }

    private void EndPattern()
    {
        Destroy(gameObject);
    }
}
