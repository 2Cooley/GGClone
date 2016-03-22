using UnityEngine;
using System.Collections;

namespace Combat.WeaponVariants
{
    public class M16 : BurstWeapon
    {
        public int NumProj = 3;
        public override void Start()
        {
            BurstNumProjectiles = NumProj;
            base.Start();
        }
        protected override bool BurstFire()
        {
            StartCoroutine(StartBurst(BurstNumProjectiles));
            return true;
        }

        protected IEnumerator StartBurst(int numRounds)
        {
            int i = 0;
            while(Firing)
            {
                StandardFire();
                i++;
                if (i >= numRounds)
                {
                    ReadyToFire = true;
                    Firing = false;
                }
                else yield return new WaitForSeconds(Stats.FireRate);
            }
        }
    } 
}
