using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    //Name: Christian Riggi
    //Student Number: 100752293
    //Jump code was referenced from this Youtube Video here: https://www.youtube.com/watch?v=pTJOksY7XFw

    //Jump variables
    public Vector3 jump;
    public float force = 2.0f;
    public float jump_height;

    private Rigidbody rb;
    private float movementspeed;
    private float dirX, dirZ;

    //Observer pattern action
    // Code referenced from Parisa's Lecture 4 Videos: https://drive.google.com/file/d/1mKuH4BzcJgqX2wQFOKWYbX6r7i3cS7mQ/view
    public static event Action destroyed;

    //Variable used to containing audio File
    private AudioSource _audioSource;

    //Awake function to intialize audio when the scene is loaded
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {

        //Set Movement speed
        movementspeed = 3.0f;
        rb = GetComponent<Rigidbody>();

        //Set Jump value
        jump = new Vector3(0f, jump_height, 0f);


        
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxis("Horizontal") * movementspeed;
        dirZ = Input.GetAxis("Vertical") * movementspeed;

       //Determine if the player is jumping
       if(rb.velocity.y == 0)
        {
            //If the player press' the space button add a force to the rigidbody which multiplies the jump vector and force value.
            //It also adds the impulse forcemode which is a mode that sends an impulse when the player jumps
            if(Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(jump * force, ForceMode.Impulse);



            }



        }


 

    }

    //Collision Detection Function
    //If the player touches the brick, the brick is destroyed
    //Code was referenced from this yotube video: https://www.youtube.com/watch?v=KVhSCck_5yI
   private void OnCollisionEnter(Collision col)
    {

        //Observer design pattern
        // If the destroyed action is true, it is now invoked
        #region observer
        destroyed?.Invoke();
        #endregion

        if(col.gameObject.tag == "Brick")
       {
         //Singleton pattern referenced from Healthtext class. Function subtractHealth is called and 1 is subtracted from the total
            HealthText.Instance.SubtractHealth(1); 
            
            Destroy(col.gameObject);

            //Play audio of brick if the destroyed action is invoked
            PlayerMovement.destroyed = PlayAudio;  

            
       }

     
       
    }

    //Function that is used to play Audio
    private void PlayAudio()
    {
        //Audiosource variable calls the play function. This function automatically plays the audio attched to the audio source component
        _audioSource.Play();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }

   
}

