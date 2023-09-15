namespace Goodies_0.Trs
{

    using UnityEngine;
    using UnityEngine.Events;

    public class PositionUpdate : MonoBehaviour
    {
        [SerializeField] UnityEvent<Vector3> OnPositionChanged;
        Vector3 previousPosition;
        [SerializeField] bool notifyOnEnable = false;
        private void OnEnable()
        {
            UpdateController.AddUpdateListener(OnUpdate);
            previousPosition=transform.position;
            if(notifyOnEnable )
            OnPositionChanged?.Invoke(previousPosition);
        }
        private void OnDisable()
        {
            UpdateController.RemoveUpdateListener(OnUpdate);            
        }
        private void OnUpdate()
        {
            Vector3 p= transform.position;
            if (transform.position != previousPosition)
            {
                previousPosition = p;
                OnPositionChanged?.Invoke(p);
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
    }
}
