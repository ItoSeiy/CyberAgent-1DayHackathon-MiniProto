using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public bool IsGhostMode => _isGhostMode;

    [SerializeField]
    private int _speed = 1;

    private bool _canMove = false;
    private bool _isGhostMode = false;
    private SpriteRenderer _spriteRendrer;
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private Animator _anim;

    private void Awake()
    {
        _spriteRendrer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();
        _canMove = true;
    }

    private void Update()
    {
        if (!_canMove) return;
        Move();
        if(Input.GetKeyDown(KeyCode.E))
        {
            ChangeGhostMode();
        }
    }

    public void CanMoveFlagChange(bool flag)
    {
        _canMove = flag;
    }

    private void ChangeGhostMode()
    {
        _isGhostMode = !_isGhostMode;
        _collider.isTrigger = _isGhostMode;
        ChangeGhostSkin();
    }

    private void ChangeGhostSkin()
    {
        _anim.SetBool("IsGhostMode", _isGhostMode);
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        SetAnimation(h);
        _rb.velocity = new Vector2(h * _speed, v * _speed);
    }

    private void SetAnimation(float x)
    {
        _anim.SetBool("IsRun", x != 0);
        _spriteRendrer.flipX = x > 0;
    }
}
