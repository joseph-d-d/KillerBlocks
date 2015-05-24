using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
     //the speed of the player
     public float speed;
     //the height when the player jumped
     public float jumpHeight;

     //how many times the player can jump
     public int maxJump = 2;
     public int jumpcount = 2;

     // Use this for initialization
     void Start()
     {
         
     }

     // Update is called once per frame
     void FixedUpdate()
     {
         Transform transform = GetComponent<Transform>();
         
          Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
          float move = Input.GetAxis("Horizontal") / 4;
          if (Input.GetButtonDown("Jump") == true && jumpcount != 0)
          {
               jumpcount--;
               movement = new Vector3(move, jumpHeight, 0.0f);
               GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
               GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
          }
          else
          {
              movement = new Vector3(move, 0.0f, 0.0f);
              transform.Translate(movement);
          }
          
          
     }

     //trigger when the ball hit something...
     void OnCollisionEnter(Collision collision)
     {
          //reset the jumpcount to maxJump
          jumpcount = maxJump;
     }
}