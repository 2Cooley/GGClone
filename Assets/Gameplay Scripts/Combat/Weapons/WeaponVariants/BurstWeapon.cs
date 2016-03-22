using UnityEngine;
using Stats;
using System.Collections;

namespace Combat.WeaponVariants
{
    public abstract class BurstWeapon : StandardWeapon
    {
        protected int BurstNumProjectiles { get; set; }
        protected bool Firing { get; set; }
        public override void Start()
        {
            base.Start();
        }

        internal override bool FireOn()
        {
            Firing = true;
            ReadyToFire = false;
            return BurstFire();
        }
        internal override bool FireOff()
        {
            return true;
        }

        protected bool StandardFire()
        {
            return base.FireOn();
        }

        protected abstract bool BurstFire();

    }
}