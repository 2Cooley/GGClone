using UnityEngine;
using System.Collections;
using Stats;
using Combat.WeaponVariants;

public class TestScript : MonoBehaviour {

    public Vector3 Velocity;
    public StandardWeapon Wep;

	void Start () {
        WeaponStats stats = new WeaponStats("Pistol", Combat.Weapons.Pistol, .05f, 20, Combat.ProjectileTypes.Bullet, 10, 30, 0);
        Wep = this.GetComponent<Pistol>();
        Wep.Stats = stats;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) Wep.FireOn();
        else if (Input.GetKeyUp(KeyCode.E)) Wep.FireOff();
	}
}
