using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera can;
    public Transform followTarget;

    // Starting position for the parallax game object
    Vector2 startingPosition;

    // Start Z value of the parallax game object
    float startingZ;

    // Distance that the camera has moved from the starting position of the parallax object
    Vector2 canMoveSinceStart => (Vector2)can.transform.position - startingPosition;


    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // if object is in front of target , use near clip plane . if behind target , use far clip plane
    float clippingPlane => (can.transform.position.z + (zDistanceFromTarget > 0 ? can.farClipPlane : can.nearClipPlane));

    // the futher the object from the player, the faster the parallaxEffect object will move. drag is`s Z value closer to the tager to make is move slower
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // when the target moves , move the parallax object the same distance time a multiplier
        Vector2 newPosition = startingPosition + canMoveSinceStart * parallaxFactor;

        // the X/Y position changes based on target travel speed times the parallax fator, but Z stays consistent
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
