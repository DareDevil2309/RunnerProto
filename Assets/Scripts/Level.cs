using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Path _path;
        [SerializeField] private City _city;
        
        public void Generate()
        {
            _path.Generate();
            _city.Generate();
        }
    }
}