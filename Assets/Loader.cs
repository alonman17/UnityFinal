using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame

    // public void LoadScene(int sceneIndex)
    // {
    //     _loadingScreen.SetActive(true);
    //     StartCoroutine(LoadAsynchronously(sceneIndex));
    // }

    // IEnumerator LoadAsynchronously(int sceneIndex)
    // {
    //     // load scene in background with at least 5 seconds of loading screen
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    //     // operation.allowSceneActivation = false;
    //     // float timer = 0.0f;
    //     // while(!operation.isDone)
    //     // {
    //     //     timer += Time.deltaTime;
    //     //     _slider.value = Mathf.Clamp01(timer / 5.0f);
    //     //     if(timer >= 5.0f)
    //     //     {
    //     //         operation.allowSceneActivation = true;
    //     //     }
    //     //     yield return null;
    //     // }
    // }
}
