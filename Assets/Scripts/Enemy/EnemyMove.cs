using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyShoot))]

public class EnemyMove : MonoBehaviour
{
    const string ENEMY_RUN = "Run";
    const string ENEMY_IDLE = "Idle";

    [SerializeField] float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private EnemyShoot _enemyShoot;
    private Animator _animator;
    private string _currentState;

    public int Direction { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyShoot = GetComponent<EnemyShoot>();
        Direction = 1;
    }

    private void Update()
    {
        if (!_enemyShoot.IsTargetExist())
        {
            Move();
        }
        else
        {
            ChangeAnimationState(ENEMY_IDLE);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LeftBorder>())
        {
            Direction = 1;
            transform.Rotate(Vector3.up, 180.0f);
        }
        else if (collision.GetComponent<RightBorder>())
        {
            Direction = -1;
            transform.Rotate(Vector3.down, 180.0f);
        }
    }

    private void Move()
    {
        ChangeAnimationState(ENEMY_RUN);
        _rigidbody.velocity = new Vector2(Direction * _moveSpeed, _rigidbody.velocity.y);
    }

    private void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
        {
            return;
        }
        _animator.Play(newState);
        _currentState = newState;
    }
}
