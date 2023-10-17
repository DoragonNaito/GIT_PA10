using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;
   
    public float jumpforce = 10;
    private int Score = 0;
    [SerializeField] public Text Txt_Score;


    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        thisAnimation.Play();

        if (transform.position.y >= 10f)
        {
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            if (transform.position.y <= -10f)
            {
                SceneManager.LoadScene("LoseScene");
            }


            if(Score == 15 )
            {
                SceneManager.LoadScene("WinScene");
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
   
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Score++;
            Txt_Score.text = "SCORE : "+ Score;

        }
       
    }
}
