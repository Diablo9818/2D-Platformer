using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class WalkingEnemyBehavior : MonoBehaviour
{
    [SerializeField] private PlayerDetector _detector;

    private EnemyMove _enemyMove;
    private void Awake()
    {
        _enemyMove = GetComponent<EnemyMove>();
        _detector = GetComponentInChildren<PlayerDetector>();
    }

    private void Update()
    {
        if (!_detector.IsTargetExist())
        {
            _enemyMove.Move();
        }
        else
        {
            _enemyMove.MoveToTarget(_detector.GetTarget());
        }
    }
}
