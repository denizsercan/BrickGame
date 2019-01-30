using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BallP2 : MonoBehaviour
{



    public float ballInitialVelocity = 1000f;
    public GameObject brickParticle;
    private Rigidbody rb;
    private bool ballInPlay;
    new AudioSource audio;

    public int lives;
    public Text livesText;
    public Text gameOver;
    public float resetDelay = 1f;
    public static Ball instance = null;
    public GameObject bricksPrefab;

    public Text ScoreText;
    private int score;
    public Text winText;
    int kalanbox = 0;

    void Start()
    {        
        audio = GetComponent<AudioSource>();
        score = 0;
        ScoreText.text = "Score: " + score.ToString();
        SetScoreText();
        winText.text = "";
        lives = 3;
        setLivesText();
    }

    public void setLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
    public void SetScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //DontDestroyOnLoad(transform.gameObject);
        //Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }      

        GameObject[] box1 = GameObject.FindGameObjectsWithTag("yellowbox");
        GameObject[] box2 = GameObject.FindGameObjectsWithTag("purplebox");
        kalanbox = box1.Length + box2.Length;

        if(kalanbox < 1)
        {
            winText.text = "YOU WON";
            Time.timeScale = .25f;
            // StartCoroutine("NextLevel");         
        }
    }

    //IEnumerator NextLevel()
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    Application.LoadLevel("page2");
    //}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "yellowbox")
        {
            Destroy(col.gameObject);
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            audio.Play();
            score = score + 100;
            SetScoreText();

        }

        if(col.gameObject.tag == "purplebox")
        {
            Destroy(col.gameObject);
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            audio.Play();
            score = score + 200;
            SetScoreText();

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "yer")
        {
            gameOver.text = "GAME OVER";
            //lives--;
            //setLivesText();
            //Application.LoadLevel(Application.loadedLevel);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);           
        }
    }

}
