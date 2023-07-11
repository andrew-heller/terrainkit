using SkiaSharp;

public static class DrawingHelper{


    public static void WritePNG(SKSurface surface,string filename){

// save the file
				using (var image = surface.Snapshot())
				using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
				using (var stream = File.OpenWrite(filename))
				{
					data.SaveTo(stream);
				}
    }


public static SKSurface CreateSurface(SKImageInfo info){
	return  SKSurface.Create(info);
}


public static void DrawShapes(SKSurface surface, List<Shape> shapes, List<SKPaint> paints){

		var canvas = surface.Canvas;
	
		foreach(var shp in shapes){


var paintcolor = paints[shp.PaintIndex];

		switch(shp.Type){
			case ShapeType.Circle:
			
			 	canvas.DrawCircle(shp.position.X,shp.position.Y,shp.Width,paintcolor);
				break;

			case ShapeType.line:

				var endpt = new SKPoint(shp.position.X + shp.Width, shp.position.Y + shp.Height);

			 	canvas.DrawLine(shp.position,endpt,paintcolor);

				break;
			case ShapeType.box: //is a line
				AddBox(shp,canvas,paintcolor);
				break;

			case ShapeType.triangle:

				AddTriangle(shp,canvas,paintcolor);
				break;

			case ShapeType.l_shape:

				AddLShape(shp,canvas,paintcolor);
				break;
			case ShapeType.u_shape:

				AddUShape(shp,canvas,paintcolor);
				break;
			case ShapeType.borders:

				AddBorders(shp,canvas,paintcolor);
				break;

			default:
			//show text?
			break;
		}


}

				
// draw some text
// var paint = new SKPaint
// 				{
// 					Color = SKColors.Black,
// 					IsAntialias = true,
// 					Style = SKPaintStyle.Fill,
// 					TextAlign = SKTextAlign.Center,
// 					TextSize = 24
// 				};
				//var coord = new SKPoint(info.Width / 2, (info.Height + paint.TextSize) / 2);
				//draw text
				//canvas.DrawText(this.Description, coord, paint);


				
			}


public static void AddUShape(Shape shp, SKCanvas canvas, SKPaint tcolor){


		var Longside = new Shape(){
			Width = shp.Width,
			Height = Size.InchesToPixelsMultiplier,
			Type = ShapeType.box,
			position= shp.position

		};

		var smallsideLeft = new Shape(){
			Type= ShapeType.box,
			Width = Size.InchesToPixelsMultiplier,
			Height = shp.Height,
			position= new SKPoint(shp.position.X,shp.position.Y)
		};

		var smallsideRight = new Shape(){
			Type= ShapeType.box,
			Width = Size.InchesToPixelsMultiplier,
			Height = shp.Height,
			//subtract 1 for thikness of bar from left most position
			position= new SKPoint(shp.position.X + shp.Width - Size.InchesToPixelsMultiplier,shp.position.Y)
		};

		AddBox(Longside,canvas,tcolor);
		AddBox(smallsideLeft,canvas,tcolor);
		AddBox(smallsideRight,canvas,tcolor);




}

public static void AddLShape(Shape shp, SKCanvas canvas, SKPaint tcolor){

//bounding box for shape
//turn single shage into 3 rects

		var isHorizontal = shp.Width > shp.Height ? true : false;
		
		if(isHorizontal){

		}

		var Longside = new Shape(){
			Width = shp.Width,
			Height = Size.InchesToPixelsMultiplier,
			Type = ShapeType.box,
			position= shp.position

		};

		var smallsideLeft = new Shape(){
			Type= ShapeType.box,
			Width = Size.InchesToPixelsMultiplier,
			Height = shp.Height,
			position= new SKPoint(shp.position.X,shp.position.Y)
		};

	

		AddBox(Longside,canvas,tcolor);
		AddBox(smallsideLeft,canvas,tcolor);
		




}


public static void AddTriangle(Shape shp, SKCanvas canvas, SKPaint tcolor){


	var path2 = new SKPath { FillType = SKPathFillType.EvenOdd };
	path2.MoveTo(shp.position.X, shp.position.Y);
	path2.LineTo(shp.position.X + shp.Width, shp.position.Y);
	path2.LineTo(shp.position.X+ shp.Width,shp.position.Y + shp.Height);
	path2.Close();

	canvas.DrawPath(path2,tcolor);
}

public static void AddBox(Shape shp,SKCanvas canvas,SKPaint boxcolor){
	var pth = new SKPath();
			var rec = new SKRect();
				rec.Top = shp.position.Y;
				rec.Left = shp.position.X;
				rec.Right = rec.Left + shp.Width;
				rec.Bottom = rec.Top + shp.Height;
				
			pth.AddRect(rec);
			canvas.DrawPath(pth,boxcolor);
		

}

public static SKImageInfo CreateImage(int width, int height)
{
     //define image size
     var info = new SKImageInfo(width, height);

            return info;
}
    
public static void AddBorders(Shape shp, SKCanvas canvas, SKPaint tcolor){

		//top
		if(shp.BorderTop){
				AddBox(new Shape(){
					Width = shp.Width,
					Height = Size.InchesToPixelsMultiplier,
					Type = ShapeType.box,
					position= shp.position

				}, canvas, tcolor);
		}

		//bottom
		if(shp.BorderBottom){
				AddBox(new Shape(){
					Width = shp.Width,
					Height = Size.InchesToPixelsMultiplier,
					Type = ShapeType.box,
					position= new SKPoint(shp.position.X,shp.position.Y + shp.Height - Size.InchesToPixelsMultiplier)
				},
				canvas, tcolor);
		}
		//left
		if(shp.BorderLeft){
				AddBox( new Shape(){
					Type= ShapeType.box,
					Width = Size.InchesToPixelsMultiplier,
					Height = shp.Height,
					position= new SKPoint(shp.position.X,shp.position.Y)
				},
				canvas, tcolor);
		}
		//right border
		if(shp.BorderRight){
				AddBox( new Shape(){
					Type= ShapeType.box,
					Width = Size.InchesToPixelsMultiplier,
					Height = shp.Height,
					//subtract 1 for thikness of bar from left most position
					position= new SKPoint(shp.position.X + shp.Width - Size.InchesToPixelsMultiplier,shp.position.Y)
				},
				canvas, tcolor);
		}


		if(shp.MidVertical){
				AddBox(  new Shape(){
					Type= ShapeType.box,
					Width = Size.InchesToPixelsMultiplier,
					Height = shp.Height,
					position= new SKPoint( (shp.position.X + shp.Width/2 ) - Size.InchesToPixelsMultiplier/2,shp.position.Y)
				},
				canvas,tcolor);
		}

		if(shp.MidHorizonal){
				AddBox(  new Shape(){
					Type= ShapeType.box,
					Height = Size.InchesToPixelsMultiplier,
					Width = shp.Width,
					position= new SKPoint( shp.position.X,(shp.position.Y + shp.Height/2 )- Size.InchesToPixelsMultiplier/2)
				},
				canvas,tcolor);

		}
}


public static void DrawGrid(SKImageInfo info,SKSurface surface, SKColor color, int scale){

		var paint = new SKPaint
						{
							Color = color,
							IsAntialias = true,
							Style = SKPaintStyle.Fill,
							TextAlign = SKTextAlign.Center,
							TextSize = 24
						};

				
			//draw grid
			var origin = new SKPoint(0,0); //upperleft corner
			var bottompoint = new SKPoint(0,info.Height);
			for(int x = 0; x<= info.Width; x+=(Size.InchesToPixelsMultiplier*scale) ){
			
				origin.X = x;
				bottompoint.X = x;

				surface.Canvas.DrawLine(origin,bottompoint,paint);

			}
			//reset back to zero
			origin.X=0;
			bottompoint.X=info.Width;

			for(int y = 0; y<= info.Height; y+=(Size.InchesToPixelsMultiplier*scale)){
			
				origin.Y = y;
				bottompoint.Y = y;

				surface.Canvas.DrawLine(origin,bottompoint,paint);

			}
	}
}