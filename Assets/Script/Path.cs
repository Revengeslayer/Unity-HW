using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private static GameObject[] wayPoint;
    public float speed;
    private int index=1;
    private static GameObjectPool objectPool;
    private static List<GameObject> loadedObjects;

    private void Awake()
    {
        index = 1;
    }
    private void Start()
    {
    }
    private void OnEnable()
    {
        Awake();
    }
    private void Update()
    {
        float dic = Vector3.Distance(gameObject.transform.position, wayPoint[index].transform.position);

        if (dic>0.1f*(speed/10.0f) )
        {
            Move();
        }
        else 
        {
            if (wayPoint.Length != index + 1)
            {
                index += 1;
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward * 4.0f);
    }
    public static void SetData(PoolData data )
    {
        objectPool = data.objectPool;
        loadedObjects = data.loadedObjects;

    }

    public void Move()
    {      
        gameObject.transform.LookAt(wayPoint[index].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        
    }
    public static void LoadRes()
    {

        wayPoint = new GameObject[6];
        int count = 0;
        Object[] prefabs = Resources.LoadAll("Prefebs/Terrain");
        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject a = GameObject.Instantiate(prefabs[i]) as GameObject;

            if (a.tag == "WayPoint")
            {
                wayPoint[count] = a;
                count++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        objectPool.UnLoadData(gameObject);
        loadedObjects.Remove(gameObject);
    }
}
