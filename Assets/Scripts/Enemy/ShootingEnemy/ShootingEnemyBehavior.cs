using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyShoot))]
[RequireComponent(typeof(EnemyMove))]
public class ShootingEnemyBehavior : MonoBehaviour
{
    const string EnemyIdle = "Idle";

    private EnemyShoot _enemyShoot;
    private EnemyMove _enemyMove;

    private void Awake()
    {
        _enemyShoot = GetComponent<EnemyShoot>();
        _enemyMove = GetComponent<EnemyMove>();
    }

    private void Update()
    {
        if (!_enemyShoot.IsTargetExist())
        {
            _enemyMove.Move();
        }
        else
        {
            _enemyMove.ChangeAnimationState(EnemyIdle);
        }
    }
}
