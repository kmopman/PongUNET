using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMovement : NetworkBehaviour {

    /*
     * This is the player movement script.
     * Hangs onto the Player object.
     * 
     * RESPONSIBILITY: Move the player.
     */

    [SerializeField] private float ySpeed = 150f;
    [SerializeField] private Rigidbody2D _playerRigidBody2D;

	void Update()
    {
        Movement(); // We need to register our input at all time.
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }

    /*
     * CheckIsLocal is a function that checks whoever controls which player.
     * isLocalPlayer is a built-in boolean that belongs to NetworkBehaviour.
     * This prevents the local player from controlling all players on screen.
     */

    void Movement()
    {
        CheckIsLocal();

        float y = Input.GetAxis(AxisStrings.vertical) * ySpeed;
        _playerRigidBody2D.velocity = new Vector2(0, y);

        // Moves the player in a vertical manner, using the RigidBody2D attribute.
    }
}
