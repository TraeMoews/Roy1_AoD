

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
    public PegManagmentTemp pegManRef;

    public int points;

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
        pegManRef = FindObjectOfType<PegManagmentTemp>();
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
                    rend.sharedMaterial = fireMat;
                    gameObject.tag = collision.collider.tag;
                }
                else if (gameObject.tag == "Ice")
                {
                    rend.sharedMaterial = iceMat;
                    gameObject.tag = collision.collider.tag;
                }
            }
            else if (collision.gameObject.CompareTag("Fire") && gameObject.CompareTag("Fire"))
            {
                print("Second Fire");
                fire = true;
                pegManRef.RemovePegs(this);
                
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Ice") && gameObject.CompareTag("Ice"))
            {
                print("Second Ice");
                ice = true;
                pegManRef.RemovePegs(this);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Fire")
            {
                gameObject.tag = collision.collider.tag;
                rend.sharedMaterial = iceMat;
            }
            else if (gameObject.tag == "Ice")
            {
                gameObject.tag = collision.collider.tag;
                rend.sharedMaterial = fireMat;
            }

        }
    }
    #endregion
}
