using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _walkMan;

    [SerializeField]
    private int _initialHeightValue = -7;

    private void Update()
    {
        transform.position = new Vector3(_walkMan.transform.position.x, _initialHeightValue, 0);
    }
}
