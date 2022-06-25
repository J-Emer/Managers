using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Managers
{
    public class ResolutionManager
    {
        public static ResolutionManager Instance;

        private bool _isFullScreen = false;

        private List<Resolution> _allResolutions = new List<Resolution>();

        private Resolution _currentResolution;
        private Resolution _fullScreenResolution;

        /// <summary>
        /// The current Resolution of the Game
        /// </summary>
        public Resolution ActiveResolution { get; private set; }

        /// <summary>
        /// The Graphics.Viewport
        /// </summary>
        public Viewport Viewport
        {
            get
            {
                return Graphics.GraphicsDevice.Viewport;
            }
        }


        private GraphicsDeviceManager Graphics;

        public ResolutionManager(GraphicsDeviceManager _graphics, Resolution _currentResolution)
        {
            this.Graphics = _graphics;
            this._currentResolution = _currentResolution;
            this.ActiveResolution = _currentResolution;
            GetResolutions();
            SetData();
            Instance = this;
        }

        private void GetResolutions()
        {
            DisplayModeCollection _collection = Graphics.GraphicsDevice.Adapter.SupportedDisplayModes;

            foreach (var item in _collection)
            {
                _allResolutions.Add(new Resolution(item.Width, item.Height, false));
            }

            int _x = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            int _y = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _fullScreenResolution = new Resolution(_x, _y, true);
        }
        private void SetData()
        {
            Graphics.PreferredBackBufferWidth = ActiveResolution.Width;
            Graphics.PreferredBackBufferHeight = ActiveResolution.Height;
            Graphics.IsFullScreen = ActiveResolution.IsFullScreen;
            Graphics.ApplyChanges();
        }
        /// <summary>
        /// Toggles between FullScreen and not fullscreen modes
        /// </summary>
        public void ToggleFullScreen()
        {
            _isFullScreen = !_isFullScreen;

            if (_isFullScreen)
            {
                ActiveResolution = _fullScreenResolution;
            }
            else
            {
                ActiveResolution = _currentResolution;
            }

            SetData();
        }
    }
}
