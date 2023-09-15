namespace Goodies_0.Trs
{
    using TreeEditor;
    using UnityEngine;

    public class MyTrs : PositionUpdate
    {
        public Vector3 Position
        {
            get=>transform.position;
            set
            {
               transform.position = value;
            }
        }

        public void SetPosition(Vector3 value_,bool isLocal=false)
        {
            if(isLocal)
               transform.localPosition = value_;
            else transform.position = value_;
        }

        public void SetAngles(Vector3 value_,bool isLocal=false)
        {
            if(isLocal)
                transform.localEulerAngles = value_;
            else transform.eulerAngles = value_;
        }
        public void SetScale(Vector3 value_)
        {
           transform.localScale = value_;
        }
    }

}