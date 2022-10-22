using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRain : MonoBehaviour, IGimmick
{
    public void OnGimmick()
    {
        gameObject.SetActive(true);
    }
}
