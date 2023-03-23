using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Mode")]
    public bool twinstick = false;
    public bool mouseaim = false;
    public bool classic = false;

    [Header ("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
    public float dep;

    [Header("Shooting")]
    public Transform gun;
    public GameObject bullet;
    public float fireRate = 0.5f;
    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        if (twinstick)
        {
            gun.GetComponent<TwinStickAim>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;
        }
        else if (classic)
        {
            gun.GetComponent<TwinStickAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        // This is for moving the player
        transform.Translate(new Vector3(hor*playerSpeed*Time.deltaTime,ver*playerSpeed*Time.deltaTime,0));
        
        // This is for shooting

        if(!classic && Input.GetButton("Fire1")&&canFire)
        {
            StartCoroutine("Shoot");
        }
    }

    public IEnumerator Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
