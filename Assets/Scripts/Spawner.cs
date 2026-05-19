using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject FriendPrefab;
    [SerializeField] private GameObject BabyPrefab;
    
    [SerializeField] private GameObject BigPrefab;

    private float FriendInterval = 3.5f;
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(FriendInterval);

            GameObject prefabToSpawn;

            float roll = Random.value;
                if (roll > 0.75f)
                {
                    prefabToSpawn = FriendPrefab;
                }
                else if (roll > 0.33f)
                {
                    prefabToSpawn = BabyPrefab;
                }
                else
                {
                    prefabToSpawn = BigPrefab;
                }
            
                GameObject newEnemy = Instantiate(
                    prefabToSpawn,
                    new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0),
                    Quaternion.identity
                );
            
            enemies.Add(newEnemy);
        }
		// credits for Modding by kaujakoe for most script lines of the spawner, along with Brackeys for the random enemy spawn
    }
}