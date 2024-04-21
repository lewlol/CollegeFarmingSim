using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnCamChange : MonoBehaviour
{
    public CinemachineFreeLook cmf;
    int currentOrbit;

    private void Start()
    {
        currentOrbit = 1;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (cmf.m_Orbits[1].m_Height == 5.2)
            {
                cmf.m_Orbits[1].m_Height = 3;
                cmf.m_Orbits[1].m_Radius = 5;
            }
            else
            {
                cmf.m_Orbits[1].m_Height = 5.2f;
                cmf.m_Orbits[1].m_Radius = 12;
            }
        }
    }
}
