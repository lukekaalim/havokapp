using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace LKEngine;

public record VertexArray(int Handle, int Length) {
  public static implicit operator int(VertexArray arr) => arr.Handle;
  
  public static VertexArray CreateFromBuffer(
    VertexBuffer buffer,
    ShaderLayout layout,
    string attribute = "aPosition"
  ) {
    var vertexArrayObjectHandle = GL.GenVertexArray();

    GL.BindVertexArray(vertexArrayObjectHandle);
    GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);

    var attributeIndex = layout.Attributes[attribute];

    GL.VertexAttribPointer(attributeIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
    GL.EnableVertexAttribArray(attributeIndex);

    return new VertexArray(vertexArrayObjectHandle, buffer.Length);
  }
}

public record VertexBuffer(int Handle, int Length) {
  public static implicit operator int(VertexBuffer geo) => geo.Handle;

  public static VertexBuffer CreateFromVertices(Vector3[] vertices) {
    var vertexBufferObject = GL.GenBuffer();
    GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
    var vertexData = vertices
      .SelectMany(v => new float[] { v.X, v.Y, v.Z })
      .ToArray();
    GL.BufferData(
      BufferTarget.ArrayBuffer,
      vertexData.Length * sizeof(float),
      vertexData,
      BufferUsageHint.StaticDraw
    );

    return new VertexBuffer(vertexBufferObject, vertices.Length * 3);
  }
}
