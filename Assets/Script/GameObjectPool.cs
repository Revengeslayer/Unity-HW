using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameObjectPool                 //  singleton 的class
{
    public class ObjectData                 // 物件的資訊 1物件 2有沒有被使用
    {
        public GameObject thing;
        public bool isUsing;
    }

    private static GameObjectPool instance; //  要singleton的變數
    private List<ObjectData> currentData;   //  目前有哪些 ObjectData型態的 資料

    public  GameObjectPool()                //  建構子 
    {
        instance =this ;
    }

    public static GameObjectPool Instance() // 回傳instance
    {
        return instance;
    }

    public void InitData(Object prefab, int count)  //初始化資料
    {
        currentData = new List<ObjectData>();  //開個容器裝資料

        for (int i=0; i< count; i++)
        {
            //Instantiate(perfab) 將perfab內的資料複製一份 並回傳
            // GameObject.Instantiate(perfab) 回傳一個 Object 型態
            GameObject thing = GameObject.Instantiate(prefab) as GameObject;
            thing.SetActive(false);         //是否顯示物件
            ObjectData data = new ObjectData();     //設個暫存將資料存入
            data.isUsing = false;
            data.thing = thing;
            currentData.Add(data);          //把資料存入容器內
        }      
    }

    public GameObject LoadData()                    
    {
        GameObject res = null ;                     //顯示物件
        for(int i=0; i< currentData.Count; i++)     
        {
            if (currentData[i].isUsing==false)      
            {
                res = currentData[i].thing;
                currentData[i].isUsing = true;
                break;
            }
        }
        return res;
    }

    public void UnLoadData(GameObject thing)       //收回物件
    {
        for(int i=0; i< currentData.Count; i++)
        {
            if(currentData[i].thing==thing)
            {
                currentData[i].thing.SetActive(false);
                currentData[i].isUsing = false;
                break;
            }
        }
    }
}
