

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegs : MonoBehaviour
{

    #region Public
    public GameObject peg;
    public Rigidbody fireball;
    public Rigidbody iceball;
    public Material iceMat;
    public Material fireMat;
    
    public AudioClip IceSound;
    public AudioClip FireSound;
    public AudioSource PegSound;

    
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
                    rend.sharedMaterial = fireMat;
                    gameObject.tag = collision.collider.tag;
                }
                else if (gameObject.tag == "Ice")
                {
                    PegSound.clip = IceSound;
                    PegSound.Play();
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
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Fire")
            {
                PegSound.clip = IceSound;
                PegSound.Play();
                gameObject.tag = collision.collider.tag;
                rend.sharedMaterial = iceMat;
            }
            else if (gameObject.tag == "Ice")
            {
                PegSound.clip = FireSound;
                PegSound.Play();
                gameObject.tag = collision.collider.tag;
                rend.sharedMaterial = fireMat;
            }

        }
    }
    #endregion
}
