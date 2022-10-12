using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyLife : MonoBehaviour
{
    public float life = 10;
    public float rEnemyMaxLife = 100;

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) // to destroy the enemy if life is 0
        {
            Destroy(gameObject);
        }
    }
}
