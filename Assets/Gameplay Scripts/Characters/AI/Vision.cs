using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vision : MonoBehaviour {

    [System.Serializable]
    public class Target
    {
        public GameObject target;
        public bool CanSee;
    }

    public Target[] ListOfPossibleTargets;
    public ArrayList ListOfVisibleTargets;
    [Range (-180f, 180f)]public float Angle;
    public float MaxDistance;
    public float CheckFrequency;
    //Makes it so check intervals get reset every time you set a new value
    private float OldCheckFrequency;

    void Awake()
    {
        ListOfVisibleTargets = new ArrayList();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine("LookForTargets");
        OldCheckFrequency = CheckFrequency;
	}
	
	// Update is called once per frame
	void Update () {
        if(OldCheckFrequency != CheckFrequency)
        {
            StopCoroutine("LookForTargets");
            StartCoroutine("LookForTargets");
        }
        OldCheckFrequency = CheckFrequency;
	}

    IEnumerator LookForTargets()
    {
        while(true)
        {
            ListOfVisibleTargets = new ArrayList();
            foreach (Target t in ListOfPossibleTargets)
            {
                t.CanSee = CanSee(t.target);
                if (t.CanSee) ListOfVisibleTargets.Add(t.target);
            }
            if (CheckFrequency <= 0) CheckFrequency = 0;
            yield return new WaitForSeconds(CheckFrequency);
        }
    }

    public bool CanSee(GameObject target)
    {
        bool canSee = Vector3.Angle(transform.forward, target.transform.position - transform.position) < Angle
            && Vector3.Distance(transform.position, target.transform.position) < MaxDistance;
        if(canSee)canSee &= ObjectIsNotBlocked(target);
        Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(Angle, Vector3.up) * transform.forward * 10);
        Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(-Angle, Vector3.up) * transform.forward * 10);
        return canSee;
    }

    bool ObjectIsNotBlocked(GameObject objLookingFor)
    {
        RaycastHit info;
        Physics.Raycast(transform.position, objLookingFor.transform.position - transform.position, out info);
        return  info.collider != null && info.collider.gameObject == objLookingFor.gameObject;
    }
}
