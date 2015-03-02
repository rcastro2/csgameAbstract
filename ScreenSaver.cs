using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CSGame{
  class ScreenSaver{
    // Modify Line 53 of Game.cs to match the class name above
    Setting game;

    Color c;
    SolidBrush b;

    int x,y,dx=5,dy=5,r,dr=1,s=100,ds=1;

    public ScreenSaver(Setting game){
      this.game = game;
    }

    public void update(){
        c = Color.FromArgb(r,0,0);
        b = new SolidBrush(c);

        game.canvas.FillEllipse(b,x,y,s,s);

        r+=dr;
        if(r>254||r<1)dr=-dr;

        s+=ds;
        if(s>150||s<50)ds=-ds;

        x+=dx;y+=dy;
        if(x<0||x+s>game.width)dx=-dx;
        if(y<0||y+s>game.height)dy=-dy;

    }
  }
}
