using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotRay : MonoBehaviour
{

    public int damagePerShot = 10;
    public float range = 100f;
    public int shootableMask = 0;
    public LineRenderer gunLine;

    Ray shootRay = new Ray();
    RaycastHit shootHit;
    

    

    // Start is called before the first frame update
    void Start()
    {
        gunLine = GetComponent <LineRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableEffects ()
    {
        //disable line renderer
        gunLine.enabled = false;
    }

    public void Shoot()
    {
        //enable Line renderer dan set first position
        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);
        // gunLine.transform.rotation.y = angle;
        // gunLine.SetRotation(0, transform.rotation.y+angle);
 
        //Set posisi ray shoot dan direction
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
 
        //Lakukan raycast jika mendeteksi id nemy hit apapun
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            //Lakukan raycast hit hace component Enemyhealth
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
 
            if(enemyHealth != null)
            {
                
                //Lakukan Take Damage
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
 
            //Set line end position ke hit position
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            //set line end position ke range freom barrel
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
        Debug.Log(gunLine.GetPosition(1));
    }
}
