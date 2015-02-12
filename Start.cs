using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CSGame{
  class Start{

    Graphics canvas;
    Input input;

    public Start(Graphics canvas, Input input){
      this.canvas = canvas;
      this.input = input;

    }

    public void update(){
      if(input.keyDown=="Q")
        canvas.FillEllipse(new SolidBrush(Color.Green),input.mouseX,input.mouseY,20,20);
      if(input.leftButton)
        canvas.FillEllipse(new SolidBrush(Color.Blue),input.mouseX,input.mouseY,50,50);
      canvas.DrawRectangle(new Pen(Color.Red),input.mouseX,input.mouseY,100,100);

    }
  }
}
