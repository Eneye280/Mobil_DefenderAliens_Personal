using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private int maxSpawnEnemies;
    [SerializeField] private GameObject prefabEnemies;
    [SerializeField] private Transform[] positionSpwan;
    [SerializeField] private List<GameObject> listEnemies;
    private GameObject refPrefabEnemie;

    private void Start()
    {
        InitiliazeSpwan();
        CallSpwanEnemie();
    }

    private void InitiliazeSpwan()
    {
        for (int i = 0; i < maxSpawnEnemies; i++)
        {
            SpawnEnemie(); 
        }
    }

    private void SpawnEnemie()
    {
        refPrefabEnemie = Instantiate(prefabEnemies);
        AddParentSpawnEnemies();
        listEnemies.Add(refPrefabEnemie);

        for (int i = 0; i < listEnemies.Count; i++)
        {
            listEnemies[i].SetActive(false);
        }
    }

    private void AddParentSpawnEnemies() => refPrefabEnemie.transform.SetParent(transform);

    private void CallSpwanEnemie()
    {
        for (int i = 0; i < listEnemies.Count; i++)
        {
            if(!listEnemies[i].activeInHierarchy)
            {
                listEnemies[i].SetActive(true);
                AddPositionSpawnEnemie();
            }
        }
    }

    private void AddPositionSpawnEnemie()
    {
        for (int i = 0; i < listEnemies.Count; i++)
        {
            listEnemies[i].transform.position = positionSpwan[Random.Range(0, positionSpwan.Length)].position;
        }
    }
}
