using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropmap : MonoBehaviour, IGimmick
{
    public void OnGimmick()
    {
        gameObject.SetActive(false);
    }
}
