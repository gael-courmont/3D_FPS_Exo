using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private Bounds SpawnBounds;
    [SerializeField] private GameObject TargetPrefab = default;
    [SerializeField] private float spawnSpeed = 1f;
    [SerializeField] private Transform TargetParent= default;
    [SerializeField] private BoxCollider spawnzone = default;

    private bool StartSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        StartSpawn = false;
        SpawnBounds = spawnzone.bounds;
        startSpawning();
    }
    
    public void startSpawning()
    {
        if (!StartSpawn)
        {
            StartCoroutine(Spawns());
            StartSpawn = true;
        }
    }

    private IEnumerator Spawns()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f / spawnSpeed);
            GameObject Poulet =Instantiate(TargetPrefab, GetRandomSpawnPos(), Quaternion.identity, TargetParent) as GameObject;
            GameObject Player= GameObject.Find("Player");
            Poulet.transform.LookAt(Player.transform);
            
        }
    }
    // Update is called once per frame

    private Vector3 GetRandomSpawnPos()
    {
        return new Vector3(
            Random.Range(SpawnBounds.min.x, SpawnBounds.max.x),
            Random.Range(SpawnBounds.min.y, SpawnBounds.max.y),
            Random.Range(SpawnBounds.min.z, SpawnBounds.max.z));
    }


}
