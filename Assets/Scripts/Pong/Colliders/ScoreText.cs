using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ScoreText : NetworkBehaviour 
{
    /*
     * This class keeps track of the score.
     * 
     * RESPONSIBILITY: Showcases the score of both players onto a text object.
     */


    [SerializeField] private ScoreCollider[] _scoreColliders; // Grabs script of both colliders (left and right).
    [SerializeField] private GameScore _gameScore; // Grabs the score of both players.
    [SerializeField] private Text _scoreText; // Grabs the text object.

    void Start()
    {
        foreach(ScoreCollider scorecollider in _scoreColliders)
            scorecollider.OnScoreAdd += CmdText;
    }

    [Command]
    void CmdText()
    {
        RpcUpdateText();
    }



    [ClientRpc]
    void RpcUpdateText()
    {
        _scoreText.text = _gameScore.GetPlayerOneScore + "-" + _gameScore.GetPlayerTwoScore;
    }
}
