using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [SerializeField]
    private Transform m_droneTransform;
    [SerializeField]
    private float m_speed = 2f;

    [Header("Max Height Behavior")]
    [Tooltip("How high the drone's Y transform can go before capping height")]
    [SerializeField] private float maxHeight = 530f;
    [Tooltip("How much force to apply in the opposite direction when player reaches max height")]
    [Range(6f, 1000f)][SerializeField] private float yConstraintForce = 7f;

    private CharacterController droneController;

    // Start is called before the first frame update
    void Start()
    {
        droneController = GetComponent<CharacterController>();
        m_droneTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() // When moving things with character controller, use the provided Move() commands. Transform.translate should be used as sparingly as possible as they disregard things like forces and collisions
    {
        float inputVerticalAxis = Input.GetAxis("DroneVertical");
        if (inputVerticalAxis != 0 )
        {
            droneController.Move(Vector3.up * inputVerticalAxis * m_speed * Time.deltaTime);
        }

        if (transform.position.y > maxHeight)
        {
            droneController.Move(Vector3.down * yConstraintForce * Time.deltaTime);
        }
    }
}
