using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;
    public TextMeshProUGUI timer;
    float totaltime=0.0f;
    public CameraShake cs;
    public GameOver gos;
    public Transform cam;
    public Animator anim;
    public Animator anim2;
    float horizontal,vertical;
    public float runSpeed = 6.0f;
    public float health = 4.0f;
    public AudioSource ad;
    bool isPlaying = false;
    bool disableMovement = false;
    public float stealDuration = 1.0f;
    public float lookRadius = 2.5f;
    public float lossSpeed = 0.1f;
    public float healAmt = 0.5f;
    public RectTransform healthbar;
    void Start()
    {
        // health = 4.0f;
        // anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        totaltime+=Time.deltaTime;
        timer.text = ""+(int)(totaltime);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        health-=Time.deltaTime*lossSpeed;
        if(health<=0)
        {
            health=0;
            Debug.Log("GM");
            gos.GameEnded(totaltime);
            gameObject.SetActive(false);
        }
        if(health>4)
        health=4;
        healthbar.localScale = new Vector3(health,0.06f,1.0f);
        if(Input.GetKey("a")||Input.GetKey("w")||Input.GetKey("s")||Input.GetKey("d"))
        {
            if(!isPlaying)
            {
                ad.Play(0);
                isPlaying = true;
            }
        }
        else
        {
            if(isPlaying)
            {
                ad.Stop();
                isPlaying = false;
            }
        }
        if(body.velocity.x<=0)
            transform.localScale = new Vector3(-1,1,1);
        else
            transform.localScale = new Vector3(1,1,1);
        if(Input.GetKey("space"))
        {
            playStealAnim();
        }
        if(disableMovement==true)
        {
            horizontal = 0;
            vertical = 0;
            if(isPlaying)
            {
                ad.Stop();
                isPlaying = false;
            }
            float dist = (cam.position.x-transform.position.x)*(cam.position.x-transform.position.x)+(cam.position.y-transform.position.y)*(cam.position.y-transform.position.y);
            if(dist<=lookRadius*lookRadius)
            {
                Debug.Log("GameOver!");
                gos.GameEnded(totaltime);
                gameObject.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal*runSpeed,vertical*runSpeed);

        anim.SetFloat("speed",body.velocity.x*body.velocity.x+body.velocity.y*body.velocity.y);
    }
    void playStealAnim()
    {
        anim2.SetBool("steal",true);
        disableMovement = true;
        Invoke("stopStealAnim",stealDuration);
    }
    void stopStealAnim()
    {
        anim2.SetBool("steal",false);
        disableMovement = false;
    }
}
