using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDeadzone : MonoBehaviour
{
    public CinemachineFreeLook cfl;

    private void Update()
    {
        if(cfl.m_YAxis.Value > 0.45f)
        {
            cfl.m_YAxis.Value = 0.45f;
        }

        if (Input.GetMouseButtonDown(2))
        {
            cfl.m_YAxis.Value = 0.45f;
        }
    }
}
