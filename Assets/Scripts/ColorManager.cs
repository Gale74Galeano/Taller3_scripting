using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] Color[] colorsArray;
    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    private void OnEnable()
    {
        ClickManager.m_OnButtonClicked += UpdateColor;

    }
    private void OnDisable()
    {
        ClickManager.m_OnButtonClicked -= UpdateColor;

    }

    void UpdateColor(int indxColor)
    {
        if (indxColor <= colorsArray.Length)
        {
            material.color = colorsArray[indxColor-1];
        }
    }
}
