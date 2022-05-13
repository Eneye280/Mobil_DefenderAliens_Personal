using System.Collections.Generic;
using UnityEngine;

public class ManagerPool : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private bool isSpawn;
    [SerializeField] private bool isRepeatingwithTime;
    [SerializeField] private int timeRepeating;
    [SerializeField] private int maxSpawn;

    [Header("Parameters")]
    [SerializeField] private GameObject prefabPool;
    [SerializeField] private Transform[] positionPool;
    [SerializeField] private List<GameObject> listPool;

    private GameObject refPrefabPool;

    private void Start()
    {
        InitiliazeSpwan();

        if (isSpawn && !isRepeatingwithTime)
        {
            CallSpwan(); 
        }

        if(isRepeatingwithTime)
        {
            InvokeRepeating(nameof(RepeatingBullet), 1f, timeRepeating);
        }
    }

    private void InitiliazeSpwan()
    {
        for (int i = 0; i < maxSpawn; i++)
        {
            Spawn(); 
        }
    }

    private void Spawn()
    {
        refPrefabPool = Instantiate(prefabPool);
        AddParentSpawn();
        listPool.Add(refPrefabPool);

        for (int i = 0; i < listPool.Count; i++)
        {
            listPool[i].SetActive(false);
        }
    }

    private void AddParentSpawn() => refPrefabPool.transform.SetParent(transform);

    private void CallSpwan()
    {
        for (int i = 0; i < listPool.Count; i++)
        {
            if(!listPool[i].activeInHierarchy)
            {
                listPool[i].SetActive(true);
                AddPositionSpawn();
            }
        }
    }

    private void RepeatingBullet() => CallSpwan();

    private void AddPositionSpawn()
    {
        for (int i = 0; i < listPool.Count; i++)
        {
            listPool[i].transform.position = positionPool[Random.Range(0, positionPool.Length)].position;
        }
    }
}
