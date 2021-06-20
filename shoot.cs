using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float damge = 10f;
    public float range = 100f;
    public float fireRate = 10f;
    public float impactForce = 10f;

    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 10f;
    private bool isReloading = false;

    public Animator animator;
    public AudioClip shootSound;
    public AudioSource audioSource;
    public Camera fpscCam;
    public ParticleSystem muzzeleFlash;
    public GameObject impactEffect;
    public PlayerCollect leftAmmo;


    private float nextTimeToFire = 3f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReloading)
        {
            return;
        }
        if (leftAmmo.points <= 0 && currentAmmo == 0)
        {
            return;
        }
        if (Input.GetButton("Reload") && leftAmmo.points > 0)
        {
            StartCoroutine(ReloadNMax());
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if ((Input.GetButton("Fire1") && Time.time >= nextTimeToFire) && currentAmmo > 0)
        {
            Debug.Log(currentAmmo);
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reload");

        animator.SetBool("reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("reloading", false);

        leftAmmo.points = leftAmmo.points - maxAmmo;
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    IEnumerator ReloadNMax()
    {
        isReloading = true;
        Debug.Log("Reload");

        animator.SetBool("reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("reloading", false);

        leftAmmo.points = leftAmmo.points - currentAmmo;
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        muzzeleFlash.Play();
        audioSource.PlayOneShot(shootSound);
        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpscCam.transform.position, fpscCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.TakeDamage(damge);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }

    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 300), "Ammo " + currentAmmo + " / " + leftAmmo.points);

    }

}
