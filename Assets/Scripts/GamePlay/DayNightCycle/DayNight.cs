using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    public Light2D lightSource;
    public AnimationCurve changeCurve;
    public float defaultIntensity = 0.5f;
    public float maxIntensity = 1f;
    public float minIntensity = 0.1f;
    public Cycle nextCycle = Cycle.day;
    public UnityEvent onFinished = new UnityEvent();


    private void Start()
    {
        onFinished.AddListener(() => { SimulateNext(); });
        SimulateNext();
    }
    private IEnumerator SimulateChange(float targetIntensity, float time)
    {
        for (float timeSpent = 0f; timeSpent < time; timeSpent += Time.deltaTime)
        {
            lightSource.intensity = Mathf.Lerp
                (defaultIntensity,
                targetIntensity,
                changeCurve.Evaluate(timeSpent / time));

            yield return null;
        }

        lightSource.intensity = defaultIntensity;
        onFinished.Invoke();
    }

    public void SimulateNext(float time = 60f)
    {
        if(nextCycle == Cycle.day)
        {
            StartCoroutine(SimulateChange(maxIntensity, time));
            nextCycle = Cycle.night;
        }
        else
        {
            StartCoroutine(SimulateChange(minIntensity, time));
            nextCycle = Cycle.day;
        }
    }
    
    public enum Cycle
    {
        day,
        night
    }
}
