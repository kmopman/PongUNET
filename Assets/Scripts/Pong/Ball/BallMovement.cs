using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BallMovement : NetworkBehaviour 
{

    /*
     * This class hangs onto the ball object itself.
     * 
     * RESPONSIBILITY: Make the ball move.
     */

    [SerializeField] private float _ballSpeed; // Speed of the ball.
    [SerializeField] private float _ballCountDown; // Seconds until the ball starts moving.

    [SerializeField] private bool _ballIsMoving; // Is the ball moving?

    public bool SetBallIsMoving
    {
        get { return _ballIsMoving; }
        set { _ballIsMoving = value; }
    }

    [SerializeField] private Rigidbody2D _ballRigidBody2D; // Grabs the ball's RigidBody2D component.

    void Start()
    {
        StartCoroutine("StartBall");
    }

    private IEnumerator StartBall()
    {
        yield return new WaitForSeconds(_ballCountDown);
        _ballIsMoving = true;
        _ballRigidBody2D.velocity = new Vector2(_ballSpeed, _ballSpeed);
    }

}
