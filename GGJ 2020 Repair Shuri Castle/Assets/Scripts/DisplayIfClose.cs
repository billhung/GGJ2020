using System.Collections;
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
                                    new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y,                        0));

            isInPlace = isInPlaceCheck();
            if (isInPlace) {
                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, 1000);
            } else {
                if (dist < 30.0) {
                    obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, 0);
                }
                else {
                    obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, 1000);
                }
            }

            //Debug.Log("dist="+dist+"; Camera<x,y,z>="+ m_MainCamera.transform.position.x+ m_MainCamera.transform.position.y + m_MainCamera.transform.position.z);
        }
    }

    bool isInPlaceCheck() {         
        //not enough time for implementation (to stop blinking when one piece is in place)
        //時間のため実装に間に合わなかった
        return false;
    }
}
