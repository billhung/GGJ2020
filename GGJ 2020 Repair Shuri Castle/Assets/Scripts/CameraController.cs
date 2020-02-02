using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera m_Camera;
    public Vector2 m_LastAngles = new Vector2(0, 0);
    public float m_MoveSpeed = 0.05f;
    public float m_RotateSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
        rotateCamera();
    }

    private void moveCamera()
    {
        if (Input.GetKey(KeyCode.D))
        {
            m_Camera.transform.Translate(Vector3.right * m_MoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Camera.transform.Translate(Vector3.left * m_MoveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            m_Camera.transform.Translate(Vector3.forward * m_MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Camera.transform.Translate(Vector3.back * m_MoveSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            m_Camera.transform.localPosition = move(m_Camera.transform.localPosition, new Vector3(0, m_MoveSpeed, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            m_Camera.transform.localPosition = move(m_Camera.transform.localPosition, new Vector3(0, -m_MoveSpeed, 0));
        }
    }

    private Vector3 move(Vector3 current, Vector3 delta)
    {
        return new Vector3(current.x + delta.x, current.y + delta.y, current.z + delta.z);
    }

    private void rotateCamera()
    {
        Vector2 newAngles = new Vector2(Input.GetAxis("Mouse X") * m_RotateSpeed, Input.GetAxis("Mouse Y") * m_RotateSpeed);
        Vector2 newAngles_ = new Vector2(1.0f, 0);
        m_LastAngles = new Vector2(m_LastAngles.x + newAngles.x, m_LastAngles.y + newAngles.y);
        m_Camera.transform.localEulerAngles = new Vector2(-m_LastAngles.y, m_LastAngles.x);
    }
}
