using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float y;
    public float speed;
    void Start()
    {
        y = Random.Range(-15, 20);
        transform.localPosition = new Vector3(0, y, 0);
        Destroy(gameObject,5);
    }

    void Update()
    {
        transform.position +=new Vector3(speed,0)*Time.deltaTime;
    }
}
