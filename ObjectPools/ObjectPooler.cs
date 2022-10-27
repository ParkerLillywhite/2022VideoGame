using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject placeHolderObject;
    public int poolSize;

    int poolCount;
    void Awake(){
        SharedInstance = this;
        poolCount = pooledObjects.Count;
    }

    void Start(){
        CreateObjectPool(poolSize, placeHolderObject);
    }


    public void CreateObjectPool(int amountToPool, GameObject objectToPool){
        pooledObjects = new List<GameObject>();
        GameObject objectInstance;
        for(int i = 0; i < amountToPool; i++){
            objectInstance = Instantiate(objectToPool);
            objectInstance.SetActive(false);
            pooledObjects.Add(objectInstance);
        } 
    }

    public GameObject GetPooledObject(){
        for(int i = 0; i < poolCount; i++){
            if(!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }
        return null;
    }   
}
