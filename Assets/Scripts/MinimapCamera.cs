using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
      bool doWeHaveFogInScene;


    // Start is called before the first frame update
    void Start()
    {
        doWeHaveFogInScene = RenderSettings.fog;
    }

    // Update is called once per frame
    private void OnPreRender() {
        RenderSettings.fog = false;
    }
    private void OnPostRender() {
        RenderSettings.fog = doWeHaveFogInScene;
    }
}
