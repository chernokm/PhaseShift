using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [SerializeField]
    private Transform m_droneTransform;
    [SerializeField]
    private float m_speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        m_droneTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("DroneVertical") > 0 )
        {
            m_droneTransform.Translate(Vector3.up * Time.deltaTime * m_speed, Space.World);
        }

        else if (Input.GetAxis("DroneVertical") < 0)
        {
            m_droneTransform.Translate(Vector3.down * Time.deltaTime * m_speed, Space.World);
        }
    }
}
