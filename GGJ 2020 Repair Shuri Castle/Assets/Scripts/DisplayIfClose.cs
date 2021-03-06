﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayIfClose : MonoBehaviour
{
    Camera m_MainCamera;
    bool isInPlace;

    public GameObject scatteredParts;

    void Start() {
        m_MainCamera = Camera.main;
        isInPlace = false;
    }

    void Update()
    {
        foreach (var obj in GetComponentsInChildren(typeof(Renderer))) {
            float dist = Vector3.Distance(m_MainCamera.transform.position, 
                                    new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, 0));

            if (dist < 30.0) {
                //obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, 0);
                obj.GetComponent<Renderer>().enabled = true;
            } else {
            //obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, 1000);
                obj.GetComponent<Renderer>().enabled = false;
            }

            //Debug.Log("dist="+dist+"; Camera<x,y,z>="+ m_MainCamera.transform.position.x+ m_MainCamera.transform.position.y + m_MainCamera.transform.position.z);
        }
    }

}
