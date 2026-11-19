using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fadescript : MonoBehaviour
{
    public Image BlackFade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BlackFade.canvasRenderer.SetAlpha(1.0f);
        fadeOut();
    }

    // Update is called once per frame
    void fadeOut()
    {
        BlackFade.CrossFadeAlpha(0, 5, false);
    }
}
