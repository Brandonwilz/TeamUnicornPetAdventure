using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkElementsSpawnSystem : MonoBehaviour
{
    [SerializeField] private float moveOffset = 19f;
    [SerializeField] private GameObject previousChunk;
    [SerializeField] private GameObject speedObstacle;
    [SerializeField] private GameObject speedBooster;
    [SerializeField] private GameObject damageObstacle;
    [SerializeField] private Environment environment;
    [SerializeField] private List<GameObject> LeftBuildings;
    [SerializeField] private List<GameObject> MiddleBuildings;
    [SerializeField] private List<GameObject> RightBuildings;

    private List<List<GameObject>> Buildings = new List<List<GameObject>>();
    private List<GameObject> obstacles = new List<GameObject>();
    private GameObject[] spawnPoints = new GameObject[6];

    void Start()
    {
        SetListOfBuildings();
        ChouseBuildingtoSet();
       // SpawnElements();
    }

    private void SetListOfBuildings()
    {
        Buildings.Add(LeftBuildings);
        Buildings.Add(MiddleBuildings);
        Buildings.Add(RightBuildings);
    }
    private void ChouseBuildingtoSet()
    {
        foreach (var items in Buildings)
        {
            int rNum = Random.Range((int)0, items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                if (i == rNum) items[i].SetActive(true);
                else items[i].SetActive(false);
            }
        }
    }

    private void MoveChunk()
    {
        transform.position = previousChunk.transform.position + new Vector3(moveOffset, 0f, 0f);
        ChouseBuildingtoSet();
        // SpawnElementsAgain();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Movement>())
        {
            MoveChunk();
        }
    }
}
