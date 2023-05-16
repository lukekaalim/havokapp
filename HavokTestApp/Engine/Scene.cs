using OpenTK.Graphics.OpenGL4;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace HavokTestApp.Engine;

public record Scene(Mesh[] Meshes) {

  public sealed record Binding(
    ImmutableDictionary<ShaderProgram, ShaderProgram.Binding> Shaders,
    Mesh.Binding[] Meshes,
    Scene From
  ): IDisposable {
    public void Render() {
      foreach (var boundMesh in Meshes)
        boundMesh.Render();
    }
    public void Dispose()
    {
      foreach (var boundMesh in Meshes) {
        boundMesh.Dispose();
      }
      foreach (var shaderBinding in Shaders.Values) {
        shaderBinding.Dispose();
      }
    }
  }

  public Binding Bind() {
    var shaders = Meshes
      .Select(mesh => mesh.Shader)
      .Distinct()
      .ToImmutableDictionary(shader => shader, shader => shader.Bind());
    var meshes = Meshes
      .Select(mesh => mesh.Bind(shaders[mesh.Shader]))
      .ToArray();

    return new Binding(shaders, meshes, this);
  }
}