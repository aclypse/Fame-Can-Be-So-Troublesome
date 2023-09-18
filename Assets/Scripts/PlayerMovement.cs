using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    private new Animator animation;
    //public AudioSource audioBoom;
     ExplodedObstacle explodedObstacleScript; 
    [SerializeField] float speed = 2f;
    public Rigidbody rb;
    private float horizontalInput;
    public float horizontalMultiplier = 1.05f;
    //ScoreScript scoreScript;
    

    private void Awake()
    {
        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }

        Vector3 forwardSpeed = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = horizontalInput * transform.right * speed * Time.fixedDeltaTime * horizontalMultiplier;

        //rb.MovePosition(forwardSpeed + horizontalMove + rb.position);
        //rb.velocity = forwardSpeed *speed;
        rb.velocity = horizontalMove + forwardSpeed * speed * Time.deltaTime;
        //rb.AddForce( forwardSpeed + horizontalMove );
      
        //rb.velocity = forwardSpeed;
        
        //Vector3.ClampMagnitude(forwardSpeed, horizontalMove);
       // ScoreScript.instance.AddScore();

      //  if (Input.GetKeyDown(KeyCode.W))
         //{Vector3 moveDown = new Vector3
            //    rb.MovePosition(Vector3.down);
          //  Debug.Log("It collides");
        //}
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
      
    }

    private void OnDisable()
    {
        Debug.Log("Something disabled me.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Debug.Log("I hit the wall");
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (collision.gameObject.TryGetComponent(out ExplodedObstacle obstacle))
            {
                obstacle.Explode();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                //audioBoom.Play();
              //  rb.constraints = RigidbodyConstraints.FreezeRotation;
                Die();
            }
        }
    }


    void Die() 
    {
        Debug.Log("You do die");
        speed = 2;
        // stops the animation when player collides
        animation.SetTrigger("collision");
        Invoke("Restart", 3);
    }

    void Restart()
    {
        alive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
