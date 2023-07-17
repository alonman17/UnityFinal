using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FractureObject : MonoBehaviour
{

    public GameObject fracturePrefab;
    public GameObject OriginalObject;

    public float explosionMinForce = 5f;
    public float explosionMaxForce = 100f;
    public float explosionRadius = 20f;

    private GameObject fracture;

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Bullet"){
            Explode();
        }
    }

    void Explode(){
        
        OriginalObject.SetActive(false);
         fracture = Instantiate(fracturePrefab, transform.position, transform.rotation) as GameObject;
        foreach (Transform child in fracture.transform){
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null){
                rb.AddExplosionForce(Random.Range(explosionMinForce, explosionMaxForce), OriginalObject.transform.position, explosionRadius);
            }
            StartCoroutine(Shrink(child,2f));
            // Destroy(child.gameObject, 3f);
        }

        

    }

    IEnumerator Shrink(Transform t,float delay){
        yield return new WaitForSeconds(delay);
        Vector3 newScale = t.localScale;

        while(newScale.x > 0f){
            newScale = Vector3.Lerp(newScale, Vector3.zero, Time.deltaTime);
            t.localScale = newScale;
            yield return new WaitForSeconds(0.05f);
        }

       
    }

}
