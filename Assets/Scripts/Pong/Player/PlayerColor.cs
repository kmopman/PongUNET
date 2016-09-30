using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerColor : NetworkBehaviour 
{

    /*
     * This class is attached to the player.
     * 
     * RESPONSIBILITY: This class gives the local player a specific color,
     * To let the player which object to use.
     */

    [SerializeField] private SpriteRenderer _playerSpriteRenderer; // Grabs the GameObject's Sprite Renderer component.
    [SerializeField] private Color _playerColor; // Make a variable to store a certain color in.

    public override void OnStartLocalPlayer()
    {
        _playerSpriteRenderer.color = _playerColor;
    }

    /*
     * OnStartLocalPlayer is a built-in function for Unity's Networking.
     * We use this function to assign the local player's sprite renderer a certain color.
     */
}
