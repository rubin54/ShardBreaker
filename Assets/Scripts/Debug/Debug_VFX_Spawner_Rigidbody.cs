using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_VFX_Spawner_Rigidbody : Debug_VFX_Spawner
{
    public Vector3 offset = Vector3.up;
    internal override IEnumerator Spawn(Transform spawnTransform)
    {
        yield return new WaitForSeconds(spawnDelay);

        //changed to spawnTrans rotation
        GameObject go = Instantiate(prefab, spawnTransform.position + offset, spawnTransform.rotation, gameObject.transform);
        if (autokill)
        {
            Destroy(go, killDelay);
        }

        Debug_VFX_Respawner respawn = go.AddComponent<Debug_VFX_Respawner>();
        respawn.OnDestroySelf = () => Respawn(spawnTransform);
    }

#if UNITY_EDITOR
    internal override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.cyan;
        foreach (Transform spawnTransform in spawnPositions)
        {
            if (spawnTransform != null)
            {
                Gizmos.DrawRay(spawnTransform.position + offset, spawnTransform.forward);
            }
        }
    }
#endif
}
