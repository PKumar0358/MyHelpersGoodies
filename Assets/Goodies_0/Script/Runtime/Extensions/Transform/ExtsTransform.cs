namespace Goodies_0.Exts.Trs
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class ExtsTransform 
    {
        public static void ChangeXP(this Transform t,float x,bool isLocal=false)
        {
            Vector3 p =isLocal?t.localPosition: t.position;
            p.x = x;
            if (!isLocal)
                t.position = p;
            else
                t.localPosition = p;
        }
        public static void ChangeYP(this Transform t, float val, bool isLocal = false)
        {
            Vector3 p = isLocal ? t.localPosition : t.position;
            p.y = val;
            if (!isLocal)
                t.position = p;
            else
                t.localPosition = p;
        }
        public static void ChangeZP(this Transform t, float val, bool isLocal = false)
        {
            Vector3 p = isLocal ? t.localPosition : t.position;
            p.z = val;
            if (!isLocal)
                t.position = p;
            else
                t.localPosition = p;
        }

        public static void ResetT(this Transform t,bool isLocal=true)
        {
            if (isLocal)
            {
                t.localPosition = Vector3.zero;
                t.localEulerAngles = Vector3.zero;
            }
            else
            {
                t.position = Vector3.zero;
                t.eulerAngles = Vector3.zero;
            }
            t.localScale = Vector3.one;
        }
        public static bool TryGetCompsInChildrn<T>(this Transform t,out List<T>result_,bool includeInactive=true) where T : Component
        {
            result_ =new List<T>(t.GetComponentsInChildren<T>(includeInactive));
             bool found = (result_ != null) && result_.Count > 0
;            return found;
        }

    }
}


