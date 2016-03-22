using UnityEngine;
using System.Collections;

namespace Combat
{
    public class Projectile : MonoBehaviour
    {
        private Vector3 ProjOrigin;
        public DamageTypes DamType;
        [Range(0,100)] public float Speed;
        public float ProjectileRange;
        public int Damage;

        private float CreationTime { get; set; }
        private float TimeSinceCreation { get { return Time.time - CreationTime; } set { } }

        void Awake()
        {
            CreationTime = Time.time;
        }

        void Start()
        {
            ProjOrigin = gameObject.transform.position;
        }

        void Update()
        {
            UpdatePosition();
        }

        void LateUpdate()
        {
            if (MaxDistanceReached()) MarkForDeletion(this);
        }

        internal static Projectile InitProj(Projectile p, Transform locAndDir, ProjectileTypes projType, float speed, int damage, float projRange)
        {
            if ((locAndDir == null) || (projType == null) || speed <= 0) return null;
            p.ProjOrigin = p.transform.position; p.DamType = GetDamageType(projType);
            p.Speed = speed; p.Damage = damage; p.ProjectileRange = projRange;
            return p;
        }

        internal static void MarkForDeletion(Projectile proj)
        {
            Destroy(proj.gameObject);
        }

        internal static GameObject InstantiateProjectile(ProjectileTypes type, Transform locAndDir)
        {
            GameObject p = Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
            p.transform.position = locAndDir.position;
            p.transform.forward = locAndDir.forward;
            return p;
        }

        private bool MaxDistanceReached()
        {
            return Vector3.Distance(this.gameObject.transform.position, ProjOrigin) > ProjectileRange;
        }

        private static DamageTypes GetDamageType(ProjectileTypes projType)
        {
            switch (projType)
            {
                case ProjectileTypes.Bullet:
                    return DamageTypes.Normal;
                case ProjectileTypes.BulletArmPierce:
                    return DamageTypes.AntiArmor;
                case ProjectileTypes.BulletHollowPoint:
                    return DamageTypes.AntiPersonel;
                case ProjectileTypes.Shuriken:
                    return DamageTypes.SoftTargetOnly;
                case ProjectileTypes.Fireball:
                    return DamageTypes.SoftTargetOnly;
                case ProjectileTypes.Rocket:
                    return DamageTypes.AntiArmor;
                case ProjectileTypes.Grenade:
                    return DamageTypes.AntiArmor;
                case ProjectileTypes.Arrow:
                    return DamageTypes.SoftTargetOnly;
                default:
                    return DamageTypes.Normal;
            }
        }

        private void UpdatePosition()
        {
            this.transform.position = ProjOrigin + transform.forward * Speed * TimeSinceCreation;
        }
    }
}
