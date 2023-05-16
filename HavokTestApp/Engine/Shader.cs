using System;
using System.Collections.Generic;

using OpenTK.Graphics.OpenGL4;

namespace HavokTestApp.Engine;

public record ShaderProgram(Shader Vertex, Shader Fragment) {
  public sealed record Binding(
    int ProgramHandle,
    Dictionary<string, int> UniformHandles,
    Dictionary<string, int> AttributeHandles
  ): IDisposable {
    public void Dispose() => GL.DeleteProgram(ProgramHandle);
  }

  public int LinkProgram(Shader.Binding boundFragment, Shader.Binding boundVertex) {
    var programHandle = GL.CreateProgram();

    GL.AttachShader(programHandle, boundFragment.ShaderHandle);
    GL.AttachShader(programHandle, boundVertex.ShaderHandle);

    GL.LinkProgram(programHandle);

    GL.DetachShader(programHandle, boundFragment.ShaderHandle);
    GL.DetachShader(programHandle, boundVertex.ShaderHandle);
    return programHandle;
  }

  public static Dictionary<string, int> FindUniformHandles(int programHandle) {
    GL.GetProgram(programHandle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
    var uniformHandles = new Dictionary<string, int>();
    for (var i = 0; i < numberOfUniforms; i++)
    {
        var key = GL.GetActiveUniform(programHandle, i, out _, out _);
        var location = GL.GetUniformLocation(programHandle, key);
        uniformHandles.Add(key, location);
    }
    return uniformHandles;
  }
  public static Dictionary<string, int> FindAttributeHandles(int programHandle) {
    GL.GetProgram(programHandle, GetProgramParameterName.ActiveAttributes, out var numberOfAttributes);
    GL.GetProgram(programHandle, GetProgramParameterName.ActiveAttributeMaxLength, out var maxAttributeNameLength);

    var attributeHandles = new Dictionary<string, int>();
    for (var i = 0; i < numberOfAttributes; i++)
    {
        GL.GetActiveAttrib(programHandle, i, maxAttributeNameLength, out _, out _, out _, out var name);
        var location = GL.GetAttribLocation(programHandle, name);
        attributeHandles.Add(name, location);
    }
    return attributeHandles;
  }

  public Binding Bind() {
    using var fragmentHandle = Fragment.Bind();
    using var vertexHandle = Vertex.Bind();

    var programHandle = LinkProgram(fragmentHandle, vertexHandle);
    var uniformHandles = FindUniformHandles(programHandle);
    var attributeHandles = FindAttributeHandles(programHandle);

    return new Binding(programHandle, uniformHandles, attributeHandles);
  }
}

public record Shader(string SourceCode, ShaderType Type) {
  public sealed record Binding(int ShaderHandle) : IDisposable
  {
    public All CompileStatus {
      get {
        GL.GetShader(ShaderHandle, ShaderParameter.CompileStatus, out var code);
        return (All)code;
      }
    }
    public string InfoLog => GL.GetShaderInfoLog(ShaderHandle);

    public void Dispose() => GL.DeleteShader(ShaderHandle);
  }

  public Binding Bind() {
    var shaderHandle = GL.CreateShader(Type);
    GL.ShaderSource(shaderHandle, SourceCode);
    GL.CompileShader(shaderHandle);
    return new Binding(shaderHandle);
  }
}