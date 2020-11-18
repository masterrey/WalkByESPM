using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
public class PostControl : MonoBehaviour
{

    public Volume volume;
    ColorAdjustments colora;
    float timeto = 0;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out colora);
        StartCoroutine(FadeIn());
    }

   IEnumerator Fadeout()
    {
        float timeto = 0;
        while (timeto < 1)
        {
            timeto += Time.deltaTime / 10;
            colora.colorFilter.Interp(colora.colorFilter.GetValue<Color>(), Color.black, timeto);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeIn()
    {
        float timeto = 0;
        while (timeto < 1)
        {
            timeto += Time.deltaTime / 10;
            colora.colorFilter.Interp(colora.colorFilter.GetValue<Color>(), Color.white, timeto);
            yield return new WaitForEndOfFrame();
        }
    }
}
