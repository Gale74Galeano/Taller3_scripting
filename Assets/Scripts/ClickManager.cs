using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public delegate void OnButtonClicked(int indx);
    public static OnButtonClicked m_OnButtonClicked;
    int colorIndx;

    private void Start()
    {
        colorIndx = 1;
        m_OnButtonClicked?.Invoke(colorIndx);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (colorIndx < 4)
            {
                colorIndx += 1;
            }
            else
            {
                colorIndx = 1;
            }
            m_OnButtonClicked?.Invoke(colorIndx);
        }
    }

}
