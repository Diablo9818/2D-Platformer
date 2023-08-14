using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private int _maxJumps = 2;
    [SerializeField] private int _jumpCount = 0; 

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private string _currentState;
    private bool _isJumping;

    const string PLAYER_IDLE = "Idle";
    const string PLAYER_RUN = "Run";
    const string PLAYER_JUMP = "Jump";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _isJumping = false;
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < _maxJumps)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            _jumpCount = 0;
            _isJumping = false;
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (moveInput != 0 && _isJumping == false)
        {
            ChangeAnimationState(PLAYER_RUN);
        }
        else
        {
            ChangeAnimationState(PLAYER_IDLE);
        }

        _rigidbody.velocity = new Vector2(moveInput * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        ChangeAnimationState(PLAYER_JUMP);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _jumpCount++;
        _isJumping = true;
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



