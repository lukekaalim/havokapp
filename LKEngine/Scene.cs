namespace LKEngine;

public record Scene(List<Graphic> Graphics) {
  public void Render() {
    foreach (var graphic in Graphics)
      graphic.Render();
  }
}
