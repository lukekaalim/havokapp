using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace LKEngine;

public record Graphic(VertexArray Geometry, ShaderProgram Material) {
  public Dictionary<int, Vector4> VectorUniforms = new();
  public Dictionary<int, Matrix4> MatrixUniforms = new();

  public void Render() {
      GL.UseProgram(Material);
      GL.BindVertexArray(Geometry);
      foreach (var (layout, vector) in VectorUniforms)
        GL.Uniform4(layout, vector.X, vector.Y, vector.Z, vector.W);
      foreach (var (layout, matrix) in MatrixUniforms) {
        var myMatrix = matrix;
        GL.UniformMatrix4(layout, true, ref myMatrix);
      }

      GL.DrawArrays(PrimitiveType.Triangles, 0, Geometry.Length);
  }

  public void SetUniform(string name, Vector4 value) {
    var uniformLayout = Material.Layout.Uniforms[name];
    if (VectorUniforms.ContainsKey(uniformLayout))
      VectorUniforms[uniformLayout] = value;
    else
      VectorUniforms.Add(uniformLayout, value);
  }

  public void SetMatrixUniform(string name, Matrix4 value) {
    var uniformLayout = Material.Layout.Uniforms[name];
    if (MatrixUniforms.ContainsKey(uniformLayout))
      MatrixUniforms[uniformLayout] = value;
    else
      MatrixUniforms.Add(uniformLayout, value);
  }
}
