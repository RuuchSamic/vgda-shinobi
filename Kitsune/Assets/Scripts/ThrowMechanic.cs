using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMechanic : MonoBehaviour {

    public float offset;
    public GameObject projectile;
    public GameObject weapon1;
    public GameObject weapon2;
    public Transform shotPoint;
    public Vector3 initialShot = Vector3.zero;

    private float timeBtwShots;
    public float startTimeBtwShots;
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1") == true)
        {
            projectile = weapon1;
        }

        if (Input.GetKeyDown("2") == true)
        {
            projectile = weapon2;
        }

        Vector3 difference = CameraController.instance.mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                initialShot = shotPoint.position;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public Vector3 getinitialShot()
    {
        return initialShot;
    }

}
