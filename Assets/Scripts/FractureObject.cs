    using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FractureObject : MonoBehaviour
{

    public GameObject fracturePrefab;
    public GameObject OriginalObject;

    public GameObject optinalItem;
    public float explosionMinForce = 0.1f;
    public float explosionMaxForce = 1f;
    public float explosionRadius = 20f;

    private GameObject fracture;

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Bullet"){
            //
            Explode(collision);
        }
    }

    void Explode(Collision collision){
        OriginalObject.SetActive(false);
        fracture = Instantiate(fracturePrefab, transform.position, transform.rotation) as GameObject;
        foreach (Transform child in fracture.transform){
            
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if(rb != null){
               //add normal force
               rb.AddExplosionForce(Random.Range(explosionMinForce, explosionMaxForce), collision.contacts[0].point, explosionRadius);
            }
       



            
            StartCoroutine(Shrink(child,2f));
        }
        if(optinalItem != null){
            Instantiate(optinalItem, transform.position, transform.rotation);
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
