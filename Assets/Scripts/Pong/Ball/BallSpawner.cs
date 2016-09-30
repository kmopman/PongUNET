using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BallSpawner : NetworkBehaviour
{

    /*
     * This class hangs onto it's own GameObject, the BallManager.
     * 
     * RESPONSIBILITY: Spawn the ball onto the screen.
     */

    [SerializeField] private ScoreCollider[] _scoreColliders; // Grabs the script from both the left, and right wall object.
    [SerializeField] private GameObject _ballObject; // The GameObject we're about to instantiate (the ball).
    [SerializeField] private Transform _ballStartPosition; // The starting position of the ball.

    [SerializeField] private float _timeUntilBallAppears; // The amount of time for the ball to wait before it functions.
    [SerializeField] private bool _runSpaceOnce; // We're going to need this boolean to make something run once.

    void Start()
    {
        foreach (ScoreCollider scorecollider in _scoreColliders)
        scorecollider.OnScoreAdd += InvokeBall;

        /*
         * The ScoreCollider script sends delegates over to certain scripts.
         * OnScoreAdd gets called whenever the ball either hits the left, or right wall (Which would grant a point).
         * Every time this happens, the ball gets removed, and the game will instantiate a new one.
         */
    }

    void Update()
    {
        StartBall();
    }

    private void StartBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_runSpaceOnce)
            {
                CmdSpawnBall();
                _runSpaceOnce = true;
            }
        }

        /*
         * This will only run once, and we will use this at the very start of the game.
         * Once the host has pressed the Space button (which is only possible if the boolean is false), the ball instantiates.
         * Afterwards, the boolean's value turns to true, and never turns false afterwards.
         */
    }

    private void InvokeBall()
    {
        Invoke("CmdSpawnBall", _timeUntilBallAppears);

        /*
         * Invoke calls a function, but the second parameter gives you the opportunity to wait a certain amount of seconds
         * Before it gets called. The second parameter should be a float.
         */

    }

    [Command]
    private void CmdSpawnBall()
    {
       GameObject ball = Instantiate(_ballObject, _ballStartPosition.position, Quaternion.identity) as GameObject;
       NetworkServer.Spawn(ball);

    }

    /*
     * [Command] = A Networking function that takes care of any synchronization.
     * Instantiate the ball as a GameObject.
     * NetworkServer.Spawn(ball) = Instantiates the object on both computers.
     */
}