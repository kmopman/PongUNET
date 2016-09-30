using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameScore : NetworkBehaviour
{

    /*
     * RESPONSIBILITY: 
     * 1. Hold the score of both players in two seperate integers.
     * 2. Send delegates when needed (whenever one of the players score).
     */

   [SerializeField] private ScoreCollider[] _scoreColliders;

    // Grabs both walls and their scripts.

   [SyncVar] private int _playerOneScore;
   [SyncVar] private int _playerTwoScore;

    /*
     * Integers that store the player's score.
     * SyncVar makes the score sync online.
     */

   [SerializeField][SyncVar] private int _scoreMultiplier = 1;

    // The amount of score it adds whenever a player scores.

   public int GetPlayerOneScore
    {
        get { return _playerOneScore; }
    }

   public int GetPlayerTwoScore
    {
        get { return _playerTwoScore; }
    }

    /*
     * Getters and setters for the player's scores.
     * Other scripts can now use these values,
     * i.e the script that handles the UI.
     */

    void Start()
    {
        foreach(ScoreCollider scorecollider in _scoreColliders)
        {
            scorecollider.OnLeftCollider += CmdAddP2Score;
            scorecollider.OnRightCollider += CmdAddP1Score;
        }
        
        /*
         * Grab both delegates.
         * These trigger only if the player scores.
         */

    }

    [Command]
    void CmdAddP1Score()
    {
        _playerOneScore += _scoreMultiplier;
    }

    [Command]
    void CmdAddP2Score()
    {
        _playerTwoScore += _scoreMultiplier;
    }

    /*
     * Whenever P1 scores, add a point.
     * Same goes for P2.
     * Command is an online function that causes the game to sync correctly.
     */

}
