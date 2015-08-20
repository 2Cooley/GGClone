using UnityEngine;
using System.Collections;

public class TestZoneSub : MonoBehaviour {

    public Gameplay.Zone zone;

	// Use this for initialization
	void Start () {
        zone.zEvents.Changed += ZoneStateChange;
        Debug.Log("Subbed");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ZoneStateChange(object sender, Gameplay.ZoneEventArgs e)
    {
        if (e.EventType == Gameplay.ZoneEventTypes.OnDestroy)
        {
            Debug.Log("Zone " + zone.gameObject.name + " was destroyed");
            zone = null;
        }
        else Debug.Log("Actor " + e.ActorType + " " + e.EventType + "  " + zone.gameObject.name);
    }
}
