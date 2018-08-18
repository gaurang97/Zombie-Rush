using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {
    private Animator _playerAnimate;
    private Rigidbody _playerRigid;
    [SerializeField] private float force = 100f;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;
    private AudioSource _source;
    private bool jump = false;

    //Use this before initialization
    private void Awake()
    {
        Assert.IsNotNull(jumpSound);
        Assert.IsNotNull(deathSound);
    }
    // Use this for initialization
    void Start () {
        _playerAnimate = GetComponent < Animator>();
        _playerRigid = GetComponent<Rigidbody>();
        _source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.instance.GameOver != true )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.instance.gameStarted();
                jump = true;
                _playerAnimate.Play("Jump");
                _source.PlayOneShot(jumpSound);
                _playerRigid.useGravity = true;


            }
        }
        
	}

    private void FixedUpdate()
    {
        if(jump == true)
        {
            jump = false;
            _playerRigid.AddForce(new Vector2(0, force), ForceMode.Impulse);
            _playerRigid.velocity = new Vector2(0f, 0f);

        }
    }
   void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            
            _playerRigid.AddForce(new Vector2(-50f, 50f), ForceMode.Impulse);
            _playerRigid.detectCollisions = false;
            _source.PlayOneShot(deathSound);
            GameManager.instance.playerCollided();
        }
    }
}
