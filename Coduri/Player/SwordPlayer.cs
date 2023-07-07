using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlayer : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public int attackDamage = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().DamageEnemy(attackDamage);
            Debug.Log("We hit " + enemy.name);

        }



        //Damage the enemy
    }

    private void OnDrawGizmosSelected()
    {
        //no error
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
