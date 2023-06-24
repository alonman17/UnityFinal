using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;
    public float minThrust = 0.1f, maxThrust = 1;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    void Update()
    {
        
        
        transform.Translate(Vector3.forward * Random.Range(minThrust, maxThrust) * Time.deltaTime);
        
    }
}