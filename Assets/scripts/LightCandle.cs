using System.Collections;
using UnityEngine;

public class CandleActivator : MonoBehaviour
{
    Light candleLight;
    ParticleSystem[] particleEffects;

    void Start()
    {
        candleLight = GetComponentInChildren<Light>();
        particleEffects = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                StartCoroutine(ToggleCandleWithDelay());
            }
        }
    }

    IEnumerator ToggleCandleWithDelay()
    {
        // Toggle the light
        if (candleLight != null)
        {
            candleLight.enabled = !candleLight.enabled;
        }

        // Toggle each particle effect
        foreach (ParticleSystem particleEffect in particleEffects)
        {
            if (particleEffect != null)
            {
                if (particleEffect.isPlaying)
                {
                    // Stop and immediately clear existing particles
                    particleEffect.Stop(true);
                }
                else
                {
                    // Wait for a short delay before starting the new effect
                    yield return new WaitForSeconds(0.1f);

                    // Start the new effect
                    particleEffect.Play();
                }
            }
        }
    }
}
