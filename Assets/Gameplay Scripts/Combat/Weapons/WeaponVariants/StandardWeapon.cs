using UnityEngine;
using System.Collections;
using Stats;
using System.Threading;

namespace Combat.WeaponVariants
{
    public abstract class StandardWeapon : MonoBehaviour
    {
        
        internal Transform BarrelTransform { get; set; }
        internal WeaponStats Stats { get; set; }
        internal bool ReadyToFire { get; set; }

        public virtual void Start()
        {
            BarrelTransform = gameObject.transform;
            ReadyToFire = true;
        }

        internal virtual bool FireOn()
        {
            GameObject g = Projectile.InstantiateProjectile(Stats.ProjectileType, BarrelTransform);
            Projectile p = g.AddComponent<Projectile>();
            if (p == null) return false;
            Projectile.InitProj(p, BarrelTransform, Stats.ProjectileType, Stats.ProjectileSpeed, Stats.ProjectileDamage, Stats.Range);
            //Produce Sound
            //Create relevant alert to enemies
            return true;
        }

        internal abstract bool FireOff();
        
    }   
}