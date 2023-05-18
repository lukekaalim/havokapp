using System;
using System.Linq;
using System.Collections.Generic;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace HavokTestApp.Engine;


public record Graphic(VertexArray Geometry, ShaderProgram Material) {
  public void Render() {
      GL.UseProgram(Material);
      GL.BindVertexArray(Geometry);
      GL.DrawArrays(PrimitiveType.Triangles, 0, Geometry.Length);
  }

  public void SetUniform(string name, Vector4 value) {
    var uniformLayout = Material.LayoutLookup.Uniforms[name];
    GL.UseProgram(Material);
    GL.Uniform4(uniformLayout, value.X, value.Y, value.Z, value.W);
  }

  public void SetMatrixUniform(string name, ref Matrix4 value) {
    var uniformLayout = Material.LayoutLookup.Uniforms[name];
    GL.UseProgram(Material);
    GL.UniformMatrix4(uniformLayout, true, ref value);
  }
}

public record Scene(List<Graphic> Graphics) {
  public void Render() {
    foreach (var graphic in Graphics)
      graphic.Render();
  }
}

public record VertexArray(int Handle, int Length) {
  public static implicit operator int(VertexArray arr) => arr.Handle;
  
  public static VertexArray CreateFromBuffer(VertexBuffer buffer, int length, ShaderProgram.Layout layout) {
    var vertexArrayObjectHandle = GL.GenVertexArray();

    GL.BindVertexArray(vertexArrayObjectHandle);
    GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);

    var attributeIndex = layout.Attributes["aPosition"];

    GL.VertexAttribPointer(attributeIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
    GL.EnableVertexAttribArray(attributeIndex);

    return new VertexArray(vertexArrayObjectHandle, length);
  }
}

public record VertexBuffer(int Handle) {
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

    return new VertexBuffer(vertexBufferObject);
  }
}

public record ShaderProgram(int Handle, ShaderProgram.Layout LayoutLookup) {
  public sealed record Shader(int Handle): IDisposable
  {
    public void Dispose() => GL.DeleteShader(Handle);

    public static implicit operator int(Shader shader) => shader.Handle;

    public static Shader CreateFromSourceCode(string sourceCode, ShaderType type) {
      var handle = GL.CreateShader(type);
      GL.ShaderSource(handle, sourceCode);
      GL.CompileShader(handle);

      GL.GetShader(handle, ShaderParameter.CompileStatus, out int success);
      if (success == 0)
      {
          string infoLog = GL.GetShaderInfoLog(handle);
          throw new Exception(infoLog);
      }
      return new Shader(handle);
    }
  }

  public record Layout(Dictionary<string, int> Attributes, Dictionary<string, int> Uniforms) {
    public static Layout Calculate(int programHandle) {
      GL.GetProgram(programHandle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
      GL.GetProgram(programHandle, GetProgramParameterName.ActiveAttributes, out var numberOfAttributes);
      GL.GetProgram(programHandle, GetProgramParameterName.ActiveAttributeMaxLength, out var maxAttributeNameLength);

      var uniformHandles = new Dictionary<string, int>();
      var attributeHandles = new Dictionary<string, int>();

      for (var i = 0; i < numberOfUniforms; i++)
      {
          var key = GL.GetActiveUniform(programHandle, i, out _, out _);
          var location = GL.GetUniformLocation(programHandle, key);
          uniformHandles.Add(key, location);
      }
      for (var i = 0; i < numberOfAttributes; i++)
      {
          GL.GetActiveAttrib(programHandle, i, maxAttributeNameLength, out _, out _, out _, out var name);
          var location = GL.GetAttribLocation(programHandle, name);
          attributeHandles.Add(name, location);
      }

      return new Layout(attributeHandles, uniformHandles);
    }
  }

  public static implicit operator int(ShaderProgram shader) => shader.Handle;

  public static ShaderProgram CreateFromSouceCode(string fragmentSourceCode, string vertexSourceCode) {
    var programHandle = GL.CreateProgram();
    using var fragmentShader = Shader.CreateFromSourceCode(fragmentSourceCode, ShaderType.FragmentShader);
    using var vertexShader = Shader.CreateFromSourceCode(vertexSourceCode, ShaderType.VertexShader);

    GL.AttachShader(programHandle, fragmentShader);
    GL.AttachShader(programHandle, vertexShader);

    GL.LinkProgram(programHandle);

    GL.DetachShader(programHandle, fragmentShader);
    GL.DetachShader(programHandle, vertexShader);

    var layout = Layout.Calculate(programHandle);

    return new ShaderProgram(programHandle, layout);
  }
}

public abstract record Uniform(string Name) {}

public record FloatUniform(string Name)    : Uniform(Name) {}
public record Vector4Uniform(string Name)  : Uniform(Name) {}
public record Matrix4Uniform(string Name)  : Uniform(Name) {}

