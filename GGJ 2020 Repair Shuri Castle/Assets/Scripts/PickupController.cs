using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Renderer m_HoldingObject = null;
    public CameraController m_CameraController;

    private Component[] m_Parts;
    private float epsilon = 5;
    // Start is called before the first frame update
    void Start()
    {
        var mainCamera = GameObject.Find("Main Camera");
        m_CameraController = mainCamera.GetComponent<CameraController>();

        m_Parts = GetComponentsInChildren(typeof(Renderer));
    }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = m_CameraController.m_Camera.transform.position;
        if (m_HoldingObject != null)
        {
            m_HoldingObject.transform.position = new Vector3(cameraPosition.x, cameraPosition.y - 10, cameraPosition.z);
        }

        if (Input.GetKey(KeyCode.P))
        {
            if (m_HoldingObject == null)
            {
                m_HoldingObject = pickupObject(cameraPosition)?.GetComponent<Renderer>();
                Debug.Log(m_HoldingObject == null);
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            m_HoldingObject = null;
        }
    }

    private Component pickupObject(Vector3 position)
    {
        Component nearest = m_Parts.OrderBy(obj => dist(position, obj.transform.position)).First();
        Debug.Log(dist(position, nearest.transform.position));
        return dist(position, nearest.transform.position) < epsilon ? nearest : null;
    }

    private float dist(Vector3 p, Vector3 q)
    {
        return p == null || q == null ? float.MaxValue : (p.x - q.x) * (p.x - q.x) + (p.y - q.y) * (p.y - q.y);
    }
}
