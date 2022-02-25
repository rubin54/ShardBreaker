using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Debug_VFX_Spawner_StressTest : Debug_VFX_Spawner
{
    [Range(1,1000)]
    public int spawnPerSecond = 20;
    public Vector3 bounds = Vector3.up;
    float time = 0;

    internal override IEnumerator Spawn(Transform spawnTransform)
    {
        yield return new WaitForSeconds(spawnDelay);

        Vector3 randomSpawnPosition;

        Vector3 boundsHalf = bounds * 0.5f;
        randomSpawnPosition = transform.position 
                                + new Vector3(0, bounds.y * 0.5f, 0) 
                                + new Vector3(  Random.Range(-boundsHalf.x, boundsHalf.x), 
                                                Random.Range(-boundsHalf.y, boundsHalf.y),
                                                Random.Range(-boundsHalf.z, boundsHalf.z));
        GameObject go = Instantiate(prefab, randomSpawnPosition, Quaternion.identity, gameObject.transform);

        if (autokill)
        {
            Destroy(go, killDelay);
        }
    }

    private void Update()
    {
        if(time >= 1 / spawnPerSecond)
        {
            StartCoroutine(Spawn(transform));
            time = 0;
        }

        time += Time.deltaTime;
    }


#if UNITY_EDITOR
    internal override void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,0,0.2f);
        Gizmos.DrawCube(transform.position + new Vector3(0, bounds.y * 0.5f, 0), bounds);
    }
#endif

}
