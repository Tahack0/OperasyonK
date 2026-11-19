using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    private Animator enemyanimator;
    private enemy enemyy;
    void Start()
    {
        enemyanimator = GetComponent<Animator>();
        enemyy = GetComponent<enemy>();
    }

    public void DeductHealth(float deductHealth)

    {
        enemyHealth -= deductHealth;
        if(enemyHealth <= 0) { EnemyDead(); }

        void EnemyDead()
        {
            enemyy.enabled = false;
            enemyanimator.SetBool("enemydead", true);
            Destroy(gameObject, 8f);
        }
    }
}
