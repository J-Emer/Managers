using Microsoft.Xna.Framework;
using System;


namespace Managers
{
    public class WindowManager
    {
        public static WindowManager Instance;

        public event Action OnWindowStateChanged;
        public string Title
        {
            get
            {
                return _window.Title;
            }
            set
            {
                _window.Title = value;
                OnWindowStateChanged?.Invoke();
            }
        }
        public bool IsBorderless
        {
            get
            {
                return _window.IsBorderless;
            }
            set
            {
                _window.IsBorderless = value;
                OnWindowStateChanged?.Invoke();
            }
        }
        public bool AllowUserResizing
        {
            get
            {
                return _window.AllowUserResizing;
            }
            set
            {
                _window.AllowUserResizing = value;
                OnWindowStateChanged?.Invoke();
            }
        }
        public GameWindow Window
        {
            get
            {
                return _window;
            }
        }

        private GameWindow _window;

        public WindowManager(GameWindow _window, string _title = "")
        {
            this._window = _window;

            if(_title != "")
            {
                Title = _title;
            }

            Instance = this;
        }


    }
}
