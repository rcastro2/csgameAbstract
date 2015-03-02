using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CSGame{
  class Polygon{
    Setting game;
    int c=50,dc=1,s=50,ds=2,speed,sides,size;
    double angle,da=0.02,offset,x,y,dx,dy;
    Point[] points;
    Color color;
    SolidBrush brush;

    public Polygon(Setting game, int x, int y, int speed, double angle, int sides, int size){
      this.game = game;
      this.x = x; this.y = y;
      this.angle = angle;
      this.sides = sides;
      this.speed = speed;
      this.size = size;

      offset = 2*Math.PI/sides;
      dx = speed * Math.Cos(angle);
      dy = speed * Math.Sin(angle);
    }

    public void draw(){
      color = Color.FromArgb(c,c,c);
      brush = new SolidBrush(color);

      angle+=da;

      points = new Point[sides];
      for(int index = 0; index < sides; index++){
        int tmpx = (int)x + (int)(size*Math.Cos(angle + offset*index));
        int tmpy = (int)y + (int)(size*Math.Sin(angle + offset*index));
        points[index] = new Point(tmpx,tmpy);
      }
      game.canvas.FillPolygon(brush,points);

      c+=dc;
      if(c>250||c<5)dc=-dc;
      s+=ds;
      if(s>100||s<50)ds=-ds;
      x+=dx;y+=dy;
      if(x<0||x>game.form.Width)dx=-dx;
      if(y<0||y>game.form.Height)dy=-dy;
    }
  }
}
