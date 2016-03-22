using UnityEngine;
using Stats;
using System.Collections;

namespace Combat.WeaponVariants
{
    public abstract class AutoWeapon : StandardWeapon
    {
        protected bool Firing { get; set; }
        public override void Start()
        {
            base.Start();
        }

        internal override bool FireOn()
        {
            if (!Firing) return StartAutoFire();
            else return true;
        }

        internal override bool FireOff()
        {
            return StopAutoFire();
        }

        protected bool StandardFire()
        {
            return base.FireOn();
        }

        protected abstract bool StartAutoFire();
        protected abstract bool StopAutoFire();

    }
}