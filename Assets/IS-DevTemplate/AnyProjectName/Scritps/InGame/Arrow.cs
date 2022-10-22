using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private int _speed;

    private Rigidbody2D _rb;

    private void Update()
    {
        _rb.AddForce(new Vector2(_speed, 0), ForceMode2D.Impulse);
    }
}
