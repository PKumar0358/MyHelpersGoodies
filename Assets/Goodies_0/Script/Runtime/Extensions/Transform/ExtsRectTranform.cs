namespace Goodies_0.Exts.Trs
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class ExtsRectTranform
    {
        public static bool IsOverLapping(this RectTransform rct,RectTransform otherRect)
        {
            Bounds thisbound=GetBounds(rct);
            Bounds otherbound=GetBounds(otherRect);
            return thisbound.Intersects(otherbound);
        }
        /// <summary>
        /// to check if other is in this rect's bounding area
        /// </summary>
        public static bool IsInBound(this RectTransform rct,RectTransform other)
        {
            Bounds thisbound = GetBounds(rct);
            Vector3[] corners = new Vector3[4];
            other.GetWorldCorners(corners);
            bool yes = true;
            for (int i = 1; i < 4; i++)
            {
                if (!thisbound.Contains(corners[i]))
                {
                    yes = false;
                    break;
                }
            }
            return yes;
        }
        private static Bounds GetBounds(RectTransform rct)
        {
            Vector3[] corners = new Vector3[4];
            rct.GetWorldCorners(corners);
            Bounds bounds = new Bounds(corners[0], Vector3.zero);
            for (int i = 1; i < 4; i++)            
                bounds.Encapsulate(corners[i]);
            return bounds;
        }

    }
}


