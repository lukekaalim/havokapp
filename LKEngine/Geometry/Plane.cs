using OpenTK.Mathematics;

namespace LKEngine.Geometry;

public static class Plane
{
  public static Vector3[] GetPlaneVertices() {
    var tl = new Vector3(0, 0, 0);
    var tr = new Vector3(0, 1, 0);
    var bl = new Vector3(1, 0, 0);
    var br = new Vector3(1, 1, 0);

    var plane = new Vector3[] {
      tl, tr, bl,
      
      bl, tr, br,
    };
    return plane;
  }
}
