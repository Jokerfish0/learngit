using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMake : MonoBehaviour
{
    public static EnemyMake instance;
    private GameObject enemy;
    public float speed;
    Coroutine coroutine;
    private void Awake()
    {
        instance = this;
        enemy = Resources.Load<GameObject>("Prefab/Enemy"); //在文件夹中找到预制体并加载
    }
    public void StartRun()
    {
       coroutine = StartCoroutine(NextOne());
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator  NextOne()
    {
        //y = Random.Range(-15, 20);
        while (true)
        {
            GameObject enemy01 =Instantiate(enemy,this.transform);
            enemy01.transform.position += new Vector3(-1, 0, 0) * speed;
            yield return new WaitForSeconds(2f);  
        }

    }
}
