using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Object prefab;
    private Object[] prefabs;
    private GameObjectPool objectPool;
    private List<GameObject> loadedObjects;
    private PoolData data;
    private void Awake()
    {        
        if (SceneManager.GetActiveScene().buildIndex ==1)
        {
            LoadRes();
            objectPool = new GameObjectPool();
            objectPool.InitData(prefab, 15);        
        }
        loadedObjects = new List<GameObject>();
        data = new PoolData();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().buildIndex ==1)
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
                Debug.Log("º¡¤F");
            }
        }
        if (Input.GetMouseButtonDown(1) && SceneManager.GetActiveScene().buildIndex == 1)
        {
           
            if(loadedObjects.Count>0)
            {
                GameObject thing = loadedObjects[loadedObjects.Count-1];
                objectPool.UnLoadData(thing);
                loadedObjects.RemoveAt(loadedObjects.Count-1);
            }
        }
        data.loadedObjects = loadedObjects;
        data.objectPool = objectPool;
        Path.SetData(data);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadRes()
    {
        prefab = Resources.Load("Prefebs/Thing/Capsule");
        prefabs = Resources.LoadAll("Prefebs/Terrain");
        for (int i = 0; i < prefabs.Length; i++)
        {
           GameObject a =  GameObject.Instantiate(prefabs[i]) as GameObject;
        }
    }
}
