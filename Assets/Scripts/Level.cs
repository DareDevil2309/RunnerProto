using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        [Header("Path")] [SerializeField] private int _pointsCount;
        [SerializeField] private int _pointRadius;
        [SerializeField] private int _pathLength;
        [SerializeField] private int _pathSeed;

        [Header("Buildings")]
        [SerializeField] private float _cellSize;
        [SerializeField] private float _cityWidth;
        [SerializeField] private float _streetWidth;
        [SerializeField] private float _maxHeight;
        [SerializeField] private int _seed = 0;
        [SerializeField] [HideInInspector] private Spline _path;
        
        public void GeneratePath()
        {
            _path = SplineGenerator.Generate(_pathLength, _pointsCount, _pointRadius, _pathSeed);
            GetComponent<SplineContainer>().Spline = _path;
        }
        
        public void GenerateBuildings()
        {
            var mesh = MeshGenerator.Generate(_path, _cityWidth, _streetWidth, _cellSize, _maxHeight, _seed);
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }
}