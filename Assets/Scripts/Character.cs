using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace DefaultNamespace
{
    public class Character : Pawn
    {
        [SerializeField] private Path _path;
        [SerializeField] private float _movementSpeed;

        private float _distance;
        
        public void Update()
        {
            _distance += _movementSpeed * Time.deltaTime;
            var t = SplineUtility.GetNormalizedInterpolation(_path.Value, _distance, PathIndexUnit.Distance);
            transform.position = _path.Value.EvaluatePosition(t);
            transform.forward = math.normalize(_path.Value.EvaluateTangent(t));
        }
    }
}