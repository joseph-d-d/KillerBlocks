using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
     public float speed;
     public float jumpHeight;


     // Use this for initialization
     void Start()
     {

     }

     // Update is called once per frame
     void FixedUpdate()
     {
          Vector3 movement;
          float move = Input.GetAxis("Horizontal");
          if(Input.GetButtonDown("Jump") == true)
          {
               movement = new Vector3(move, jumpHeight, 0.0f);
          }
          else
          {
               movement = new Vector3(move, 0.0f, 0.0f);
          }
          GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
     }


}
