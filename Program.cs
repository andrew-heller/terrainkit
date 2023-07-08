using System.Collections.Generic;
using SkiaSharp;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Terrain Kit!");

 
var MyMap = new Map();

MyMap.Description ="MY FIRST TEST MAP";
MyMap.Name="Test";
MyMap.Size.Width= 48; //inchecs
MyMap.Size.Height = 36;

MyMap.Zones.Add(new MapZone(){
      ZoneType = ZoneType.Deployment
      
}
);

MyMap.Zones.Add(new MapZone(){
      ZoneType = ZoneType.Deployment
}
);

MyMap.Zones.Add(new MapZone(){
      ZoneType = ZoneType.NoMansLand,
      Objective = new MapObjective()
}
);

Console.WriteLine($"Map \"{MyMap.Name}\" has {MyMap.Zones.Count} zones");



//MyMap.ExportMapPNG("mymap.png");



//test shapes
var sz = new Size(){
 Width=36,
 Height=48
};


var shapes = new List<Shape>();

shapes.Add(new Shape(){
      Type= ShapeType.box,
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 1,Size.InchesToPixelsMultiplier * 1),
      Width = Size.InchesToPixelsMultiplier * 8,
      Height= Size.InchesToPixelsMultiplier * 4}
      );

shapes.Add(new Shape(){
      Type= ShapeType.box,
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 1,Size.InchesToPixelsMultiplier * 6),
      Width = Size.InchesToPixelsMultiplier * 8,
      Height=Size.InchesToPixelsMultiplier * 12}
      );


shapes.Add(new Shape(){
      Type= ShapeType.t_shape,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 1,Size.InchesToPixelsMultiplier * 9),
      Width = Size.InchesToPixelsMultiplier * 4,
      Height= Size.InchesToPixelsMultiplier * 7}
      );

shapes.Add(new Shape(){
      Type= ShapeType.u_shape,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 15,Size.InchesToPixelsMultiplier * 1),
      Width = Size.InchesToPixelsMultiplier * 3,
      Height= Size.InchesToPixelsMultiplier * 9}
      );

      shapes.Add(new Shape(){
      Type= ShapeType.l_shape,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 6,Size.InchesToPixelsMultiplier * 10),
      Width = Size.InchesToPixelsMultiplier * 6,
      Height= Size.InchesToPixelsMultiplier * 2}
      );




var img = DrawingHelper.CreateImage(sz.WidthPixels(),sz.HeightPixels());

using(var sfc = DrawingHelper.CreateSurface(img)){

      //set a global background color
      sfc.Canvas.Clear(SKColors.DarkGray);

      DrawingHelper.DrawShapes(sfc ,shapes);

      DrawingHelper.DrawGrid(img,sfc, SKColors.LightGray,1);
      DrawingHelper.DrawGrid(img,sfc, SKColors.Black,12);
      
      DrawingHelper.WritePNG(sfc,"drawshapestest.png");    
}

