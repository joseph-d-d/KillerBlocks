using UnityEngine;
using System.Collections;

public class PlayerControllerBoxman : MonoBehaviour
{

     Rigidbody PlayerRigid;
     public int JumpPower;
     public float Speed;
     public Animator anim;
     Vector3 prevPos;
     bool PlayerHasTurnedRight;
     bool PlayerHasturnedLeft;
     // Use this for initialization
     void Start()
     {
          PlayerRigid = GetComponent<Rigidbody>();
          anim = GetComponent<Animator>();
          PlayerHasTurnedRight = true;
          PlayerHasturnedLeft = true;
     }

     // Update is called once per frame
     void Update()
     {
          Movement();
     }

     public void Movement()
     {
          if (Input.GetButton("right"))
          {
               anim.SetBool("Running", true);
               transform.position += -transform.right * Speed;

               if(PlayerHasturnedLeft == true)
               {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    PlayerHasTurnedRight = true;
                    PlayerHasturnedLeft = false;
               }
          }
          if (Input.GetButton("left"))
          {
               anim.SetBool("Running", true);
               transform.position += -transform.right * Speed;

               if (PlayerHasTurnedRight == true)
               {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    PlayerHasTurnedRight = false;
                    PlayerHasturnedLeft = true;
               }
          }
          if (Input.GetButtonDown("Jump"))
          {
               PlayerRigid.AddForce(0, JumpPower, 0);
          }
          anim.SetBool("Running", false);
     }
     
}
