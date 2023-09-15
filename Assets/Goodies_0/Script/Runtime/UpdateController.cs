namespace Goodies_0
{
    using UnityEngine;
    using System;
    public class UpdateController : MonoBehaviour
    {
        private Action OnPreUpdate;
        private Action OnUpdate;
        private Action OnPostUpdate;
        private Action OnLateUpdate;
        private Action OnFixUpdate;
        private static UpdateController mInstance;
        private static UpdateController Instance
        {
            get
            {
                if (mInstance == null)
                {
                    GameObject g = new GameObject("UpdateController");
                    DontDestroyOnLoad(g);
                    mInstance= g.AddComponent<UpdateController>();
                }
                return mInstance;
            }
        }
        private void Update()
        {
            OnPreUpdate?.Invoke();
            OnUpdate?.Invoke();
            OnPostUpdate?.Invoke();
        }
        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
        private void FixedUpdate()
        {
            OnFixUpdate?.Invoke();
        }
        public static void AddUpdateListener(Action listener_)
        {
            Instance.OnUpdate += listener_;
        }
        public static void RemoveUpdateListener(Action listener_)
        {
            Instance.OnUpdate -= listener_;
        }

        public static void AddPreUpdateListener(Action listener_)
        {
            Instance.OnPreUpdate += listener_;
        }
        public static void RemovePreUpdateListener(Action listener_)
        {
            Instance.OnPreUpdate -= listener_;
        }

        public static void AddPostUpdateListener(Action listener_)
        {
            Instance.OnPostUpdate += listener_;
        }
        public static void RemovePostUpdateListener(Action listener_)
        {
            Instance.OnPostUpdate -= listener_;        
        }

        public static void AddLateUpdateListener(Action listener_)
        {
            Instance.OnLateUpdate += listener_;
        }
        public static void RemoveLateUpdateListener(Action listener_)
        {
            Instance.OnLateUpdate -= listener_;
        }

        public static void AddFixedUpdateListener(Action listener_)
        {
            Instance.OnFixUpdate += listener_;
        }

        public static void RemoveFixedUpdateListener(Action listener_)
        {
            Instance.OnFixUpdate -= listener_;
        }
    }

}
