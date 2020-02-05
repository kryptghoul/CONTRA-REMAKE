using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rd2d;
    private bool isGrounded;
    public float speed;

	public GameObject shot;
	 public Transform shotSpawn;
	 public float fireRate;
	 public AudioSource musicSource;

	 private float nextFire;

     private Rigidbody rb;


    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
        }
		PlayerMovement();
	}

    //======Function==========
    void PlayerMovement()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionStay2D(Collision2D collision) //jumping code
    {
        if (collision.collider.tag == "Ground")
        {
            //Debug.Log("on ground");
            isGrounded = true;
            if (Input.GetKey(KeyCode.W) && isGrounded == true)
            {
                //Debug.Log("w press");
                rd2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
    }
}
