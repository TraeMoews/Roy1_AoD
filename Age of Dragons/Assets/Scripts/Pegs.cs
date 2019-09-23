

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegs : MonoBehaviour
{

    #region Public
    public GameObject peg;
    public GameObject burst;
    public Rigidbody fireball;
    public Rigidbody iceball;
    public Material iceMat;
    public Material fireMat;
    
    public AudioClip IceSound;
    public AudioClip FireSound;
    public AudioSource PegSound;

    public Light lt;

    
    public GameManager gm;

    #endregion

    #region Private
    private Renderer rend;
    private bool fire;
    private bool ice;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        rend.enabled = true;

        lt = GetComponentInChildren<Light>();
       
        gm = FindObjectOfType<GameManager>();
    }

    #region Fuctions

    // Determine what ball hit peg and turns it the respective color then deletes peg
    void OnCollisionEnter(Collision collision)
    {
        if (!fire && !ice)
        {
            if (gameObject.CompareTag("Plain"))
            {
                gameObject.tag = collision.collider.tag;
                if (gameObject.tag == "Fire")
                {
                    PegSound.clip = FireSound;
                    PegSound.Play();
                    lt.color = Color.red;
                    rend.sharedMaterial = fireMat;
                    gameObject.tag = collision.collider.tag;
                }
                else if (gameObject.tag == "Ice")
                {
                    PegSound.clip = IceSound;
                    PegSound.Play();
                    lt.color = Color.blue;
                    rend.sharedMaterial = iceMat;
                    gameObject.tag = collision.collider.tag;
                }
            }
            else if (collision.gameObject.CompareTag("Fire") && gameObject.CompareTag("Fire"))
            {
                PegSound.clip = FireSound;
                PegSound.Play();
                print("Second Fire");
                fire = true;
                gm.RemovePegs(this);
                //Invoke("Peg Particle System", 1);
                Instantiate(burst, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                //print("boom boom");
                Destroy(gameObject);
                //gm.UpdateScore(gameObject.GetComponent<PegManagmentTemp>().points);
            }
            else if (collision.gameObject.CompareTag("Ice") && gameObject.CompareTag("Ice"))
            {
                PegSound.clip = IceSound;
                PegSound.Play();
                print("Second Ice");
                ice = true;
                gm.RemovePegs(this);
                //Invoke("Peg Particle System", 1);
                Instantiate(burst, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                //print("boom boom");
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Fire")
            {
                PegSound.clip = IceSound;
                PegSound.Play();
                lt.color = Color.blue;
                gameObject.tag = collision.collider.tag;
                rend.sharedMaterial = iceMat;
            }
            else if (gameObject.tag == "Ice")
            {
                PegSound.clip = FireSound;
                PegSound.Play();
                lt.color = Color.red;
                gameObject.tag = collision.collider.tag;
                rend.sharedMaterial = fireMat;
            }

        }
    }
    #endregion
}
