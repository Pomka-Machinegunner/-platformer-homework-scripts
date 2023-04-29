using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] Renderer[] _renderer;

    public void BlinkEffectCorutineStart()
    {
        StartCoroutine(BlinkEffect());
    }

    IEnumerator BlinkEffect()
    {
        for (float t = 0f; t < 1f; t += Time.deltaTime * 1f)
        {
            for (int i = 0; i < _renderer.Length; i++)
            {
                for (int w = 0; w < _renderer[i].materials.Length; w++)
                {
                    _renderer[i].materials[w].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30f) * 0.5f + 0.5f, 0, 0, 0));
                }
               
                yield return null;
            }
        }

    }
}
