using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Sight : MonoBehaviour
{
    public bool IsAppearGhost => _isAppearGhost;

    [SerializeField]
    [Tag]
    private string _playerTag;

    private bool _isAppearGhost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GhostCheck(collision, true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ghost ghost))
        {
            if (!ghost.IsGhostMode)
            {
                _isAppearGhost = true;
            }
            else
            {
                _isAppearGhost = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GhostCheck(collision, false);
    }

    /// <summary>
    /// Ghostが見えているか判定する関数
    /// OnTriggerEnterのときはtrueを設定
    /// OnTriggerExitのときはfalseを設定する
    /// </summary>
    /// <param name="collider"></param>
    /// <param name="isEnter"></param>
    private void GhostCheck(Collider2D collider, bool isEnter)
    {
        if (collider.TryGetComponent(out Ghost ghost))
        {
            if(!ghost.IsGhostMode)// Ghostが可視状態なら
            {
                _isAppearGhost = isEnter;
            }
        }
    }
}
