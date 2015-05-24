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

     Vector3 temp;
     float tempX;
     float tempY;


     // Use this for initialization
     void Start()
     {
         
     }

     // Update is called once per frame
     void FixedUpdate()
     {

         Transform transform = GetComponent<Transform>();

         //reset the rotation to 0s
         transform.rotation = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
         //reset the z-axis to 0s
         tempX = transform.position.x;
         tempY = transform.position.y;
         temp = giveZeroZ(tempX, tempY);
         transform.position = temp;

          Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
          float move = Input.GetAxis("Horizontal") / 4;
          if (Input.GetButtonDown("Jump") == true && jumpcount != 0)
          {
               jumpcount--;
               movement = new Vector3(move, jumpHeight, 0.0f);
               GetComponent<AudioSource>().Play();
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

     Vector3 giveZeroZ(float fX, float fY)
     {
         Vector3 t = new Vector3(fX, fY, 0f);
         return t;
     }
}