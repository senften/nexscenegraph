using System.Linq;
using System.Numerics;

namespace Veldrid.SceneGraph.Util.Shape
{
    public interface IPath : IShape
    {
        Vector3[] PathLocations { get; }
        
        Matrix4x4 StaticTransform { get; }
    }
    
    public class Path : IPath
    {
        private Vector3[] _pathLocations;
        private Matrix4x4 _staticTransform;
        
        public Vector3[] PathLocations
        {
            get { return _pathLocations.Select(x => StaticTransform.PreMultiply(x)).ToArray(); }
        }

        public Matrix4x4 StaticTransform => _staticTransform;

        public static IPath Create(Vector3[] pathLocations)
        {
            return new Path(pathLocations);
        }
        
        public static IPath Create(Vector3[] pathLocations, Matrix4x4 staticTransform)
        {
            return new Path(pathLocations, staticTransform);
        }
        
        internal Path(Vector3[] pathLocations)
        {
            _pathLocations = pathLocations;
            _staticTransform = Matrix4x4.Identity;
        }
        
        internal Path(Vector3[] pathLocations, Matrix4x4 staticTransform)
        {
            _pathLocations = pathLocations;
            _staticTransform = staticTransform;
        }
        
        public void Accept(IShapeVisitor shapeVisitor)
        {
            shapeVisitor.Apply(this);
        }
    }
}