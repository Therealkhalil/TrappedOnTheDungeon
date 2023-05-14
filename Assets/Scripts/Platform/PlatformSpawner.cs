using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;
    private float[] offset_X = { 1.31f, -1.31f };
    private float timer;
    [SerializeField] private float spanwTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spanwTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        var randomNumber = Random.Range(0, 3);
        var randomOffset = Random.Range(0, 2);
        Vector3 placement = new Vector3(offset_X[randomOffset], transform.position.y,transform.position.z);
        Instantiate(platform[0],placement,Quaternion.identity);
    }
}
