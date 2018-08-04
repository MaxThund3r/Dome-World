using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunShootBullet : MonoBehaviour {

    public Animator animationTest;
    public int Ammo;
    public int ammoMax;
    public Text bulletCount;

    // Update is called once per frame
    void Start() {
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
            if (Input.GetMouseButton(0) && Ammo > 0)
            {
                RaycastHit hit;
                Ammo--;
                if (Physics.Raycast(transform.position, -transform.forward, out hit, 20))
                {

                }
                yield return new WaitForSeconds(.3f);
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator test()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animationTest.SetBool("Shoot", true);
                animationTest.SetBool("Idle", false);
                yield return new WaitForSeconds(0.5f);
                animationTest.SetBool("Shoot", false);
                animationTest.SetBool("Idle", true);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Ammo = ammoMax;
                yield return new WaitForSeconds(.3f);
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
