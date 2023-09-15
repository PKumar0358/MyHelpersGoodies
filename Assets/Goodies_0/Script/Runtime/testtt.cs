using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goodies_0.Trs;
using Goodies_0.Exts.Trs;

public class testtt : MonoBehaviour
{
    public RectTransform rct;
    public RectTransform rct2;
    public bool overlaping = false;
    public bool isInside = false;
    private void Update()
    {
      overlaping= rct.IsOverLapping(rct2);
        isInside=rct.IsInBound(rct2);
    }
}
