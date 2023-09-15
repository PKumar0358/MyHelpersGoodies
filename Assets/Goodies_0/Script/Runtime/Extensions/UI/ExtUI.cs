namespace Goodies_0.Exts.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;
    public static class ExtUI
    {
        public static void AddListener(this GameObject o,UnityAction listener_)
        {
            if (o.TryGetComponent(out Button btn))
                btn.onClick.AddListener(listener_);
        }
        public static void AddListener(this Button btn,UnityAction listener_)
        {
            btn.onClick.AddListener(listener_);
        }
    }
}