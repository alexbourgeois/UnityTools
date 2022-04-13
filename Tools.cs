using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class Tools
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    public static IEnumerator DelayAction(float delay, Action callback = null)
    {
        if (delay <= 0.0f)
            delay = Mathf.Epsilon;

        float currentTime = 0.0f;
        float startTime = Time.time;

        while (currentTime / delay <= 1.0f)
        {
            currentTime += Time.deltaTime;
            yield return waitForFixedUpdate;
        }

        callback?.Invoke();
    }

    public static IEnumerator LerpAlongCurve(Color initialValue, Color finalValue, AnimationCurve curve, float duration, Action<Color> target, Action<bool> animationIndicator = null, Action callback = null)
    {
        float currentTime = 0.0f;
        float startTime = Time.time;

        animationIndicator?.Invoke(true);

        while (currentTime / duration <= 1.0f)
        {
            target(Color.Lerp(initialValue, finalValue, curve.Evaluate(currentTime / duration)));
            currentTime += Time.deltaTime;
            yield return waitForFixedUpdate;
        }

        target(finalValue);

        animationIndicator?.Invoke(false);
        callback?.Invoke();
    }

    public static IEnumerator LerpAlongCurve(Quaternion initialValue, Quaternion finalValue, AnimationCurve curve, float duration, Action<Quaternion> target, Action<bool> animationIndicator = null, Action callback = null)
    {
        float currentTime = 0.0f;
        float startTime = Time.time;

        animationIndicator?.Invoke(true);

        while (currentTime / duration <= 1.0f)
        {
            target(Quaternion.Lerp(initialValue, finalValue, curve.Evaluate(currentTime / duration)));
            currentTime += Time.deltaTime;
            yield return waitForFixedUpdate;
        }

        target(finalValue);

        animationIndicator?.Invoke(false);
        callback?.Invoke();
    }

    public static IEnumerator LerpAlongCurve(Vector3 initialValue, Vector3 finalValue, AnimationCurve curve, float duration, Action<Vector3> target, Action<bool> animationIndicator = null, Action callback = null)
    {
        float currentTime = 0.0f;
        float startTime = Time.time;

        animationIndicator?.Invoke(true);

        while (currentTime / duration <= 1.0f)
        {
            target(Vector3.Lerp(initialValue, finalValue, curve.Evaluate(currentTime / duration)));
            currentTime += Time.deltaTime;
            yield return waitForFixedUpdate;
        }

        target(finalValue);

        animationIndicator?.Invoke(false);
        callback?.Invoke();
    }

    public static IEnumerator LerpAlongCurve(float initialValue, float finalValue, AnimationCurve curve, float duration, Action<float> target, Action<bool> animationIndicator = null, Action callback = null)
    {
        float currentTime = 0.0f;
        float startTime = Time.time;

        animationIndicator?.Invoke(true);

        while (currentTime / duration <= 1.0f)
        {
            target(Mathf.Lerp(initialValue, finalValue, curve.Evaluate(currentTime / duration)));
            currentTime += Time.deltaTime;
            yield return waitForFixedUpdate;
        }

        target(finalValue);

        animationIndicator?.Invoke(false);
        callback?.Invoke();
    }
}
