using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DonutSpawnerScript : MonoBehaviour
{
    public GameObject[] donutPrefabs;
    public float spawnInterval = 1.0f;
    float maxPos, minPos;
    Transform bakeryTransf;

    private void Start()
    {
        bakeryTransf = GetComponent<Transform>();

    }

    public void Bake(Boolean state)
    {
        if (state == true)
            StartCoroutine(Spawn());
        else
            StopAllCoroutines();
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            minPos = bakeryTransf.position.x-40;
            maxPos = bakeryTransf.position.x + 40;
            var value = UnityEngine.Random.Range(minPos, maxPos);
            var pos = new Vector2(value, transform.position.y);
            GameObject donut = Instantiate(donutPrefabs[UnityEngine.Random.Range(0, donutPrefabs.Length)], 
                pos, Quaternion.identity, bakeryTransf);
            yield return new WaitForSeconds(spawnInterval); 
        }
    }
}
