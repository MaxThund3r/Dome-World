using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunShootBullet : MonoBehaviour {

    public Animator animationTest;
    public int Ammo;
    public int ammoMax;
    public Text bulletCount;
    public GameObject particle;
    public bool enabled1 = true;
    public Vector3 localSpace;

    // Update is called once per frame
    void Start() {
        StartCoroutine(test());
        StartCoroutine(Shoot());
    }

    private void OnEnable()
    {
        StartCoroutine(test());
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if(Ammo > ammoMax)
        {
            Ammo = ammoMax;
        }
        bulletCount.text = "Balas:" + Ammo.ToString();

        
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && Ammo > 0 && enabled1)
            {
                RaycastHit hit;
                Ammo--;

                Instantiate(particle, transform.position, transform.rotation * Quaternion.Euler(0,90,0));
                if (Physics.Raycast(transform.position, transform.right, out hit, 100))
                {
                    Instantiate(particle, hit.point, Quaternion.LookRotation(hit.normal));
                }
                yield return new WaitForSeconds(.3f);
            }
            if (Input.GetKeyDown(KeyCode.R) && enabled1)
            {
                Ammo = ammoMax;
                yield return new WaitForSeconds(.3f);
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator test()
    {
        while (true)
        {
            if (Ammo > 0 && enabled1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    animationTest.SetBool("Shoot", true);
                    animationTest.SetBool("Idle", false);
                    yield return new WaitForSeconds(0.2f);
                    animationTest.SetBool("Shoot", false);
                    animationTest.SetBool("Idle", true);
                }
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
