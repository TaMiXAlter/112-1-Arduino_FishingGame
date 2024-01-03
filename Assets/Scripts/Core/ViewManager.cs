using System;
using Tool;
using UnityEngine;
using View;

namespace Core
{
    public class ViewManager : MySingleton<ViewManager>
    {
        [SerializeField]private ViewBase _startView;
        private ViewBase _currentView;

        private void Start()
        {
            _currentView = _startView ;
            _currentView.Show();
        }

        public void SwitchView(ViewBase _nextView)
        {
            _currentView.Hide();
            _currentView = _nextView;
            _nextView.Show();
        }
    }
}
