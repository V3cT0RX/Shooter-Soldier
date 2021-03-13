using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AggroDetection aggroDetection;
    private Health healthTarget;
    [SerializeField] private float attackRefreshRate = 1.5f;
    private float attackTimer;

    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }

    private void Update()
    {

        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if (canAttack())
            {
                Attack();
            }
        }
    }

    private bool canAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }
}
