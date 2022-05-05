using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugManager : MonoBehaviour
{
    private void OnEnable()
    {
        ClickManager.m_OnButtonClicked += PrintIndex;
    }

    private void OnDisable()
    {
        ClickManager.m_OnButtonClicked -= PrintIndex;

    }

    void PrintIndex(int colorIndx)
    {
        Debug.Log("The color index is: " + colorIndx.ToString());
    }
    
}
