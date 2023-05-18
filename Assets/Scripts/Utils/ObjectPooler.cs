using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;

    #region Singleton
    public static ObjectPooler instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int idPool = 0; idPool < pool.size; idPool++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.m_tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with m_tag " + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    [System.Serializable]
    public class Pool
    {
        public string m_tag;
        public GameObject prefab;
        public int size;
    }

}
