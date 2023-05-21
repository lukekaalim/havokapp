using OpenTK.Graphics.OpenGL4;

namespace LKEngine;

public record ShaderProgram(int Handle, ShaderLayout Layout) {
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

    var layout = ShaderLayout.Calculate(programHandle);

    return new ShaderProgram(programHandle, layout);
  }
}

public record ShaderLayout(Dictionary<string, int> Attributes, Dictionary<string, int> Uniforms) {
  public static ShaderLayout Calculate(int programHandle) {
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

    return new ShaderLayout(attributeHandles, uniformHandles);
  }
}