using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    [SerializeField] Image[] splatterImages;
    float impactTime = 2.0f;

    int lastSplat = -1;

    void Start()
    {
        foreach (Image splat in splatterImages)
        {
            splat.enabled = false;
        }
    }

    public void ShowDamageUI()
    {
        int randomNum = GetRandomSplat();

        while (randomNum == lastSplat) {
            randomNum = GetRandomSplat();
        }

        lastSplat = randomNum;
        Image splat = splatterImages[randomNum];
        StartCoroutine(FadeImage(splat, 1.0f, 0.0f, impactTime));
    }

    private int GetRandomSplat()
    {
        return UnityEngine.Random.Range(0, splatterImages.Length + 1);
    }

    public static IEnumerator FadeImage(Image image, float startAlpha, float endAlpha, float duration)
    {
        image.enabled = true;
        Color tempColor = image.color;
        tempColor.a = startAlpha;
        image.color = tempColor;

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
        tempColor.a = endAlpha; 
        image.enabled = false;
    }
}
