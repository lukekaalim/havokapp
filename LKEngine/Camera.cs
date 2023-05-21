using OpenTK.Mathematics;

namespace LKEngine;

public class Camera
{
  public float Fov = 90;
  public Matrix4 Matrix = Matrix4.Identity;

  public Vector3 Position {
    get { return Matrix.ExtractTranslation(); }
    set { Matrix += Matrix4.CreateTranslation(value.X, value.Y, value.Z); }
  }

  public Quaternion Rotation {
    get { return Matrix.ExtractRotation(); }
    set { Matrix *= Matrix4.CreateFromQuaternion(value); }
  }

  public Matrix4 ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(70.0f), 1f, 0.1f, 100.0f);

  public Matrix4 ViewMatrix => Matrix * ProjectionMatrix;
}
