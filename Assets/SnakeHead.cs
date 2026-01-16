using System;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    /// <summary>
    /// 1. Get the snake moving in cardinal directions
    ///     - The snake head steers the snake
    ///     - The snake is constantly in motion
    ///     - Each snake tail piece follows the piece in front of it
    ///     - If the snake head steers right, the tail piece behind it continues until it reaches the snake heads
    ///       previous position, and then it's next position will move in the new direction of the head piece.
    /// </summary>
    
    private void Awake()
    {
        
    }
    
    private void Start()
    {
        
    }
    
    private void Update()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 1.0F, 0, 0));
        transform.Translate(new Vector3(Time.deltaTime * 1.0F, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            // Create new tail piece
            /*
             * Maintain a List/Queue of tail pieces
             * Instantiate a chosen amount in Awake/Start
             * When snake head collides with food, instantiate a new tail piece and set its position to the back piece + offset
             */
            
            //print(other.gameObject.name); // Not printing?
            Destroy(other.gameObject);
        }
    }
}
