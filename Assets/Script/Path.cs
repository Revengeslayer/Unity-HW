using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject[] wayPoint;
    public float speed;
    private int index =0;

    private void Start()
    {

    }
    private void Update()
    {
        float dic = Vector3.Distance(gameObject.transform.position, wayPoint[index].transform.position);
        if(dic>0.1f && gameObject)
        {
            move();
        }
        else
        {
            if (wayPoint.Length != index+1)
            {
                index += 1;
            }
        }
        
    }
    public void move()
    {
        gameObject.transform.LookAt(wayPoint[index].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward * 4.0f);
    }
}
