using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class BallThrower : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public float throwForce = 10f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = ballRigidbody.transform.position;
        initialRotation = ballRigidbody.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetButtonUp("TriggerButton"))
        {
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        // Reset the ball's position and rotation
        ballRigidbody.transform.position = initialPosition;
        ballRigidbody.transform.rotation = initialRotation;

        // Calculate the throwing direction based on the VR hand's velocity
        Vector3 throwDirection = GetThrowDirection();

        // Apply an impulse force to the ball in the calculated direction
        ballRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }

    private Vector3 GetThrowDirection()
    {
        // Get the velocity of the VR hand or controller
        Vector3 handVelocity = GetVRHandVelocity();

        // Use the hand velocity as the throw direction
        return handVelocity.normalized;
    }

    private Vector3 GetVRHandVelocity()
    {
        Vector3 velocity = Vector3.zero;

        XRController xrController = GetComponent<XRController>();
        if (xrController != null && xrController.inputDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity))
        {
            return velocity;
        }

        return velocity;
    }
}
