using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed;
    public float fireRate;

    public Material[] materialVariations;

    private bool isFiring = false;

    public SteamVR_Action_Boolean triggerBoolean;
    public SteamVR_Input_Sources handType;

    public void EnableListeners()
    {
        triggerBoolean.AddOnStateDownListener(StartFire, handType);
        triggerBoolean.AddOnStateUpListener(CeaseFire, handType);
    }

    public void DisableListeners()
    {
        CeaseFire();
        triggerBoolean.RemoveAllListeners(handType);
    }

    public void StartFire(SteamVR_Action_Boolean function, SteamVR_Input_Sources fromSource)
    {
        if (!isFiring)
        {
            isFiring = true;
            StartCoroutine(FireCoroutine());
        }
    }

    public void CeaseFire(SteamVR_Action_Boolean function, SteamVR_Input_Sources fromSource)
    {
        isFiring = false;
        StopAllCoroutines();
    }

    public void CeaseFire()
    {
        isFiring = false;
        StopAllCoroutines();
    }

    private IEnumerator FireCoroutine()
    {
        while (isFiring)
        {
            int i = UnityEngine.Random.Range(0, materialVariations.Length);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bullet.GetComponent<BallReset>().Thrown();

            bulletRigidbody.velocity = transform.forward * bulletSpeed;

            Destroy(bullet, 6f);

            yield return new WaitForSeconds(fireRate);
        }
    }

}
