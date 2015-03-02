using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSGame{
  class ScreenSaverII{
    // Modify Line 47 of Game.cs to match the class name above
    Setting game;
    List<Polygon> polygons;
    Random g = new Random();

    public ScreenSaverII(Setting game){
      this.game = game;
      game.interval = 1;
      game.form.TransparencyKey = Color.White;
      game.form.FormBorderStyle = FormBorderStyle.None;
      game.form.WindowState = FormWindowState.Maximized;
      polygons = new List<Polygon>();

      double angle = 0;
      for(int pos = 1; pos <= 8; pos++){
        polygons.Add(new Polygon(game,game.form.Width/2,game.form.Height/2,2,angle,3,50));
        angle += Math.PI /  4;
      }
    }

    public void update(){
      foreach(Polygon p in polygons)
        p.draw();
      if(game.keyDown == "Q")
        System.Windows.Forms.Application.Exit();
      //Uncomment code below for interactive screensaver
      /*
      if(game.leftButton)
        polygons.Add(new Polygon(game,game.mouseX,game.mouseY,2,2*Math.PI/g.Next(0,36),3,50));
      */


    }
  }
}
