using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

    public GameObject Bullet;
    public GameObject Barrel;
    public bool Automatic;
    public float AutoFireInterval;
    private bool BurstFiring = false;
    private float TimeBetweenBursts = .1f;
    private int BulletsPerBurst = 3;
    private bool auto = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Automatic && !auto)
        {
            StartCoroutine("AutoFire");
            auto = true;
        }
        else if(auto && !Automatic)
        {
            StopCoroutine("AutoFire");
            auto = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !BurstFiring) StartCoroutine("BurstFire");
	}

    public void Fire()
    {
        if(!BurstFiring) StartCoroutine("BurstFire");
    }

    void FireABullet()
    {
        GameObject.Instantiate(Bullet, Barrel.transform.position, Barrel.transform.rotation);
        AudioClip clip = Resources.Load<AudioClip>("Gunshot");
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            StartCoroutine("BurstFire");
            float minTime = Mathf.Max(BulletsPerBurst * TimeBetweenBursts, AutoFireInterval);
            yield return new WaitForSeconds(minTime);
        }

    }

    IEnumerator BurstFire()
    {
        BurstFiring = true;
        for(int i = 0; i < BulletsPerBurst; i++)
        {
            FireABullet();
            yield return new WaitForSeconds(TimeBetweenBursts);
        }
        yield return new WaitForSeconds(TimeBetweenBursts);
        BurstFiring = false;
    }
}
