using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_VFX_Respawner : MonoBehaviour
{
    public Action OnDestroySelf;

    private void OnDestroy()
    {
        OnDestroySelf?.Invoke();
    }
}
