using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public GameObject[] item; //2중 포문접근
    public float spawnTime = 2.0f;
    float deltaSpawnTime = 0.0f;
    //float itemCount = 0.0f;
    //public float itemCountMax = 3.0f;
    const int MAX_ITEM_SIZE = 9;
    //Pooling 사용
    GameObject[] itemPool = null;
    
    public int poolSize = MAX_ITEM_SIZE;

    void Start()
    {
        int i = 0;
        itemPool = new GameObject[poolSize];
        for (int j = 0; j < item.Length; j++)
        {   
            for(int k=0; k<item.Length; k++)
            {
                itemPool[i] = Instantiate(item[j]) as GameObject;
                itemPool[i].name = "item_0" + j + "-" + +i;
                itemPool[i].SetActive(false);
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        deltaSpawnTime += Time.deltaTime;
        //if (deltaSpawnTime > spawnTime && itemCount < itemCountMax)//Pooling 사용 전 몬스터 갯수 제한
        if (deltaSpawnTime > spawnTime)
        {
            //itemCount++;
            deltaSpawnTime = 0.0f;
            //GameObject itemObj = Instantiate(item) as GameObject;
            
                for (int i = 0; i < poolSize; i++)
                {
                    GameObject itemObj = itemPool[i];
                    if (itemObj.activeSelf == true)
                        continue;
                    itemObj.SetActive(true);
                    float x = Random.Range(-3.5f, 3.5f);
                    float z = Random.Range(-3.5f, 3.5f);
                    itemObj.transform.position = new Vector3(x, 0.0f, z);
                    //break;
                }
            
        }
    }
}
