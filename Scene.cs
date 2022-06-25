

namespace Managers
{
    public abstract class Scene
    {
        public string SceneName { get; }
        public Scene(string _sceneName)
        {
            this.SceneName = _sceneName;
            SceneManager.Instance.Add(this);
        }


        public abstract void Load();
        public virtual void Unload() { }
    }
}
