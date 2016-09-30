using UnityEngine;
using System.Collections;

public class WallColliderSound : MonoBehaviour
{

    /*
     * RESPONSIBILITY: Play a sound whenever the ball hits either the left, or right wall.
     */

    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private ScoreCollider _scoreCollider;
	
    void Start()
    {
        _scoreCollider.OnScoreAdd += PlayWallSound;

        // Add function to the delegate.
    }

    void PlayWallSound()
    {
        _soundManager.PlaySound(1);

        // Play sound.
    }
}
