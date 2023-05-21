namespace LKEngine.Shaders;

public static class IndexColorShader
{
  public static ShaderProgram CreateProgram() {
      var fragmentShader = """
      #version 330

      out vec4 outputColor;

      uniform vec4 ourColor;
      in float indexColor;

      void main()
      {
          outputColor = ourColor + ((indexColor - 0.5) * 0.5);
      }
      """;

      var vertexShader = """
      #version 330 core

      in vec3 aPosition;

      uniform mat4 transform;
      out float indexColor;

      void main(void)
      {
        gl_Position = vec4(aPosition, 1.0f) * transform;
        
        float r, g, b;
        int index = gl_VertexID * 10;
        indexColor = (index % 256) / 255.0f;
      }
      """;
      var shader = ShaderProgram.CreateFromSouceCode(fragmentShader, vertexShader);
      return shader;
  }
}
