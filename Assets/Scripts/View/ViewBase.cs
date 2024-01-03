using System;
using UnityEngine;

namespace View
{
    public abstract class ViewBase : MonoBehaviour
    {
        private void Awake()
        {
            Hide();
        }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
