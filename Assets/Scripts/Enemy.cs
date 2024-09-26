using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    public float enemyTime;
    public GameObject bc;
    Slider enemyLifeSlider;
 

    void Start()
    {
        enemyLifeSlider = GameObject.Find("EnemyLifeSlider").GetComponent<Slider>();
        enemyLifeSlider.minValue = 0;
        enemyLifeSlider.maxValue = enemyTime;
    }

    void FixedUpdate()
    {
        if (timer < enemyTime)
        {
            enemyLifeSlider.value = timer;
            timer += Time.deltaTime;
        }
    }
}
