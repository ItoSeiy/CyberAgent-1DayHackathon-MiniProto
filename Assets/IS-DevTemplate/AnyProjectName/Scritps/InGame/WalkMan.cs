using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISDevTemplate.Manager;
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

    private Rigidbody2D _rb;
    private bool _canMove = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _canMove = true;
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
            GameManager.Instance.GameClear();
        }
        if (collision.gameObject.tag == _gameOverTag)
        {
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
        _canMove = !_sight.IsAppearGhost;
    }
}
