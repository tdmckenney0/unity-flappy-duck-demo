using UnityEngine;
using System.Collections;

public class Flappy : MonoBehaviour {

    public string FlapTrigger = "SwimTrigger";
    public string ObstacleName = "Wall";
    public string TitleScene = "Flappy_Title";

    public AudioClip swimSound;

    public float flapPower;
    // public float forwardMoveSpeed;

    Rigidbody2D rb;
    // Animator anim;
    AudioSource aud;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(ObstacleName))
        {
            Debug.Log("Died!");
            // Application.LoadLevel(TitleScene); // Depreciated.
            UnityEngine.SceneManagement.SceneManager.LoadScene(TitleScene);
        }
    }

    public void Flap()
    {
        Vector2 flapForce = new Vector2(0f, flapPower);
        rb.velocity = flapForce;
        //anim.SetTrigger(FlapTrigger);
        aud.clip = swimSound;
        aud.Play();
    }
}
