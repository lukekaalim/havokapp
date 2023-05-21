using OpenTK.Mathematics;

namespace LKEngine.Geometry;

public static class Cube
{
  public static Vector3[] GetCubeVertices(float size = 1f) {
    var forward = Matrix4.CreateTranslation(1f, 1f, 10f);

    var faceRotations = new Matrix4[] {
      Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0)),
      Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90)),
      Matrix4.CreateRotationX(MathHelper.DegreesToRadians(180)),
      Matrix4.CreateRotationX(MathHelper.DegreesToRadians(270)),

      Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90)),
      Matrix4.CreateRotationY(MathHelper.DegreesToRadians(270)),
    };

    return faceRotations.SelectMany(rotation => {
      return Plane.GetPlaneVertices()
        .Select(vertex => (vertex - new Vector3(0.5f, 0.5f, 0)) * size)
        .Select(vertex => (new Vector4(vertex) + new Vector4(0, 0, size / 2f, 0)) * rotation)
        .Select(vertex => new Vector3(vertex));
    }).ToArray();
  }
}
