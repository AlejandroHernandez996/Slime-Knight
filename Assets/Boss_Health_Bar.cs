// Health_Bar_Script
// Shows what health you are with a bar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health_Bar : MonoBehaviour
{

    public GameObject boss;

    // Update is called once per frame
    void Update()
    {

        // Width is the percentage of health you are at
        float width = (float)boss.GetComponent<Enemy_Manager>().health / (float)boss.GetComponent<Enemy_Manager>().GetMaxHealth() * 500.0f;
        RectTransform imageRect = GetComponent<Image>().rectTransform.transform as RectTransform;
        // Set bar to width
        imageRect.sizeDelta = new Vector2(width, imageRect.sizeDelta.y);

    }
}
