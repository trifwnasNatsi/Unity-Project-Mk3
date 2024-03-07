using System.Collections;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 2f; // Time between spawns
    public int spawnLimit = 5;
    public int level = 1;
    public int waitForNextLevel=10;
    public bool isLevelComplete;
    private int spawnedCount;
    private bool isSpawning=true;
    public Vector3 center;
    public Vector3 size;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (spawnedCount < spawnLimit)
        {
            if (isSpawning)
            {
                Vector3 randomSpawnPosition = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
                enemyPrefab.SetActive(true);
                Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
                spawnedCount++;
                yield return new WaitForSeconds(spawnTime);

            }

            

            if (spawnedCount == spawnLimit)
            {
                isLevelComplete = true;
                Debug.Log("level complete");
                yield return new WaitUntil(() => AllEnemiesDead());
                Debug.Log("All enemies are dead");
                yield return new WaitForSeconds(waitForNextLevel);
                goNextLevel();
            }
        }
    }
    bool AllEnemiesDead()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int aliveCount = 0;

        foreach (var enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                aliveCount++;

                // You can break the loop if you only want to check the status of the first active enemy
                // break;
            }
        }

        return aliveCount <= 1; // Returns true if there's at most one enemy alive
    }
    public void goNextLevel()
    {
        level++;
        spawnedCount = 0;
        spawnLimit = spawnLimit * level;
        Debug.Log("Reached level " + level);
        if (spawnTime != 1) spawnTime = spawnTime / level;
        isLevelComplete = false;
    }
    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    } 

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }


}












/*using System.Collections;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; // Time between spawns
    public int spawnLimit = 5;
    public int level = 1;
    public int waitForNextLevel = 10;
    public bool isLevelComplete;
    public Vector3 center;
    public Vector3 size;

    private int spawnedCount;
    private bool isSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (spawnedCount < spawnLimit)
        {
            if (isSpawning)
            {
                Vector3 randomSpawnPosition = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
                enemyPrefab.SetActive(true);
                Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
                spawnedCount++;
            }

            yield return new WaitForSeconds(spawnInterval);

            if (spawnedCount == spawnLimit)
            {
                isLevelComplete = true;
                yield return new WaitUntil(() => AllEnemiesDead());
                Debug.Log("All enemies are dead");
                goNextLevel();
            }
        }
    }

    bool AllEnemiesDead()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                return false; // At least one enemy is still alive
            }
        }
        return true; // All enemies are dead
    }

    public void goNextLevel()
    {
        level++;
        spawnedCount = 0;
        spawnLimit = spawnLimit * level;
        Debug.Log("Reached level " + level);
        if (spawnInterval != 1) spawnInterval = spawnInterval / level;
        isLevelComplete = false;
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}















IEnumerator SpawnEnemies()
    {
        while (spawnedCount < spawnLimit)
        {
            if (isSpawning)
            {
                Vector3 randomSpawnPosition = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
                enemyPrefab.SetActive(true);
                Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
                spawnedCount++;
                Debug.Log("Enemy spawned at: " + randomSpawnPosition);
            }

            yield return new WaitForSeconds(spawnTime);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (spawnedCount == spawnLimit)
            {
                isLevelComplete = true;
                Debug.Log("Level complete!");

                // Restart the loop
                continue;
            }

            if (enemies.Length == 1 && isLevelComplete)
            {
                Debug.Log("All enemies are dead");
                goNextLevel();
                yield return new WaitForSeconds(waitForNextLevel);
            }
        }
    }
*/
