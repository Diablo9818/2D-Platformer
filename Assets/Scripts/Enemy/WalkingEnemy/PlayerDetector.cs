using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;
    private PlayerMovementHandler _target;
    private bool _isTargetExist;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out PlayerMovementHandler playerMovementHandler))
        {
            _target = playerMovementHandler;
            _isTargetExist = true;
            Rotate(_target.transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovementHandler playerMovementHandler))
        {
            _target = null;
            _isTargetExist = false;

            if (_enemyMove.Direction > 0)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                _enemyMove.transform.rotation = rotation;
            }
            else
            {
                Quaternion rotation = Quaternion.Euler(0, 180, 0);
                _enemyMove.transform.rotation = rotation;
            }
        }
    }

    public bool IsTargetExist()
    {
        return _isTargetExist;
    }

    public Transform GetTarget()
    {
        return _target.transform;
    }

    private void Rotate(float x)
    {
        Vector3 directionToTarget = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0f, angle, 0f);
        _enemyMove.transform.rotation = newRotation;
    }
}
