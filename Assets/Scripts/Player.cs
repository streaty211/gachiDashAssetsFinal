using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public float JumpPower = 5.0f;
    [SerializeField] public float speed = 2.0f;
    Rigidbody2D player;
    private Animator anim;
    public bool isGrounded = false;
    float posX = -1.0f;
    public bool isGameOver = false;
    public int extraJump;
    public int LargeJump;
    public AudioClip jump;
    //public AudioClip gameOver;
    AudioSource myAudioSource;
    public GameObject gameOverPanel;
    //public Text scoreText;
    public int score;
    public Text currentText;
    public Text bestText;
    public GameObject newAlert;
    private string _achivementName9 = "NEW_ACHIEVEMENT_1_9", _achivementName12 = "NEW_ACHIEVEMENT_1_12";




    private void Awake()
    {
        player = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
        myAudioSource = GameObject.FindObjectOfType<AudioSource>();


    }

    private void FixedUpdate()
    {
        if (isGrounded) State = States.idle;
        if (!isGrounded) State = States.Jump;

        score = Videos.pscore;

        if (Input.GetButton("Jump") && !isGameOver && extraJump > 0)
        {
            player.velocity = (Vector2.up * (JumpPower * 4.2f)); //player.gravityScale 20.0f player.mass
            myAudioSource.PlayOneShot(jump);
            extraJump = 0;
        }
        else if (Input.GetButton("Jump") && isGrounded && extraJump == 0)
        {
            player.velocity = (Vector2.up * (JumpPower * 4.2f)); // addforce
            myAudioSource.PlayOneShot(jump);
        }

        if (LargeJump == 1)
        {
            player.velocity = (Vector2.up * (JumpPower * 7f));
            myAudioSource.PlayOneShot(jump);
            LargeJump = 0;
        }
        // встреча с препятствием лицом
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (transform.position.x < posX && !isGameOver)
                GameOver();
        }

        if (score == 10)
        {
            bool ach12 = Steamworks.SteamUserStats.SetAchievement(_achivementName12);
            Debug.Log(message: "Is achievement" + _achivementName12 + "status updated: " + ach12);
            bool _isStatsStored12 = Steamworks.SteamUserStats.StoreStats();
            Debug.Log(message: "Is stats stored:" + _isStatsStored12);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = true;



        if (other.collider.tag == "Enemy" && !isGameOver)
        {
            GameOver();
            bool ach9 = Steamworks.SteamUserStats.SetAchievement(_achivementName9);
            Debug.Log(message: "Is achievement" + _achivementName9 + "status updated: " + ach9);
            bool _isStatsStored9 = Steamworks.SteamUserStats.StoreStats();
            Debug.Log(message: "Is stats stored:" + _isStatsStored9);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SecondJump"))
            extraJump = 1;
        if (collision.CompareTag("LargeJump"))
            LargeJump = 1;
        /*if (collision.CompareTag("Money"))
        {
            ScoreIncrement();
            Destroy(collision.gameObject);
        }*/
    }



    void GameOver()
    {
        
        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        isGameOver = true;
        if (currentlevel == 10)
        {
            SoundManager.snd.PlayDeathSounds();
            Time.timeScale = 0;
            PlayerPrefs.SetInt("death9", PlayerPrefs.GetInt("death9") + 1);
            //scoreText.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
            


            if (score > PlayerPrefs.GetInt("Best", 0))
            {
                PlayerPrefs.SetInt("Best", score);
                newAlert.SetActive(true);
            }

            bestText.text = "Best:" + PlayerPrefs.GetInt("Best").ToString();
            currentText.text = "Cups collected:" + score.ToString();
            //PlayerPrefs.SetInt("Best", 0);

        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        if (currentlevel == 2)
        {
            PlayerPrefs.SetInt("death1", PlayerPrefs.GetInt("death1") + 1); 
        }

        if (currentlevel == 3)
        {
            PlayerPrefs.SetInt("death2", PlayerPrefs.GetInt("death2") + 1);
        }

        if (currentlevel == 4)
        {
            PlayerPrefs.SetInt("death3", PlayerPrefs.GetInt("death3") + 1);
        }

        if (currentlevel == 5)
        {
            PlayerPrefs.SetInt("death4", PlayerPrefs.GetInt("death4") + 1);
        }

        if (currentlevel == 6)
        {
            PlayerPrefs.SetInt("death5", PlayerPrefs.GetInt("death5") + 1);
        }

        if (currentlevel == 7)
        {
            PlayerPrefs.SetInt("death6", PlayerPrefs.GetInt("death6") + 1);
        }

        if (currentlevel == 8)
        {
            PlayerPrefs.SetInt("death7", PlayerPrefs.GetInt("death7") + 1);
        }

        if (currentlevel == 9)
        {
            PlayerPrefs.SetInt("death8", PlayerPrefs.GetInt("death8") + 1);
        }
    }   

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    /*void ScoreIncrement()
    {
        score++;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
    }*/

    

}

public enum States
{
    idle,
    Jump
}