using UnityEngine;
using System.Collections;

public class ScoreCollider : MonoBehaviour 
{

    /*
     * This is the Score Collider script.
     * This script handles the firing of delegates.
     * Whenever the ball collides with one of the walls,
     * A certain delegate gets fired.
     * 
     * This script hangs onto the left, and right collider.
     */


    [SerializeField] private bool _isLeftCollider;
    [SerializeField] private bool _isRightCollider;

    /*
     * These are booleans that we will assign in the inspector.
     */

    public delegate void ScoreEventHandler();

    public ScoreEventHandler OnLeftCollider;
    public ScoreEventHandler OnRightCollider;

    /*
     * The delegates we will use for our left,
     * or right collider.
     */
    
    public ScoreEventHandler OnScoreAdd;

    // The delegate we will use that fires for whenever a wall gets hit.

void OnCollisionEnter2D(Collision2D coll)
    {
    if (coll.gameObject.CompareTag(GameTags.ball)) // (No in-line strings, use of a Data Class)
    {
        if (_isLeftCollider)
        {
            if (OnLeftCollider != null)
                OnLeftCollider();
        }

            /*
             * If the ball hits the left collider,
             * Fire delegate.
             */
        else if (_isRightCollider)
        {
            if (OnRightCollider != null)
                OnRightCollider();
        }

        /*
            * If the ball hits the right collider,
            * Fire delegate.
            */


        if (OnScoreAdd != null)
            OnScoreAdd();

        /*
            * If the ball hits one of the two colliders,
            * Fire delegate.
            */

    }
    }

}
