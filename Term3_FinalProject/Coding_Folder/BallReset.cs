using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System.Collections;

public class BallReset : MonoBehaviour
{
    public string ballTag = "Ball"; // Tag of the ball object
    private Vector3 originalPosition; // Original position of the ball
    public GameObject ball; // Reference to the ball object

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag(ballTag);
        if (ball != null)
            originalPosition = ball.transform.position;
        else
            Debug.LogWarning("Ball object not found with tag: " + ballTag);
    }

    private void Update()
    {
        XRController xrController = GetComponent<XRController>();
        if (Input.GetButtonUp("AButton"))
        {
            ResetBallPosition();
        }
    }

    private void ResetBallPosition()
    {
        if (ball != null)
        {
            ball.transform.position = originalPosition;
            ball.transform.rotation = Quaternion.identity;
            ball.transform.localScale = Vector3.one;
        }
    }
}
