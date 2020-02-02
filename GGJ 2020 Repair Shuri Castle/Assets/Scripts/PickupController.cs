using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Renderer m_HoldingObject = null;
    public CameraController m_CameraController;
    public GameObject m_CorrectCastle;
    public float m_Epsilon = 15;


    private Component[] m_Parts;
    // Start is called before the first frame update
    void Start()
    {
        var mainCamera = GameObject.Find("Main Camera");
        m_CameraController = mainCamera.GetComponent<CameraController>();
        m_CorrectCastle = GameObject.Find("ShuriCastle_Correct");

        m_Parts = GetComponentsInChildren(typeof(Renderer));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_HoldingObject == null ? "No object" : "Holding now");
        var cameraPosition = m_CameraController.m_Camera.transform.position;
        if (m_HoldingObject != null)
        {
            m_HoldingObject.transform.position = new Vector3(cameraPosition.x, cameraPosition.y - m_Epsilon, cameraPosition.z);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (m_HoldingObject == null)
            {
                m_HoldingObject = pickupObject(cameraPosition)?.GetComponent<Renderer>();
            }
        }
        else if (m_HoldingObject != null)
        {
            releaseHoldingObject();
        }
    }

    private Component pickupObject(Vector3 position)
    {
        Component nearest = m_Parts.OrderBy(obj => dist(position, obj.transform.position)).First();
        return dist(position, nearest.transform.position) < m_Epsilon ? nearest : null;
    }

    private float dist(Vector3 p, Vector3 q)
    {
        return p == null || q == null ? float.MaxValue : (p.x - q.x) * (p.x - q.x) + (p.y - q.y) * (p.y - q.y);
    }

    private void releaseHoldingObject()
    {
        var obj = m_HoldingObject;
        var targetObj = getCorrectObjectByName(obj.name);
        if (targetObj != null && canAttachObj(obj, targetObj))
        {
            obj.transform.position = targetObj.transform.position;
        }
        m_HoldingObject = null;
    }

    private bool canAttachObj(Renderer obj, Renderer targetObj)
    {
        return Vector3.Distance(obj.transform.position + new Vector3(0, obj.bounds.size.y, 0), targetObj.transform.position) < m_Epsilon;
    }

    private Renderer getCorrectObjectByName(string name)
    {
        foreach (var o in m_CorrectCastle.GetComponentsInChildren<Renderer>())
        {
            if (o.name == name)
            {
                return o as Renderer;
            }
        }
        return null;
    }
}
