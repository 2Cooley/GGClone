using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public interface IZoneHandler
    {
        void ZoneStateChange(object sender, Gameplay.ZoneEventArgs e);
    } 
}
