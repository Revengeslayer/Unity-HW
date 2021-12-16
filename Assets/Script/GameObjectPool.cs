using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameObjectPool                 //  singleton ��class
{
    public class ObjectData                 // ���󪺸�T 1���� 2���S���Q�ϥ�
    {
        public GameObject thing;
        public bool isUsing;
    }

    private static GameObjectPool instance; //  �nsingleton���ܼ�
    private List<ObjectData> currentData;   //  �ثe������ ObjectData���A�� ���

    public  GameObjectPool()                //  �غc�l 
    {
        instance =this ;
    }

    public static GameObjectPool Instance() // �^��instance
    {
        return instance;
    }

    public void InitData(Object prefab, int count)  //��l�Ƹ��
    {
        currentData = new List<ObjectData>();  //�}�Ӯe���˸��

        for (int i=0; i< count; i++)
        {
            //Instantiate(perfab) �Nperfab������ƽƻs�@�� �æ^��
            // GameObject.Instantiate(perfab) �^�Ǥ@�� Object ���A
            GameObject thing = GameObject.Instantiate(prefab) as GameObject;
            thing.SetActive(false);         //�O�_��ܪ���
            ObjectData data = new ObjectData();     //�]�ӼȦs�N��Ʀs�J
            data.isUsing = false;
            data.thing = thing;
            currentData.Add(data);          //���Ʀs�J�e����
        }      
    }

    public GameObject LoadData()                    
    {
        GameObject res = null ;                     //��ܪ���
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

    public void UnLoadData(GameObject thing)       //���^����
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
