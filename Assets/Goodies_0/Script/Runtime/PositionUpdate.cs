namespace Goodies_0.Trs
{

    using UnityEngine;
    using UnityEngine.Events;

    public class PositionUpdate : MonoBehaviour
    {
        [SerializeField]protected UnityEvent<Vector3> OnPositionChanged;
        Vector3 previousPosition;
        [SerializeField] bool notifyOnEnable = false;
        [SerializeField]bool dontNotify=false;
        protected virtual void OnEnable()
        {
            if (!dontNotify)
            {
                UpdateController.AddUpdateListener(OnUpdate);
                previousPosition = transform.position;
                if (notifyOnEnable)
                    OnPositionChanged?.Invoke(previousPosition);
            }
        }
        protected virtual void OnDisable()
        {
            if (!dontNotify)
            {
                UpdateController.RemoveUpdateListener(OnUpdate);
            }           
        }
        protected virtual void OnUpdate()
        {
            if (!dontNotify)
            {
                Vector3 p = transform.position;
                if (transform.position != previousPosition)
                {
                    previousPosition = p;
                    OnPositionChanged?.Invoke(p);
                }
            }
        }

        public void AddListener(UnityAction<Vector3>listener)
        {
            OnPositionChanged.AddListener(listener);
        }
        public void RemoveListener(UnityAction<Vector3> listener)
        {
            OnPositionChanged.RemoveListener(listener);
        }
        public void StopNotifying()
        {
            if (!dontNotify)
            {
                dontNotify = true;
                UpdateController.RemoveUpdateListener(OnUpdate);
            }
        }
    }
}
