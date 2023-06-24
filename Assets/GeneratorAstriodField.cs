using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorAstriodField : MonoBehaviour
{
    public Transform[] astroidPrefab;
    public int fieldRadius = 100;
    public int astroidCount = 100;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < astroidCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * fieldRadius;
            pos.y = Random.Range(-fieldRadius, fieldRadius);
            Transform astroid = Instantiate(astroidPrefab[Random.Range(0, astroidPrefab.Length)], pos, Quaternion.identity);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
