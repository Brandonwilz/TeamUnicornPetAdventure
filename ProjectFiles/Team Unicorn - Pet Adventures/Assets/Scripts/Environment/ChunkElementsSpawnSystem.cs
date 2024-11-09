using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkElementsSpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject speedObstacle;
    [SerializeField] private GameObject speedBooster;
    [SerializeField] private GameObject damageObstacle;
    [SerializeField] private Environment environment;

    private List<GameObject> obstacles = new List<GameObject>();

    void Start()
    {
        SpawnElements();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(-0.05f, 0, 0) * environment.chunkMoveSpeed;
    }

    public void SpawnElementsAgain()
    {
        foreach(var element in obstacles)
        {
            Destroy(element);
        }
        obstacles.Clear();
        SpawnElements();
    }

    private void SpawnElements()
    {
        GameObject tempObj;
        foreach (var point in spawnPoints)
        {
            int rNum = Random.Range((int)0, (int)100);

            if (rNum < 25) ;
            else if (rNum >= 25 && rNum < 50)
            {
                tempObj = Instantiate(damageObstacle, point.transform.position, Quaternion.identity, point.transform);
                tempObj.GetComponent<Interactive>().environment = environment;
                obstacles.Add(tempObj);
            }
            else if (rNum >= 50 && rNum < 75)
            {
                tempObj = Instantiate(speedBooster, point.transform.position, Quaternion.identity, point.transform);
                tempObj.GetComponent<Interactive>().environment = environment;
                obstacles.Add(tempObj);
            }
            else
            {
                tempObj = Instantiate(speedObstacle, point.transform.position, Quaternion.identity, point.transform);
                tempObj.GetComponent<Interactive>().environment = environment;
                obstacles.Add(tempObj);
            }
        }
    }

}
