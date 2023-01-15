using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyObjectPool : MonoBehaviour
{
    public static EasyObjectPool SharedInstance;
    [SerializeField]
    List<ObjectLibrary> objectLibrary;
    private GameObject[][] objects;
    private int[][] counterObjects;
    private int[] counter;
    private void Awake() {
        SharedInstance = this;
    }
    private void Start() {
        objects = new GameObject[objectLibrary.Count][];
        counterObjects = new int [objectLibrary.Count][];
        counter = new int[objectLibrary.Count];
        for (int i = 0; i < objectLibrary.Count; i++)
        {
            int c = 0;
            GameObject[] tmp = new GameObject[objectLibrary[i].totalObjects];
            int[] ctmp = new int[objectLibrary[i].totalObjects];
            for (int j = 0; j < objectLibrary[i].totalObjects; j++)
            {
                tmp[j] = Instantiate(objectLibrary[i].objectPrefab);
                ctmp[j] = c;
                c = c+1;
            }
            objects[i] = tmp;
            counterObjects[i] = ctmp;
            counter[i] = 0;
        }
    }
    public GameObject GetPooledObject(int id)
    {
        if(counter[id]== counterObjects[id].Length-1)
        {
            resetList(id);
        }
        counter[id] = counter[id]+1;
        return objects[id][counterObjects[id][counter[id]]];
    }
    void resetList(int id)
    {
        counter[id]=0;
        int tmp = 0;
        for (int i = 0; i < objects[id].Length; i++)
        {
            if(!objects[id][i].activeInHierarchy)
            {
                tmp = tmp + 1;
            }
        }
        int[] ctmp = new int[tmp];
        for (int i = 0; i < objects[id].Length; i++)
        {
            if(!objects[id][i].activeInHierarchy)
            {
                counterObjects[id][i] = i;
            }
        }
    }
    public void disableObjects(int id)
    {
        counter[id]=0;
        int tmp = 0;
        for (int i = 0; i < objects[id].Length; i++)
        {
            if(objects[id][i].activeInHierarchy)
            {
                objects[id][i].SetActive(false);
                tmp = ++tmp;
            }
        }
        int[] ctmp = new int[tmp];
        for (int i = 0; i < objects[id].Length; i++)
        {
            if(!objects[id][i].activeInHierarchy)
            {
                counterObjects[id][i] = i;
            }
        }
    }
    public void disableAllObjects()
    {
        for (int id = 0; id < objectLibrary.Count; id++)
        {
            counter[id]=0;
            int tmp = 0;
            for (int i = 0; i < objects[id].Length; i++)
            {
                if(objects[id][i].activeInHierarchy)
                {
                    objects[id][i].SetActive(false);
                    tmp = ++tmp;
                }
            }
            int[] ctmp = new int[tmp];
            for (int i = 0; i < objects[id].Length; i++)
            {
                if(!objects[id][i].activeInHierarchy)
                {
                    counterObjects[id][i] = i;
                }
            }
        }
    }
}
[System.Serializable]
public class ObjectLibrary
{
    public int id;
    public string objectName;
    public GameObject objectPrefab;
    public int totalObjects;
}

