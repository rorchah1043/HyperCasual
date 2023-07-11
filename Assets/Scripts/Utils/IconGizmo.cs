using System;
using UnityEngine;

namespace Utils
{
    public class IconGizmo : MonoBehaviour
    {
        public String spriteFile;
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, spriteFile);
        }
    }
}