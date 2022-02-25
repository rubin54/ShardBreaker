using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_VFX_Spawner : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject prefab;
    [Range(0, 10)]
    public float spawnDelay = 0;
    public Transform[] spawnPositions;
    [Header("Destroy")]
    public bool autokill = true;
    [Range(0, 10)]
    public float killDelay = 3;


    void Start()
    {
        foreach (Transform spawnTransform in spawnPositions)
        {
            Respawn(spawnTransform);
        }
    }

    internal virtual IEnumerator Spawn(Transform spawnTransform)
    {
        yield return new WaitForSeconds(spawnDelay);

        GameObject go = Instantiate(prefab, spawnTransform.position, Quaternion.identity, gameObject.transform);
        if (autokill)
        {
            Destroy(go, killDelay);
        }

        Debug_VFX_Respawner respawn = go.AddComponent<Debug_VFX_Respawner>();
        respawn.OnDestroySelf = () => Respawn(spawnTransform);
    }

    public void Respawn(Transform spawnTransform)
    {
        if (spawnTransform == null) return;

        StartCoroutine(Spawn(spawnTransform));
    }

#if UNITY_EDITOR
    internal virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        foreach (Transform spawnTransform in spawnPositions)
        {
            if(spawnTransform != null) 
            {
                Gizmos.DrawWireCube(spawnTransform.position + Vector3.up * 0.5f, new Vector3(0.3f, 1, 0.3f));
            }
        }
    }
#endif
}
