using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;
    public float minThrust = 5f, maxThrust = 20;

    MeshDestroy meshDestroy;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        meshDestroy = GetComponent<MeshDestroy>();
    }

    void Update()
    {
        
        
        transform.Translate(Vector3.forward * Random.Range(minThrust, maxThrust) * Time.deltaTime);
        
    }

   void onCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
            meshDestroy.DestroyMesh();
    }

    void onTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        meshDestroy.DestroyMesh();
    }
}