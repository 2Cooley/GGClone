using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit by " + other.gameObject.name);
    }
}
