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
    public float playerSpeed = 50f;
    public float hor;
    public float ver;
    public float dep;

    [Header("Shooting")]
    public Transform gun;
    public GameObject bullet;
    public float fireRate = 0.2f;
    public bool canFire = true;
    public Rigidbody rb;
    public Transform rotateTowards;
    public GameManager gameManager;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector2 movement = new Vector2(-hor, -ver);
        rb.velocity = movement * playerSpeed;
        float posx = Mathf.Clamp(transform.position.x,-47,47);
        float posy = Mathf.Clamp(transform.position.y, -5, 47);
        transform.position = new Vector3(posx, posy, transform.position.z);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePosition - playerPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(angle, 270f, -90);
        // This is for shooting

        if (!classic && Input.GetButton("Fire1")&&canFire)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(other.gameObject);
            
        }
    }
}
