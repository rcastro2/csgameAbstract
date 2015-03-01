using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CSGame{
  class Template{
    // Modify Line 47 of Game.cs to match the class name above
    Graphics canvas;
    Input input;
    Setting game;

    public Template(Graphics canvas, Input input, Setting game){
      this.canvas = canvas;
      this.input = input;
      this.game = game;
    }

    public void update(){

    }
  }
}
