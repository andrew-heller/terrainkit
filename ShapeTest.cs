using SkiaSharp;

public static class ShapeTest{

    public static void Test(){
        
      //test shapes
      var sz = new Size(){
            Width=36,
            Height=48
      };


      var paints = new List<SKPaint>(){
			
		 new SKPaint(){
			Color = SKColors.LightCoral
		},
             new SKPaint(){
			Color = SKColors.LightGreen
		},
             new SKPaint(){
			Color = SKColors.White
		},

		new SKPaint(){
			Color= SKColors.BlueViolet,
			IsAntialias=true,
			 Style= SKPaintStyle.StrokeAndFill,
			 StrokeWidth = 4,
			 StrokeJoin = SKStrokeJoin.Miter
		},

		new SKPaint(){
			Color = SKColors.Blue,
			Style= SKPaintStyle.Stroke,
			
		},
		 new SKPaint(){
			Color = SKColors.SeaGreen

		},

		new SKPaint(){
			Color = SKColors.Chocolate,
			IsAntialias=true,

		},
		new SKPaint(){
			Color = SKColors.Black,
			 Style= SKPaintStyle.Stroke,
			 StrokeWidth= 4

		}
            };


      var shapes = new List<Shape>();

shapes.Add(new Shape(){
      Type= ShapeType.box,
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 1,Size.InchesToPixelsMultiplier * 1),
      Width = Size.InchesToPixelsMultiplier * 8,
      Height= Size.InchesToPixelsMultiplier * 4,
      BorderBottom=true,
      BorderLeft=true,
      BorderRight=true,
      BorderTop=true}
      );

shapes.Add(new Shape(){
      Type= ShapeType.borders,
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 1,Size.InchesToPixelsMultiplier * 6),
      Width = Size.InchesToPixelsMultiplier * 8,
      Height=Size.InchesToPixelsMultiplier * 12,
        BorderBottom=true,
      BorderLeft=true,
      BorderRight=true,
      BorderTop=true}
      );


shapes.Add(new Shape(){
      Type= ShapeType.borders,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 1,Size.InchesToPixelsMultiplier * 9),
      Width = Size.InchesToPixelsMultiplier * 4,
      Height= Size.InchesToPixelsMultiplier * 7,
      BorderTop=true, MidVertical=true}
      );

shapes.Add(new Shape(){
      Type= ShapeType.borders,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 15,Size.InchesToPixelsMultiplier * 1),
      Width = Size.InchesToPixelsMultiplier * 3,
      Height= Size.InchesToPixelsMultiplier * 9,
      BorderLeft=true,BorderRight=true,BorderTop=true
      }
      );

      shapes.Add(new Shape(){
      Type= ShapeType.borders,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 6,Size.InchesToPixelsMultiplier * 10),
      Width = Size.InchesToPixelsMultiplier * 6,
      Height= Size.InchesToPixelsMultiplier * 2,
      BorderLeft=true, BorderTop=true}
      );

  shapes.Add(new Shape(){
      Type= ShapeType.borders,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 15,Size.InchesToPixelsMultiplier * 15),
      Width = Size.InchesToPixelsMultiplier * 6,
      Height= Size.InchesToPixelsMultiplier * 6,
      BorderTop=true,
      BorderRight=true,
      BorderBottom=true,
      BorderLeft=true,
      MidHorizonal=true,
      MidVertical=true}
      );

      shapes.Add(new Shape(){
      Type= ShapeType.borders,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 15,Size.InchesToPixelsMultiplier * 27),
      Width = Size.InchesToPixelsMultiplier * 6,
      Height= Size.InchesToPixelsMultiplier * 6,
      BorderTop=true,
      BorderRight=true,
      BorderBottom=true,
      BorderLeft=true
      //MidHorizonal=true,
      //MidVertical=true
      }
      );

       shapes.Add(new Shape(){
      Type= ShapeType.borders,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 15,Size.InchesToPixelsMultiplier * 39),
      Width = Size.InchesToPixelsMultiplier * 6,
      Height= Size.InchesToPixelsMultiplier * 6,

      MidHorizonal=true,
      MidVertical=true
      });

       shapes.Add(new Shape(){
      Type= ShapeType.triangle,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 15,Size.InchesToPixelsMultiplier * 45),
      Width = Size.InchesToPixelsMultiplier * 6,
      Height= Size.InchesToPixelsMultiplier * 6,
      });

 shapes.Add(new Shape(){
      Type= ShapeType.Circle,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 20,Size.InchesToPixelsMultiplier * 10),

      });

      
 shapes.Add(new Shape(){
      Type= ShapeType.triangle,
      //start point
      position = new SkiaSharp.SKPoint(Size.InchesToPixelsMultiplier * 20,Size.InchesToPixelsMultiplier * 10),
Width = Size.InchesToPixelsMultiplier * 3,
Height=Size.InchesToPixelsMultiplier * 2
      });




            var img = DrawingHelper.CreateImage(sz.WidthPixels(),sz.HeightPixels());

            using(var sfc = DrawingHelper.CreateSurface(img)){

                  //set a global background color
                  sfc.Canvas.Clear(SKColors.WhiteSmoke);

                  DrawingHelper.DrawShapes(sfc ,shapes, paints);

                  DrawingHelper.DrawGrid(img,sfc, SKColors.LightGray,1);
                  DrawingHelper.DrawGrid(img,sfc, SKColors.Gray,6);
                  DrawingHelper.DrawGrid(img,sfc, SKColors.Black,12);
                  
                  DrawingHelper.WritePNG(sfc,"drawshapestest.png");    
            }
    }
}