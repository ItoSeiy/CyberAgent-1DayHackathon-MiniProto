using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GimmickButton : MonoBehaviour
{
    [SerializeField]
    [Header("作用するオブジェクト")]
    private GameObject _object;

    [SerializeField]
    [Tag]
    private string _playerTag = "Player";

    [SerializeField]
    Sprite _sprite;

    private bool _isPushed = false;
    private bool _canPush = false;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isPushed || !_canPush) return;
        if(Input.GetKeyDown(KeyCode.F))
        {
            OnPush();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            _canPush = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _canPush = false;
    }

    private void OnPush()
    {
        if(_object.TryGetComponent(out IGimmick gimmick))
        {
            gimmick.OnGimmick();
            _isPushed = true;
            _spriteRenderer.sprite = _sprite;
        }
    }
}
