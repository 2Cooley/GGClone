using UnityEngine;
using System.Collections;
using Stats;

namespace Combat.WeaponVariants
{
	public class Pistol : StandardWeapon
    {
        public override void Start()
        {
            base.Start();
        }

        internal override bool FireOn()
        {
            bool b = base.FireOn();
            ReadyToFire = false;
            StartCoroutine(EnforceMinCooldown());
            return b;
        }

        internal override bool FireOff()
        {
            return true;
        }

        private IEnumerator EnforceMinCooldown()
        {
            yield return new WaitForSeconds(Stats.FireRate);
            ReadyToFire = true;
        }
    } 
}
