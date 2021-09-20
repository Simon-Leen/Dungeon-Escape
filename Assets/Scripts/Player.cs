using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce = 5f;
    private bool _resetJump = false;
    PlayerAnimation _playerAnim;
    private bool _isGrounded = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        float hori = Input.GetAxisRaw("Horizontal") * _speed;
        _isGrounded = IsGrounded();
        _playerAnim.Move(hori);
        
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _playerAnim.Jump(true);
            StartCoroutine(Jumped());
        }

        _rb.velocity = new Vector2(hori, _rb.velocity.y);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnim.Attack();
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 6);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.red, 1 << 6);
        if(hitInfo.collider != null)
        {
            if (!_resetJump)
            {
                _playerAnim.Jump(false);
                return true;
            }
        }
        return false;
    }

    IEnumerator Jumped()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
