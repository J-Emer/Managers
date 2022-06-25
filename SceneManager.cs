using System;
using System.Collections.Generic;
using System.Linq;


namespace Managers
{
    public class SceneManager
    {
        public static SceneManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new SceneManager();
                }
                return _instance;
            }
        }
        
        private static SceneManager _instance;

        private List<Scene> _scenes = new List<Scene>();


        public event Action OnBeforeLoadScene;
        public event Action OnAfterLoadScene;

        public Scene ActiveScene { get; private set; }

        public bool NeedsSceneChange { get; private set; } = true;




        public void Add(Scene _scene)
        {
            _scenes.Add(_scene);
        }
        public void Remove(Scene _scene)
        {
            _scenes.Remove(_scene);
        }
        public void Load(string _sceneName)
        {
            Scene _nextScene = _scenes.FirstOrDefault(x => x.SceneName == _sceneName);

            if(_nextScene == null)
            {
                throw new Exception($"Could not find Scene: {_sceneName}");
            }


            OnBeforeLoadScene?.Invoke();

            NeedsSceneChange = true;

            if (ActiveScene != null)
            {
                ActiveScene.Unload();
            }

            ActiveScene = _nextScene;
            _nextScene = null;
            ActiveScene.Load();

            OnAfterLoadScene?.Invoke();

            NeedsSceneChange = false;
        }

    }
}
