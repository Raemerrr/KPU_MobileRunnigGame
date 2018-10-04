using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {

    //private void OnCollisionEnter(Collision other)
    //{
    //    //if (enemyScript.enemyState == EnemyScript.ENEMYSTATE.NONE || enemyScript.enemyState == EnemyScript.ENEMYSTATE.DEAD)
    //    //{
    //    //    //if (enemyScript.enemyState == EnemyScript.ENEMYSTATE.DEAD) {
    //    //    return;
    //    Debug.Log(other);
    //    //}
    //    Debug.Log(other.gameObject.name);
    //    int layerIndex = other.gameObject.layer;
    //    if (LayerMask.LayerToName(layerIndex) == "Item")
    //    {
    //        Debug.Log("Item하고 충돌함");
    //        return;
    //    }
    //    //enemyScript.enemyState = EnemyScript.ENEMYSTATE.DAMAGE;

    //}
    bool isGetItem = false;
    public int score = 10; //개당 점수 몇점을 줄지
    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log(other.gameObject.name);
        if (other.name == "Player") isGetItem = true;
        ScoreManager.Instance().myScore += score;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player") isGetItem = false;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z) && isGetItem == true)
        if (isGetItem == true)
        {
            gameObject.SetActive(false);
            isGetItem = false;
            //   Destroy(gameObject);
        }
    }
}
