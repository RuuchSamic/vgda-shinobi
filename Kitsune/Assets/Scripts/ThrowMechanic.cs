using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMechanic : MonoBehaviour
{

    public float offset;
    public GameObject projectile;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public Transform shotPoint;
    public Vector3 initialShot = Vector3.zero;
    public float Velocity = Projectile.svelocity;
    public AudioClip ThrowSound;

    private AudioSource SoundSource;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private float projectileCoolDown;
    private float teleportCoolDown;
    private float teleportTime;
    private float projectileTime;

    void Start()
    {
        SoundSource = GetComponent<AudioSource>();
        projectileCoolDown = 1.0f;
        teleportCoolDown = 2.0f;
    }

    // Update is called once per frame
    void Awake()
    {
       Velocity = Projectile.svelocity;
    }
    void Update()
    {
        if (Input.GetKeyDown("1") == true)
        {
            projectile = weapon1;
            Velocity = Projectile.svelocity;
        }

        if (Input.GetKeyDown("2") == true)
        {
            projectile = weapon2;
            Velocity = KunaiProjectile.svelocity;  
        }

        Vector3 difference = CameraController.instance.mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

       // if (timeBtwShots <= 0)
        //{             
            if (Input.GetMouseButtonDown(0))
            {
                
                if (projectile == weapon1)
                {
                    if (projectileTime <= Time.time)
                    {
                        SoundSource.clip = ThrowSound;
                        SoundSource.Play();
                        GameObject proj = GameObject.Instantiate(projectile, shotPoint.position, transform.rotation);
                        proj.GetComponent<Rigidbody2D>().AddForce(proj.transform.up * Velocity, ForceMode2D.Impulse);
                        projectileTime = Time.time + projectileCoolDown;
                    }
                }

                if (projectile == weapon2)
                {
                    if (teleportTime <= Time.time)
                    {
                        SoundSource.clip = ThrowSound;
                        SoundSource.Play();
                        GameObject proj = GameObject.Instantiate(projectile, shotPoint.position, transform.rotation);
                        proj.GetComponent<Rigidbody2D>().AddForce(proj.transform.up * Velocity, ForceMode2D.Impulse);
                        teleportTime = Time.time + teleportCoolDown;
                    }
                }
            }
         //}
       // else
        //{
          //  timeBtwShots -= Time.deltaTime;
        //}
    }
}
