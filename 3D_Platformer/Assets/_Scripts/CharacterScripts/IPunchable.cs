using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AstronautPlayer
{
    public interface IPunchable
    {
        public void OnHit(Vector3 hitDirection, float hitForce);
    }
}
