using System;
using System.Linq;
using System.Collections.Generic;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace HavokTestApp.Engine2;

public record Graphic(VertexBuffer Geometry, ShaderProgram Material) {}

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

public record ShaderProgram(int Handle) {
  public sealed record Shader(int Handle): IDisposable
  {
    public void Dispose() => GL.DeleteShader(Handle);

    public static implicit operator int(Shader shader) => shader.Handle;

    public static Shader CreateFromSourceCode(string sourceCode, ShaderType type) {
      var handle = GL.CreateShader(type);
      GL.ShaderSource(handle, sourceCode);
      GL.CompileShader(handle);
      return new Shader(handle);
    }
  }

  public record Layout(Dictionary<string, int> Attributes, Dictionary<string, int> Uniforms) {
    public static Layout Calculate(ShaderProgram program) {
      GL.GetProgram(program, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
      GL.GetProgram(program, GetProgramParameterName.ActiveAttributes, out var numberOfAttributes);
      GL.GetProgram(program, GetProgramParameterName.ActiveAttributeMaxLength, out var maxAttributeNameLength);

      var uniformHandles = new Dictionary<string, int>();
      var attributeHandles = new Dictionary<string, int>();

      for (var i = 0; i < numberOfUniforms; i++)
      {
          var key = GL.GetActiveUniform(program, i, out _, out _);
          var location = GL.GetUniformLocation(program, key);
          uniformHandles.Add(key, location);
      }
      for (var i = 0; i < numberOfAttributes; i++)
      {
          GL.GetActiveAttrib(program, i, maxAttributeNameLength, out _, out _, out _, out var name);
          var location = GL.GetAttribLocation(program, name);
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

    return new ShaderProgram(programHandle);
  }
}

public abstract record Uniform(string Name) {}

public record FloatUniform(string Name)    : Uniform(Name) {}
public record Vector4Uniform(string Name)  : Uniform(Name) {}
public record Matrix4Uniform(string Name)  : Uniform(Name) {}
