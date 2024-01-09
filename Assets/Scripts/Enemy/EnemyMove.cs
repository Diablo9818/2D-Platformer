using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class EnemyMove : MonoBehaviour
{
    const string EnemyRun = "Run";
    const string EnemyIdle = "Idle";

    [SerializeField] float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private string _currentState;

    public int Direction { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        Direction = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LeftBorder>())
        {
            Direction = 1;
            if(transform.rotation.eulerAngles.y != 0)
            transform.Rotate(Vector3.up, 180.0f);

        }
        else if (collision.GetComponent<RightBorder>())
        {
            Direction = -1;
            
            if(transform.rotation.eulerAngles.y != -180)
            {
                transform.Rotate(Vector3.down, 180.0f);
            }
        }
    }

    public void Move()
    {
        ChangeAnimationState(EnemyRun);
        _rigidbody.velocity = new Vector2(Direction * _moveSpeed, _rigidbody.velocity.y);
    }
    
    public void MoveToTarget(Transform target)
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            Vector3 moveVelocity = direction * _moveSpeed*2;

            _rigidbody.velocity = new Vector3(moveVelocity.x, _rigidbody.velocity.y);
        }
    }

    public void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
        {
            return;
        }
        _animator.Play(newState);
        _currentState = newState;
    }
}
