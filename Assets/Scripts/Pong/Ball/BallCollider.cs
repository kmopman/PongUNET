using UnityEngine;
using System.Collections;

public class BallRemover : MonoBehaviour 
{

    /*
     * RESPONSIBILITY: Remove/Destroy the ball on contact with one of the colliders.
     */

	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(GameTags.leftcollider))
        {
            Destroy(gameObject);
        }

        else if (coll.gameObject.CompareTag(GameTags.rightcollider))
        {
            Destroy(gameObject);
        }
    }
}
