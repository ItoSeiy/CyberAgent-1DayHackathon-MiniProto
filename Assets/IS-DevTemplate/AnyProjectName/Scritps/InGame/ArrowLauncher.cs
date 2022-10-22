using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISDevTemplate.Pool;

public class ArrowLauncher : MonoBehaviour, IGimmick
{
    [SerializeField]
    private ShootType _shootType;

    [SerializeField]
    private int _count;

    [SerializeField]
    private int _interval;

    private int _currentCount;
    private float _timer;
    private bool _stopLauncher = false;

    private enum ShootType
    {
        Count,
        Interval
    }

    private void Awake()
    {
        _currentCount = _count;
        _timer = 0f;
    }

    private void Update()
    {
        if (_stopLauncher) return;
        _timer += Time.deltaTime;
        switch (_shootType)
        {
            case ShootType.Count:
                if (_currentCount <= 0) return;
                Shoot();
                _currentCount--;
                break;
            case ShootType.Interval:
                if (_timer >= _interval)
                {
                    Shoot();
                    _timer = 0f;
                }
                break;
        }
    }

    private void Shoot()
    {
        ObjectPool.Instance.UseObject("Arrow", transform.position).transform.rotation = Quaternion.identity;
    }

    public void OnGimmick()
    {
        _stopLauncher = true;
    }
}
