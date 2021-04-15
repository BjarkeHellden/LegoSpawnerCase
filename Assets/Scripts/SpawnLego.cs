using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLego : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int maxSize;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public Transform [] possiblePositions;
    public int positionSelect = 0;
    private int deactivateCounterLast = 0;
    private int deactivateCounterFirst = 0;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.maxSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public void SpawnFromPool(string tag, Color color)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.parent = transform;
        objectToSpawn.transform.position = possiblePositions[positionSelect].position;
        objectToSpawn.transform.rotation = Quaternion.identity;
        objectToSpawn.GetComponent<Renderer>().material.color = color;
        poolDictionary[tag].Enqueue(objectToSpawn);
        positionSelect++;
        if (positionSelect > possiblePositions.Length - 1)
        {
            positionSelect = 0;
        }
        deactivateCounterLast = 0;
    }

    public void ClearLegos()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void DeactivateLastLego()
    {
        if(transform.childCount > 0)
        {
            if (transform.childCount - 1 - deactivateCounterLast < 0)
            {
                deactivateCounterLast = 0;
            }
            transform.GetChild(transform.childCount - 1 - deactivateCounterLast).gameObject.SetActive(false);
            deactivateCounterLast++;
        }
    }

    public void DeactivateFirstLego()
    {
        if (transform.childCount > 0)
        {
            if (deactivateCounterFirst > transform.childCount - 1)
            {
                deactivateCounterFirst = 0;
            }
            transform.GetChild(deactivateCounterFirst).gameObject.SetActive(false);
            deactivateCounterFirst++;
        }
    }

    private Vector3 positionSelector(int posSelect)
    {
        Vector3 pos;
        switch (posSelect)
        {
            case 0:
                return pos = new Vector3(-3f, 6f, 0f);
            case 1:
                return pos = new Vector3(0.2f, 6f, 0f);
            case 2:
                return pos = new Vector3(3.4f, 6f, 0f);
            case 3:
                return pos = new Vector3(6.6f, 6f, 0f);
            case 4:
                return pos = new Vector3(9.8f, 6f, 0f);
            default:
                return pos = new Vector3(-3f, 6f, 0f);
        }
    }
}
