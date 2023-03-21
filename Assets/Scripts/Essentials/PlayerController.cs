using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
    public float dep;

    [Header("Shooting")]
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        // This is for moving the player
        transform.Translate(new Vector3(hor*playerSpeed*Time.deltaTime,ver*playerSpeed*Time.deltaTime,0));
        
        // This is for shooting

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
