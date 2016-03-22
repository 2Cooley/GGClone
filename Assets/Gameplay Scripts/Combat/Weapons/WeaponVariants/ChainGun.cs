using UnityEngine;
using System.Collections;
using Stats;

namespace Combat.WeaponVariants
{
    public class ChainGun : AutoWeapon
    {
        public float SpinUpTime;
        public override void Start()
        {
            base.Start();
        }

        protected override bool StartAutoFire()
        {
            StartCoroutine(AutoFire());
            return true;
        }

        protected override bool StopAutoFire()
        {
            Firing = false;
            return true;
        }

        private IEnumerator AutoFire()
        {
            //Play Spin up sound
            Firing = true;
            yield return new WaitForSeconds(SpinUpTime);
            while(Firing)
            {
                StandardFire();
                yield return new WaitForSeconds(Stats.FireRate);
            }
        }


    }
    
}