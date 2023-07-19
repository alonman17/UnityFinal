using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Instructions : MonoBehaviour
{

    public TMP_Text instructions;

    //remove the instructions after 5 seconds

    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(10, instructions));
    }

    IEnumerator RemoveAfterSeconds(int seconds, TMP_Text instructions)
    {
        yield return new WaitForSeconds(seconds);
        instructions.text = "";
    }
    
}
