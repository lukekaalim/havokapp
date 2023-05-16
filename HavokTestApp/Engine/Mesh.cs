using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using System;
using System.Linq;

namespace HavokTestApp.Engine;

public record Mesh(Vector3[] Vertices, ShaderProgram Shader) {
  public sealed record Binding(
    int VertexArrayObject,
    int VertexBufferObject,
    ShaderProgram.Binding BoundShader,
    Mesh From
  ): IDisposable {
    public void SetUniform(string name, Vector4 value) {
      var uniformLayout = BoundShader.UniformHandles[name];
      GL.UseProgram(BoundShader.ProgramHandle);
      GL.Uniform4(uniformLayout, value.X, value.Y, value.Z, value.W);
    }
    public void SetMatrixUniform(string name, ref Matrix4 value) {
      var uniformLayout = BoundShader.UniformHandles[name];
      GL.UseProgram(BoundShader.ProgramHandle);
      GL.UniformMatrix4(uniformLayout, true, ref value);
    }

    public void Dispose() {
      GL.DeleteBuffer(VertexBufferObject);
      GL.DeleteVertexArray(VertexArrayObject);
    }
    
    public void Render() {
      GL.UseProgram(BoundShader.ProgramHandle);
      GL.BindVertexArray(VertexArrayObject);
      GL.DrawArrays(PrimitiveType.Triangles, 0, From.Vertices.Length * 3);
    }
  }

  public Binding Bind(ShaderProgram.Binding boundShader) {
    var vertexBufferObject = GL.GenBuffer();
    GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
    var vertexData = Vertices
      .SelectMany(v => new float[] { v.X, v.Y, v.Z })
      .ToArray();
    GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);
    
    var vertexArrayObject = GL.GenVertexArray();
    GL.BindVertexArray(vertexArrayObject);

    var attributeIndex = boundShader.AttributeHandles["aPosition"];

    GL.VertexAttribPointer(attributeIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
    GL.EnableVertexAttribArray(attributeIndex);

    return new Binding(vertexArrayObject, vertexBufferObject, boundShader, this);
  }
}