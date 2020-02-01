using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayIfClose : MonoBehaviour
{
    Camera m_MainCamera;

    void Start() {
        m_MainCamera = Camera.main;
    }

    void Update()
    {
        foreach (var obj in GetComponentsInChildren(typeof(Renderer))) {
            float dist = Vector3.Distance(m_MainCamera.transform.position, 
                                    new Vector3(obj.transform.localPosition.x, 1,                        obj.transform.localPosition.z));
            if (dist < 20.0) {
                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, 1, obj.transform.localPosition.z);
            }
            else {
                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, -1000, obj.transform.localPosition.z);
            }
            //Debug.Log("dist="+dist+"; Camera<x,y,z>="+ m_MainCamera.transform.position.x+ m_MainCamera.transform.position.y + m_MainCamera.transform.position.z);
        }
    }
}
