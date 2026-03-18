using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace DefaultNamespace
{
    public class Path : MonoBehaviour
    {
        [HideInInspector] public Spline Value;
        
        [SerializeField] private SplineContainer _splineContainer;
        [SerializeField] private int _pointsCount;
        [SerializeField] private int _pointRadius;
        [SerializeField] private int _length;
        [SerializeField] private int _seed;
        
        public void Generate()
        {
            Value = GenerateSpline(_length, _pointsCount, _pointRadius, _seed);
            _splineContainer.Spline = Value;
        }
        
        public static Spline GenerateSpline(int pathLength, int pointsCount, int pointRadius, int seed = 0)
        {
            var rand = seed != 0 ? new System.Random(seed) : new System.Random();
            var segmentLength = (float)pathLength / pointsCount;

            var result = new Spline();
        
            for (int pointIndex = 0; pointIndex < pointsCount; pointIndex++)
            {
                var offset = pointIndex > 0 || pointIndex == pointsCount - 1
                    ? new Vector3(rand.Next(-pointRadius, pointRadius), rand.Next(-pointRadius, pointRadius),
                        rand.Next(-pointRadius, pointRadius))
                    : new Vector3();
            
                result.Add(new BezierKnot(new float3(segmentLength * pointIndex + offset.x, offset.y, offset.z)));
                result.SetTangentMode(pointIndex, TangentMode.AutoSmooth);
            }
            return result;
        }
    }
}