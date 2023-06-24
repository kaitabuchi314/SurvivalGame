using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOnDrag : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public float xSpeed;
    public float ySpeed;

    void Start()
    {
        xSpeed = cam.m_XAxis.m_MaxSpeed;
        ySpeed = cam.m_YAxis.m_MaxSpeed;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cam.m_XAxis.m_MaxSpeed = xSpeed;
            cam.m_YAxis.m_MaxSpeed = ySpeed;
        }
        else
        {
            cam.m_XAxis.m_MaxSpeed = 0;
            cam.m_YAxis.m_MaxSpeed = 0;
        }
    }
    void OnApplicationQuit()
    {
        cam.m_XAxis.m_MaxSpeed = xSpeed;
        cam.m_YAxis.m_MaxSpeed = ySpeed;
    }
}
