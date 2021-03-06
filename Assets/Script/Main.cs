using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    GameObjectPool objectPool;
    public Object prefab;
    private List<GameObject> loadedObjects;
    private void Awake()
    {
        objectPool = new GameObjectPool();
        objectPool.InitData(prefab, 15) ;
        loadedObjects = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (loadedObjects.Count < 10.0f)
            {
                GameObject thing = objectPool.LoadData();
                thing.SetActive(true);
                thing.transform.position = new Vector3(-25.0f, 0f, -25.0f);
                loadedObjects.Add(thing);
            }
            else
            {
                Debug.Log("???F");
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
           
            if(loadedObjects.Count>0)
            {
                GameObject thing = loadedObjects[loadedObjects.Count-1];
                objectPool.UnLoadData(thing);
                loadedObjects.RemoveAt(loadedObjects.Count-1);
            }
        }

    }
}
