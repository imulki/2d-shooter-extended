using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
 
public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.3f;
    public float range = 100f;

    private int bulletLines = 1;
    public int maxBulletLines = 7; 
    public int maxBulletLinesRadius = 120; // 120 Derajat 
    // Create new line of bullets for every maxDiagonalRadius/maxDiagonalBullets

    public int maxDamage = 50;
    public float maxRange = 200f; 
 
    public TextMeshProUGUI damageText;
    public GameObject gunShotRay;
 
    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    List<GameObject> gunShotRayList = new List<GameObject>();
 
    void Awake ()
    {
        //GetMask
        shootableMask = LayerMask.GetMask ("Shootable");
 
        //Mendapatkan Reference component
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }
 
    void Start()
    {
        if (damageText != null) damageText.text = damagePerShot.ToString();
        RefreshGunShotRayList();
    }
 
    void Update ()
    {
 
        timer += Time.deltaTime;
 
//         if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
//         {
//             Shoot ();
//         }
 
        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }
 
 
    public void DisableEffects ()
    {
        //disable line renderer
        gunLine.enabled = false;
 
        //disable light
        gunLight.enabled = false;

        for (int i=0; i<gunShotRayList.Count; i++) 
        {
            GunShotRay gunNoseScript = gunShotRayList[i].GetComponent<GunShotRay>();
            gunNoseScript.DisableEffects();
        }
    }

    public void addBulletLines(int extra){
        if(bulletLines + extra > maxBulletLines) return; 
        bulletLines += extra; 
        this.RefreshGunShotRayList();
    }
 
 
    public void Shoot ()
    {
        if (timer < timeBetweenBullets || Time.timeScale == 0)
        {
            return;
        } 

        timer = 0f;

        //Play audio
        gunAudio.Play ();
 
        //enable Light
        gunLight.enabled = true;
 
        //Play gun particle
        gunParticles.Stop ();
        gunParticles.Play ();

        //-------------------------------------//
        // TEST: THIS IS FOR DIAGONAL SHOOTING //
        //-------------------------------------//

        for (int i=0; i<gunShotRayList.Count; i++) 
        {
            GunShotRay gunNoseScript = gunShotRayList[i].GetComponent<GunShotRay>();
            gunNoseScript.damagePerShot = damagePerShot;
            gunNoseScript.shootableMask = shootableMask;
            gunNoseScript.range = range;

            gunNoseScript.Shoot();
        }

        return;

        //----------//
        // END TEST //
        //----------//        
 
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
        // Debug.Log(gunLine.GetPosition(1));
    }

    public void RefreshGunShotRayList() 
    {
        int diff = gunShotRayList.Count - bulletLines;
        if (diff < 0)
        {
            for (int i=0; i< -diff; i++)
            {
                GameObject gunNose = Instantiate(gunShotRay);
                gunNose.transform.Translate(gameObject.transform.position);
                gunNose.transform.parent = gameObject.transform;
                gunShotRayList.Add(gunNose);
            }
        } else if (diff > 0)
        {
            for (int i=0; i< diff; i++)
            {
                GameObject gunNose = gunShotRayList[i];
                gunShotRayList.RemoveAt(i);
                Destroy(gunNose);
            }
        }

        int anglePerRay = maxBulletLinesRadius/(gunShotRayList.Count);

        for (int i=0; i<gunShotRayList.Count; i++)
        {
            GameObject gunShotRay = gunShotRayList[i];
            gunShotRay.transform.rotation = new Quaternion();
            float angle = (anglePerRay*i) + anglePerRay/2 - maxBulletLinesRadius/2;
            gunShotRay.transform.Rotate(0, angle, 0);
        }
    }
}