using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISDevTemplate.Manager;
using ISDevTemplate.Sound;
using NaughtyAttributes;

public class WalkMan : MonoBehaviour
{
    [SerializeField]
    private int _speed = 1;

    [SerializeField]
    [Header("視界")]
    private Sight _sight;

    [SerializeField]
    [Tag]
    private string _gameClearTag;

    [SerializeField]
    [Tag]
    private string _gameOverTag;

    [SerializeField]
    private GameObject _exlamation;

    private Rigidbody2D _rb;
    private bool _canMove = false;
    private Animator _anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _canMove = true;
        _exlamation.SetActive(false);
    }

    private void Update()
    {
        CheckSight();
        Walk();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _gameClearTag)
        {
            SoundManager.Instance.UseSFX("SE_GameClear");
            GameManager.Instance.GameClear();
        }
        if (collision.gameObject.tag == _gameOverTag)
        {
            SoundManager.Instance.UseSFX("SE_GameOver");
            GameManager.Instance.GameOver();
        }
    }

    private void Walk()
    {
        int s = _canMove ? _speed : 0;
        _rb.velocity = new Vector2(s, -1);
    }

    private void CheckSight()
    {
        bool canMove = _canMove;
        _canMove = !_sight.IsAppearGhost;
        if (canMove == _canMove) return;
        if(!_canMove)
        {
            _anim.speed = 0f;
            _exlamation.SetActive(true);
            SoundManager.Instance.UseSFX("SE_Discover");
        }
        else
        {
            _anim.speed = 1f;
            _exlamation.SetActive(false);
        }
    }
}
