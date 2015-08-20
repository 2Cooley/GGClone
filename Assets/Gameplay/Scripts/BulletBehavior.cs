using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public float Speed;

    //-1 for infinity
    [Range(-1, 4)]public int Range;
    //List of ranges for bullets. Ordered from: Infinity, zero, very short,  short, medium, long, very long
    private readonly float[] Ranges = {0f, 5f, 10f, 20f, 50f};
    private float MaxDistance;
    private float DistanceMoved = 0;

	// Use this for initialization
	void Start () {
        if (Range == -1) MaxDistance = -1;
        else MaxDistance = Ranges[Range];
	}
	
	// Update is called once per frame
	void Update () {
        MoveBullet();
	}

    void MoveBullet()
    {
        Vector3 pos = transform.position;
        this.transform.position += this.transform.forward * Speed * Time.deltaTime;
        DistanceMoved += Vector3.Distance(pos, transform.position);
        if (DistanceMoved > MaxDistance) Destroy(this.gameObject);
    }

    void OnTriggerEnter()
    {

    }
}
